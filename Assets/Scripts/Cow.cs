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
        Hidden
    }


    //DATA

    ///INNATE COW DATA
    private State currentState = State.Calm;
    public State CurrentState { get { return currentState; } }
    public bool IsCalm { get { return (currentState == State.Calm); } }
    public bool IsAlert { get { return (currentState == State.Alert); } }



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
    public bool IsPanicking { get { return (TimerAlertToPanic <= 0.0f); } }




    ///COMPLEX DATA

    ///HIDEOUT
    private List<HideoutSO.Type> favouriteHideoutTypes = new();
    public List<HideoutSO.Type> FavouriteHideoutTypes { get { return favouriteHideoutTypes; } }

    private List<SpawnPoint.Type> allowedSpawnPointTypes = new();
    public List<SpawnPoint.Type> AllowedSpawnPointTypes { get { return allowedSpawnPointTypes; } }


    ///BUFFS
    private SAAbstractSO alteration;
    public SAAbstract Alteration { 
        get {
            if (alteration != null)
            {
                return alteration.GetBuff();
            }
            return null; 
        } 
    }


    ///MOVEMENT PATTERNS
    private AbstractMovementPattern movPatternCalm;
    private AbstractMovementAlert movPatternAlert;

    ///MOVEMENT DIRECTION (AFFECTED BY MOVEMENT PATTERNS)
    private Vector3 movementDirection = Vector3.forward;
    public Vector3 MovementDirection { get { return movementDirection; } }



    //TECHNICAL DATA FOR OTHER PURPOSES
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private ParticleSystem HasFledParticles;





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
        //COW AI

        //STEP 1
        if (CowHideoutHelper.IsUFOWithinRadius(this))
        {
            if (IsCalm) this.currentState = State.Alert;
            this.TimerAlertToCalm = cowTemplate.TimerAlertToCalm;
        }
        else
        {
            if (this.TimerAlertToCalm <= 0.0f) this.currentState = State.Calm;
            else this.TimerAlertToCalm -= Time.deltaTime;
        }
        /*
        Debug.Log("IsAlert: " + IsAlert);
        Debug.Log("TimerAlertToCalm: " + TimerAlertToCalm);
        Debug.Log("TimerAlertToPanic: " + TimerAlertToPanic);
        */

        //STEP 2
        if (IsAlert)
        {

            Mathf.Clamp(this.TimerAlertToPanic, 0, cowTemplate.TimerAlertToPanic);
            if (CowHideoutHelper.IsUFOWithinRadius(this) && this.TimerAlertToPanic > 0) this.TimerAlertToPanic -= Time.deltaTime;


            //ALERT SUB-STATE
            if (this.TimerAlertToPanic > 0.0f)
            {
                HandleAlertMovement();
            }
            else
            {
                //PANIC SUB-STATE
                this.targetHideout = CowHideoutHelper.FindHideout(this);

                //REMAIN IN ALERT-SUBSTATE BEHAVIOUR
                if (!HasChosenHideout) HandleAlertMovement();
                else if (targetHideout.HasAvailableSlots()) HandlePanicMovement();

                if (CowHideoutHelper.CanEnterHideout(this)) CowHideoutHelper.EnterHideout(this);

            }
        }
        else
        {
            //RESET PANIC TIMER
            this.TimerAlertToPanic = cowTemplate.TimerAlertToPanic;

            HandleCalmMovement();


            //UPDATING THE MOVEMENT DIRECTION BASED ON CALM PATTERN
            movementDirection = movPatternCalm.ManageMovement(this);

        }

        //ENDED COW AI

        //MOVEMENT
        HandleMovement();
    }


    //ENABLEMENT/DISABLEMENT
    private void OnEnable()
    {
        this.movementDirection = Vector3.zero;
        this.currentState = State.Calm;

        //RESET TIMERS
        this.TimerAlertToCalm = 0.0f;
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

        rb.velocity = mySpeed * movementDirection;

        //rb.MovePosition(transform.position + mySpeed * Time.deltaTime * movementDirection);
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
        this.TimerAlertToCalm = cowTemplate.TimerAlertToCalm;
        this.TimerAlertToPanic = cowTemplate.TimerAlertToPanic;

        /// COMPLEX DATA
        this.favouriteHideoutTypes = cowTemplate.FavouriteHideoutTypes;
        this.allowedSpawnPointTypes = cowTemplate.AllowedSpawnPointTypes;
        this.alteration = cowTemplate.Alteration;
        this.movPatternCalm = cowTemplate.movPatternCalm.GetMovPattern();
        this.movPatternAlert = (AbstractMovementAlert) cowTemplate.movPatternAlert.GetMovPattern();
    }




    //MOVEMENT PATTERNS
    ///CALM
    private void HandleCalmMovement()
    {
        if (movPatternCalm != null)
        {
            movementDirection = movPatternCalm.ManageMovement(this);
            movPatternCalm.UpdateTimers(Time.deltaTime);
        }
        else movementDirection = Vector3.zero;

    }

    ///ALERT
    private void HandleAlertMovement()
    {
        if (movPatternAlert != null)
        {
            movementDirection = movPatternAlert.ManageMovement(this);
            movPatternAlert.UpdateTimers(Time.deltaTime);
        }
        else movementDirection = Vector3.zero;
    }

    ///PANIC
    private void HandlePanicMovement()
    {
        if (movPatternAlert != null) 
        {
            movementDirection = movPatternAlert.ManagePanic(this);
            movPatternAlert.UpdateTimers(Time.deltaTime);
        }
        else movementDirection = Vector3.zero;
        //Debug.Log("movementDirection (PANIC): " + movementDirection);
    }



    //MAP FLEEING
    public void Flee()
    {
        //PARTICLE EMISSION
        ParticleSystem fleeParticlesInstance = Instantiate(HasFledParticles, spriteRenderer.transform.position, Quaternion.identity);
        fleeParticlesInstance.Play();
        Destroy(fleeParticlesInstance.gameObject, 3.0f);

        //DESTROY COW (FLED)
        Destroy(this.gameObject);

    }


}
