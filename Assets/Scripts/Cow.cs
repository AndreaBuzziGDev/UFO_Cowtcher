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
    private float Score;

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
    private AbstractMovementPattern movPatternAlert;


    //TECHNICAL DATA FOR OTHER PURPOSES
    private SpriteRenderer sr;





    //METHODS
    //...
    private void Awake()
    {
        /// SIMPLE DATA
        //TODO: CLONE DATA FROM SCRIPTABLE COW
        this.UID = cowTemplate.UID;
        this.rarity = cowTemplate.rarity;
        this.cowName = cowTemplate.Name;
        this.fuelRecoveryAmount = cowTemplate.FuelRecoveryAmount;
        this.AlertRadius = cowTemplate.AlertRadius;
        this.SpeedCalm = cowTemplate.SpeedCalm;
        this.SpeedAlert = cowTemplate.SpeedAlert;
        this.Score = cowTemplate.Score;
        this.TimerAlertToCalm = cowTemplate.TimerAlertToCalm;
        this.TimerAlertToPanic = cowTemplate.TimerAlertToPanic;
        this.TimerCalmMovement = cowTemplate.TimerCalmMovement;
        this.TimerCalmStill = cowTemplate.TimerCalmStill;

        /// COMPLEX DATA
        this.FavouriteHideoutTypes = cowTemplate.FavouriteHideoutTypes;
        this.AllowedSpawnPointTypes = cowTemplate.AllowedSpawnPointTypes;
        this.alteration = cowTemplate.Alteration;
        this.movPatternCalm = cowTemplate.movPatternCalm;
        this.movPatternAlert = cowTemplate.movPatternAlert;
        

        //OTHER TECHNICAL AWAKE SETUP
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        sr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        sr.receiveShadows = true;

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }


    //FUNCTIONALITIES


}
