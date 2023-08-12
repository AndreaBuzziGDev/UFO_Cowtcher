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

    public enum MovementState
    {
        Calm,
        Alert,
        Panic,
        Terror
    }



    //DATA

    ///INNATE COW DATA
    private State currentState = State.Calm;
    public State CurrentState { get { return currentState; } }
    public bool IsCalm { get { return (currentState == State.Calm); } }
    public bool IsAlert { get { return (currentState == State.Alert); } }


    ///MOVEMENT STATE
    private MovementState movState = MovementState.Calm;
    public MovementState MovState { get { return movState; } }




    ///COW BEHAVIOURAL DATA
    [SerializeField] private CowSO cowTemplate;
    public CowSO CowTemplate { get { return cowTemplate; } }

    private Hideout targetHideout;
    public Hideout TargetHideout { get { return targetHideout; } }
    public bool HasChosenHideout { get { return (targetHideout != null); } }



    ///CLONED DATA
    ///UNIQUE ID
    private CowSO.UniqueID uid;
    public CowSO.UniqueID UID { get { return uid; } }
    ///RARITY
    private CowSO.Rarity rarity;
    public CowSO.Rarity Rarity { get { return rarity; } }



    /// SIMPLE DATA
    private string cowName;
    public string CowName { get { return cowName; } }

    private int fuelRecoveryAmount;
    public int FuelRecoveryAmount { get { return fuelRecoveryAmount; } }

    private float alertRadius;
    public float AlertRadius { get { return alertRadius; } }//TODO: HAS TO BE MORPHED IN COW UNITS

    ///SPEED DATA
    private float speedCalm;
    private float speedAlert;
    private float speedBuffMultiplier;//EXPERIMENT TO SLOW DOWN COWS INDIVIDUALLY (NOT YET USED)


    private int score;
    public int Score { get { return score; } }

    ///TIMERS
    [Min(0f)] private float TimerAlertToCalm;
    [Min(0f)] private float TimerAlertToPanic;
    public bool IsPanicking { get { return (TimerAlertToPanic <= 0.0f); } }


    //JUICYNESS DATA
    [SerializeField] private float shakeAmount;
    [SerializeField] private float shakeSpeed;






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


    ///MOVEMENT DIRECTION (AFFECTED BY MOVEMENT PATTERNS)
    ///BIRTH POINT
    public Vector3 spawnCoords = Vector3.zero;
    public Vector3 SpawnCoords { get { return spawnCoords; } }



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

    }



    private void FixedUpdate()
    {
        //IsGlobalTerrify
        //TODO: THIS CAN BE REFACTORED AND IMPROVED
        if (CowManager.Instance.IsGlobalTerrify)
        {
            //MOVEMENT STATE IS BEING TERRIFIED
            movState = MovementState.Terror;
        }
        else
        {
            //COW AI
            CowAI();
        }
    }


    //ENABLEMENT/DISABLEMENT
    private void OnEnable()
    {
        this.currentState = State.Calm;
        this.movState = MovementState.Calm;

        //RESET TIMERS
        this.TimerAlertToCalm = 0.0f;
        this.TimerAlertToPanic = cowTemplate.TimerAlertToPanic;

        //SET BIRTH POINT
        spawnCoords = transform.position;

    }

    private void OnDisable()
    {

    }




    //COW AI
    private void CowAI()
    {

        //STEP 1
        if (CowHelper.IsUFOWithinRadius(this))
        {
            if (IsCalm) this.currentState = State.Alert;
            this.TimerAlertToCalm = cowTemplate.TimerAlertToCalm;
        }
        else
        {
            if (this.TimerAlertToCalm <= 0.0f) this.currentState = State.Calm;
            else this.TimerAlertToCalm -= Time.deltaTime;
        }

        //STEP 2
        if (IsAlert)
        {

            Mathf.Clamp(this.TimerAlertToPanic, 0, cowTemplate.TimerAlertToPanic);
            if (CowHelper.IsUFOWithinRadius(this) && this.TimerAlertToPanic > 0) this.TimerAlertToPanic -= Time.deltaTime;


            //ALERT SUB-STATE
            if (this.TimerAlertToPanic > 0.0f)
            {
                movState = MovementState.Alert;

            }
            else
            {
                //PANIC SUB-STATE
                this.targetHideout = CowHideoutHelper.FindHideout(this);

                //REMAIN IN ALERT-SUBSTATE BEHAVIOUR
                if (!HasChosenHideout) movState = MovementState.Alert;
                //DO PANIC MOVEMENT
                else if (targetHideout.HasAvailableSlots()) movState = MovementState.Panic;

                if (CowHideoutHelper.CanEnterHideout(this)) CowHideoutHelper.EnterHideout(this);

            }
        }
        else
        {
            //RESET PANIC TIMER
            this.TimerAlertToPanic = cowTemplate.TimerAlertToPanic;

            movState = MovementState.Calm;

        }

        //ENDED COW AI

    }





    //INITIALIZATION
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
        this.alteration = cowTemplate.InstantAlteration;
    }





    //FUNCTIONALITIES

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
