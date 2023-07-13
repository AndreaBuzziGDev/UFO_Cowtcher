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
    private Hideout targetHideout;



    ///CLONED DATA
    ///UNIQUE ID & ENUMS
    private ScriptableCow.UniqueID UID;
    private ScriptableCow.Rarity rarity;


    /// SIMPLE DATA
    private string cowName;
    public string CowName { get { return cowName; } }

    private int fuelRecoveryAmount;
    public int FuelRecoveryAmount { get { return fuelRecoveryAmount; } }

    private float AlertRadius;
    private float SpeedCalm;
    private float SpeedAlert;

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
        if (this.IsCalm) mySpeed = SpeedCalm;
        else mySpeed = SpeedAlert;

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
            if (this.TimerAlertToPanic > 0.0f)
            {
                //use ALERT movement pattern to effectively determine how to move cow.
                //NB: THIS IS SPECIFICALLY THE "ALERT" MOVEMENT, DO NOT CONFUSE IT WITH PANIC (run for hideout) MOVEMENT.
                //Vector3 myNewDirection = AbstractMovementPattern.ManageMovement();

            }
            else
            {
                //NB: THIS HANDLES PANIC (run for hideout) BEHAVIOUR
                if (!CowHelper.HasChosenHideout(this))
                {
                    //HELPER - CHOSE HIDEOUT...
                    this.targetHideout = CowHelper.FindHideout(this);

                }
                else
                {
                    if (!targetHideout.HasAvailableSlots())
                    {
                        //use ALERT movement pattern to effectively determine how to move cow.
                        //NB: THIS IS SPECIFICALLY THE "PANIC" MOVEMENT, DO NOT CONFUSE IT WITH ALERT (escape from UFO) MOVEMENT.
                        //Vector3 myNewDirection = AbstractMovementPattern.ManageMovement();

                    }
                    else
                    {
                        Hideout newHideout = CowHelper.FindHideout(this);
                        if (newHideout != null) this.targetHideout = newHideout;
                        else this.targetHideout = null;//NB: THIS IS DIRTY. IMPLEMENT AS A CALL TO THE SAME CODE THAT ESSENTIALLY MOVES THE COW AS IF IT WERE IN ALERT STATE
                    }
                }

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
            //TODO: HANDLE CALM MOVEMENT PATTERN HERE
            //calm movement timer handling...

            //calm quiet timer handling...

            //use CALM movement pattern to effectively determine how to move cow.
            //Vector3 myNewDirection = AbstractMovementPattern.ManageMovement();


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
        this.AlertRadius = cowTemplate.AlertRadius;
        this.SpeedCalm = cowTemplate.SpeedCalm;
        this.SpeedAlert = cowTemplate.SpeedAlert;
        this.score = cowTemplate.Score;

        //TIMERS START AT 0. THE TEMPLATE IS USED TO "RESET" TIMERS WHEN NEEDED.
        /*
        this.TimerAlertToCalm = cowTemplate.TimerAlertToCalm;
        this.TimerAlertToPanic = cowTemplate.TimerAlertToPanic;
        this.TimerCalmMovement = cowTemplate.TimerCalmMovement;
        this.TimerCalmStill = cowTemplate.TimerCalmStill;
        */

        /// COMPLEX DATA
        this.FavouriteHideoutTypes = cowTemplate.FavouriteHideoutTypes;
        this.AllowedSpawnPointTypes = cowTemplate.AllowedSpawnPointTypes;
        this.alteration = cowTemplate.Alteration;
        this.movPatternCalm = cowTemplate.movPatternCalm;
        this.movPatternAlert = (AbstractMovementAlert) cowTemplate.movPatternAlert;
    }

}
