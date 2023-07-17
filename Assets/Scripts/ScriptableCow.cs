using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cow", menuName = "Cow")]
public class ScriptableCow : ScriptableObject
{
    //ENUMS
    //NB: "ANY" RESERVED FOR APPLICATIONS THAT DO NOT NEED SPECIFYING A COW (LIKE NON-SPECIFIC RITUALS)
    public enum UniqueID
    {
        ANY,
        C000,
        C001,
        C002,
        C003,
        C004,
        C005,
        C006,
        C007,
        C008,

        R000,
        R001,
        R002,
        R003,

        L000,
        L001,
        L002,
        L003
    }

    public enum Rarity
    {
        Common,
        Rare,
        Legendary
    }



    //DATA
    ///UNIQUE ID & ENUMS
    public UniqueID UID = UniqueID.C001;
    public Rarity rarity = Rarity.Common;



    /// SIMPLE DATA
    public string Name;
    public string Description;

    public int FuelRecoveryAmount;
    public float AlertRadius;
    public float SpeedCalm;
    public float SpeedAlert;
    public int Score;

    //TIMERS
    [Tooltip("Time the cow will spend in alert state while not being chased by the UFO anymore")]
    public float TimerAlertToCalm = 1.0f;
    [Tooltip("Time the cow will spend in alert state before transitioning to Panic (search Hideout)")]
    public float TimerAlertToPanic = 1.0f;

    [Tooltip("Time the cow will spend moving randomly while being in the calm state")]
    public float TimerCalmMovement = 1.0f;
    [Tooltip("Time the cow will spend moving standing still while being in the calm state")]
    public float TimerCalmStill = 1.0f;


    [Tooltip("Time before the cow will respawn after being caught")]
    public float TimerRespawn = 5.0f;


    ///COMPLEX DATA
    public ScriptableRitual SummoningRitual;//TODO: MUST BE NULL-SAFE
    public List<ScriptableHideout.Type> FavouriteHideoutTypes = new();
    public List<SpawnPoint.Type> AllowedSpawnPointTypes = new();

    //TODO: SWITCH TO ENUM VARIABLE
    public AbstractAlteration.EBuffType Alteration;

    //TODO: EVALUATE FURTHER DIVERSIFICATION OF MOVEMENT PATTERNS
    public AbstractMovementPattern movPatternCalm;
    public AbstractMovementAlert movPatternAlert;

}
