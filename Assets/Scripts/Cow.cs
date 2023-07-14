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
    ///UNIQUE ID & ENUMS
    private ScriptableCow.UniqueID UID;
    private ScriptableCow.Rarity rarity;


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
    private float TimerAlertToCalm;
    private float TimerAlertToPanic;
    private float TimerCalmMovement;
    private float TimerCalmStill;



    /// COMPLEX DATA
    private List<ScriptableHideout.Type> FavouriteHideoutTypes = new();//TODO: MUST BE NULL-SAFE
    private List<SpawnPoint.Type> AllowedSpawnPointTypes = new();


    private AbstractAlteration.EBuffType alteration;
    public AbstractAlteration.EBuffType Alteration { get { return alteration; } }


    //TODO: EVALUATE FURTHER DIVERSIFICATION OF MOVEMENT PATTERNS
    private AbstractMovementPattern movPatternCalm;
    private AbstractMovementAlert movPatternAlert;


    //TECHNICAL DATA FOR OTHER PURPOSES
    private SpriteRenderer sr;
    private Rigidbody rb;

    private Vector3 movementDirection = Vector3.forward;





    //METHODS
    //...
    private void Awake()
    {
        if(cowTemplate != null) CloneFromTemplate();
        else Debug.LogWarning("COW WITHOUT TEMPLATE (SCRIPTABLE COW) " + this.gameObject.name);

        //OTHER TECHNICAL AWAKE SETUP
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        sr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        sr.receiveShadows = true;

        rb = this.gameObject.GetComponent<Rigidbody>();

    }

    private void Start()
    {
        
    }


    private void FixedUpdate()
    {
        float mySpeed;
        if (this.IsCalm) mySpeed = speedCalm;
        else mySpeed = speedAlert;

        rb.MovePosition(transform.position + movementDirection * Time.deltaTime * mySpeed);
    }

    private void Update()
    {
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
            this.TimerAlertToPanic -= Time.deltaTime;

            //ALERT SUB-STATE
            if (this.TimerAlertToPanic > 0.0f) HandleAlertMovement();
            //PANIC SUB-STATE
            else
            {
                this.targetHideout = CowHelper.FindHideout(this);

                //REMAIN IN ALERT-SUBSTATE BEHAVIOUR
                if (!HasChosenHideout) HandleAlertMovement();
                else if (!targetHideout.IsFull()) HandlePanicMovement();

                if (CowHelper.CanEnterHideout(this))
                {
                    //NOTIFY THE HIDEOUT THAT THE COW WANTS TO ENTER INSIDE
                    //NB: SYNCHRONIZATION ISSUES!!!

                    //IF COW HAS ENTERED HIDEOUT, TRANSITION TO HIDDEN STATE
                    //IF COW HAS ENTERED HIDEOUT, DISABLE COW

                }

            }
        }
        else
        {
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
                //TODO: CAN USE TERNARY OPERATORS?
                TimerCalmMovement = cowTemplate.TimerCalmMovement;
                TimerCalmStill = cowTemplate.TimerCalmStill;

                //RESETTING THE MOVEMENT DIRECTION RANDOMLY BASED ON CALM PATTERN
                movementDirection = movPatternCalm.ManageMovement(this.transform.position);
                Debug.Log("movementDirection: " + movementDirection);
            }
        }


    }


    //ENABLEMENT/DISABLEMENT
    private void OnEnable()
    {
        this.movementDirection = Vector3.zero;
        this.currentState = State.Calm;
    }

    private void OnDisable()
    {

    }




    //FUNCTIONALITIES



    ///CLONE SCRIPTABLE COW
    private void CloneFromTemplate()
    {
        /// SIMPLE DATA
        this.UID = cowTemplate.UID;
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
        this.FavouriteHideoutTypes = cowTemplate.FavouriteHideoutTypes;
        this.AllowedSpawnPointTypes = cowTemplate.AllowedSpawnPointTypes;
        this.alteration = cowTemplate.Alteration;
        this.movPatternCalm = cowTemplate.movPatternCalm;
        this.movPatternAlert = (AbstractMovementAlert) cowTemplate.movPatternAlert;
    }


    private void HandleAlertMovement()
    {
        if (movPatternAlert != null) movementDirection = movPatternAlert.ManageMovement(this.transform.position);
        else movementDirection = Vector3.zero;
        Debug.Log("movementDirection (ALERT): " + movementDirection);
    }

    private void HandlePanicMovement()
    {
        if (movPatternAlert != null) movementDirection = movPatternAlert.ManagePanic(this);
        else movementDirection = Vector3.zero;
        Debug.Log("movementDirection (PANIC): " + movementDirection);
    }

}
