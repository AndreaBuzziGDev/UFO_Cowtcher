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

    private ScriptableCow cowTemplate;
    private Hideout targetHideout;

    ///TIMERS
    //TODO: IMPLEMENT




    ///CLONED DATA
    ///UNIQUE ID & ENUMS
    private ScriptableCow.UniqueID UID;
    private ScriptableCow.Rarity rarity;



    /// SIMPLE DATA
    private int fuelRecoveryAmount;
    public int FuelRecoveryAmount { get { return fuelRecoveryAmount; } }

    private float AlertRadius;
    private float Speed;



    /// COMPLEX DATA
    private List<ScriptableHideout.Type> FavouriteHideoutTypes = new List<ScriptableHideout.Type>();
    private List<SpawnPoint.Type> AllowedSpawnPointTypes = new List<SpawnPoint.Type>();


    private AbstractStatusAlteration statusAlteration;
    public AbstractStatusAlteration Alteration { get { return statusAlteration; } }


    //TODO: EVALUATE FURTHER DIVERSIFICATION OF MOVEMENT PATTERNS
    private AbstractMovementPattern movPatternCalm;
    private AbstractMovementPattern movPatternAlert;



    //METHODS
    //...
    private void Awake()
    {
        //TODO: CLONE DATA FROM SCRIPTABLE COW

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }


    //FUNCTIONALITIES


}
