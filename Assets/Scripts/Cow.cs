using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    //ENUMS
    public enum State
    {
        Calm,
        Alert,
        Panic,
        Hidden
    }


    //DATA
    private SpriteRenderer spriteRenderer;
    ///INNATE COW DATA
    private State currentState = State.Calm;
    public State CurrentState { get { return currentState; } }
    public bool IsCalm { get { return (currentState == State.Calm); } }
    public bool IsAlert { get { return (currentState == State.Alert || currentState == State.Panic); } }



    [SerializeField] private ScriptableCow cowTemplate;
    public ScriptableCow CowTemplate { get { return cowTemplate; } }

    private Hideout targetHideout;
    public Hideout TargetHideout { get { return targetHideout; } }
    public bool HasChosenHideout { get { return (targetHideout != null); } }



    ///CLONED DATA
    ///UNIQUE ID
    private ScriptableCow.UniqueID uid;
    public ScriptableCow.UniqueID UID { get { return uid; } }
    ///RARITY
    private ScriptableCow.Rarity rarity;
    public ScriptableCow.Rarity Rarity { get { return rarity; } }



    /// SIMPLE DATA
    private string cowName;
    public string CowName { get { return cowName; } }

    private int fuelRecoveryAmount;
    public int FuelRecoveryAmount { get { return fuelRecoveryAmount; } }

    private float alertRadius;
    public float AlertRadius { get { return alertRadius; } }//TODO: HAS TO BE MORPHED IN COW UNITS

    private float speedCalm;
    private float speedAlert;

    private int score;
    public int Score { get { return score; } }

    ///TIMERS
    [Min(0f)] private float TimerAlertToCalm;
    [Min(0f)] private float TimerAlertToPanic;
    [Min(0f)] private float TimerCalmMovement;
    [Min(0f)] private float TimerCalmStill;

    [Min(0f)] private float timerAlertSpecialMovement;
    public float TimerAlertSpecialMovement { get { return timerAlertSpecialMovement; } }



    /// COMPLEX DATA
    private List<ScriptableHideout.Type> favouriteHideoutTypes = new();
    public List<ScriptableHideout.Type> FavouriteHideoutTypes { get { return favouriteHideoutTypes; } }

    private List<SpawnPoint.Type> allowedSpawnPointTypes = new();
    public List<SpawnPoint.Type> AllowedSpawnPointTypes { get { return allowedSpawnPointTypes; } }



    private AbstractAlteration.EBuffType alteration;
    public AbstractAlteration.EBuffType Alteration { get { return alteration; } }


    //TODO: EVALUATE FURTHER DIVERSIFICATION OF MOVEMENT PATTERNS
    private AbstractMovementPattern movPatternCalm;
    private AbstractMovementAlert movPatternAlert;


    //TECHNICAL DATA FOR OTHER PURPOSES
    private SpriteRenderer sr;
    private Rigidbody rb;

    private Vector3 movementDirection = Vector3.forward;
    public Vector3 MovementDirection { get { return movementDirection; } }





    //METHODS
    //...
    private void Awake()
    {
        if(cowTemplate != null) CloneFromTemplate();
        else Debug.LogWarning("COW WITHOUT TEMPLATE (SCRIPTABLE COW) " + this.gameObject.name);

        //OTHER TECHNICAL AWAKE SETUP
        spriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        spriteRenderer.receiveShadows = true;

        rb = this.gameObject.GetComponent<Rigidbody>();

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (movementDirection.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }


    //TODO: CHANGE UPDATE AND FIXEDUPDATE SO THAT:
    //      FIXEDUPDATE SEARCHS FOR THE AVAILABLE HIDEOUTS ACCORDING TO THE ALGORITHM DESCRIBED IN COW GDD
    //      FIXEDUPDATE HANDLES THE COW MOVEMENT
    //      UPDATE HANDLES ALL THE TIMERS AND BEHAVIOURS
    private void FixedUpdate()
    {
        //
        HandleMovement();

        //STEP 1
        if (CowHelper.IsUFOWithinRadius(this))
        {
            if (IsCalm) this.currentState = State.Alert;
            this.TimerAlertToCalm = cowTemplate.TimerAlertToCalm;
        }
        else
        {
            this.TimerAlertToCalm -= Time.deltaTime;
            if (this.TimerAlertToCalm <= 0.0f) this.currentState = State.Calm;
        }


        //STEP 2
        if (IsAlert)
        {
            //LOWER THE TIMER USED FOR SPECIAL MOVEMENTS
            if(this.timerAlertSpecialMovement > 0.0f) this.timerAlertSpecialMovement -= Time.deltaTime;


            Mathf.Clamp(this.TimerAlertToPanic, 0, cowTemplate.TimerAlertToPanic);
            if (CowHelper.IsUFOWithinRadius(this) && this.TimerAlertToPanic > 0) this.TimerAlertToPanic -= Time.deltaTime;
            //Debug.Log("TimerAlertToPanic: " + this.TimerAlertToPanic);

            //ALERT SUB-STATE
            if (this.TimerAlertToPanic > 0.0f) HandleAlertMovement();
            //PANIC SUB-STATE
            else
            {
                this.targetHideout = CowHelper.FindHideout(this);

                //REMAIN IN ALERT-SUBSTATE BEHAVIOUR
                if (!HasChosenHideout) HandleAlertMovement();
                else if (targetHideout.HasAvailableSlots()) HandlePanicMovement();

                if (CowHelper.CanEnterHideout(this)) CowHelper.EnterHideout(this);

            }
        }
        else
        {
            //RESET PANIC TIMER
            this.TimerAlertToPanic = cowTemplate.TimerAlertToPanic;

            //HANDLE CALM MOVEMENT PHASES
            if (TimerCalmMovement > 0.0f)
            {
                TimerCalmMovement -= Time.deltaTime;
            } 
            else if (TimerCalmStill > 0.0f)
            {
                TimerCalmStill -= Time.deltaTime;
                movementDirection = Vector3.zero;
            }
            else
            {
                TimerCalmMovement = cowTemplate.TimerCalmMovement;
                TimerCalmStill = cowTemplate.TimerCalmStill;

                //RESETTING THE MOVEMENT DIRECTION RANDOMLY BASED ON CALM PATTERN
                movementDirection = movPatternCalm.ManageMovement(this);
                //Debug.Log("movementDirection: " + movementDirection);
            }
        }


    }


    //ENABLEMENT/DISABLEMENT
    private void OnEnable()
    {
        this.movementDirection = Vector3.zero;
        this.currentState = State.Calm;

        //RESET TIMERS
        this.TimerCalmMovement = cowTemplate.TimerCalmMovement;
        this.TimerCalmStill = cowTemplate.TimerCalmStill;
        this.TimerAlertToCalm = cowTemplate.TimerAlertToCalm;
        this.TimerAlertToPanic = cowTemplate.TimerAlertToPanic;
    }

    private void OnDisable()
    {

    }




    //FUNCTIONALITIES
    private void HandleMovement()
    {
        float mySpeed;
        if (this.IsCalm) mySpeed = speedCalm;
        else mySpeed = speedAlert;

        rb.MovePosition(transform.position + movementDirection * Time.deltaTime * mySpeed);
    }



    ///CLONE SCRIPTABLE COW
    private void CloneFromTemplate()
    {
        /// SIMPLE DATA
        this.uid = cowTemplate.UID;
        this.rarity = cowTemplate.rarity;
        this.cowName = cowTemplate.Name;
        this.fuelRecoveryAmount = cowTemplate.FuelRecoveryAmount;
        this.alertRadius = cowTemplate.AlertRadius;
        this.speedCalm = cowTemplate.SpeedCalm;
        this.speedAlert = cowTemplate.SpeedAlert;
        this.score = cowTemplate.Score;

        ///TIMERS
        this.TimerCalmMovement = cowTemplate.TimerCalmMovement;
        this.TimerCalmStill = cowTemplate.TimerCalmStill;
        this.TimerAlertToCalm = cowTemplate.TimerAlertToCalm;
        this.TimerAlertToPanic = cowTemplate.TimerAlertToPanic;

        /// COMPLEX DATA
        this.favouriteHideoutTypes = cowTemplate.FavouriteHideoutTypes;
        this.allowedSpawnPointTypes = cowTemplate.AllowedSpawnPointTypes;
        this.alteration = cowTemplate.Alteration;
        this.movPatternCalm = cowTemplate.movPatternCalm;
        this.movPatternAlert = (AbstractMovementAlert) cowTemplate.movPatternAlert;
    }


    private void HandleAlertMovement()
    {
        if (movPatternAlert != null) movementDirection = movPatternAlert.ManageMovement(this);
        else movementDirection = Vector3.zero;
        //Debug.Log("movementDirection (ALERT): " + movementDirection);
    }

    private void HandlePanicMovement()
    {
        if (movPatternAlert != null) movementDirection = movPatternAlert.ManagePanic(this);
        else movementDirection = Vector3.zero;
        //Debug.Log("movementDirection (PANIC): " + movementDirection);
    }



    //PUBLIC FUNCTIONALITIES
    public void ResetTimerSpecialMovement()
    {
        this.timerAlertSpecialMovement = cowTemplate.movPatternAlert.TimerAlertSpecialMovement;
    }

    private void ZeroTimerSpecialMovement()
    {
        this.timerAlertSpecialMovement = 0.0f;
    }




}
