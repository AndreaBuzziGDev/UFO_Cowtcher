using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cow", menuName = "Cow")]
public class ScriptableCow : ScriptableObject
{
    //ENUMS
    public enum UniqueID
    {
        C001,
        C002,
        C003,
        C004,
        C005,
        C006,
        C007,
        C008
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
    public int FuelRecoveryAmount;
    public float AlertRadius;
    public float Speed;
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


    ///COMPLEX DATA
    public ScriptableRitual SummoningRitual;
    public List<ScriptableHideout.Type> FavouriteHideoutTypes = new();
    public List<SpawnPoint.Type> AllowedSpawnPointTypes = new();


    public AbstractStatusAlteration statusAlteration;

    //TODO: EVALUATE FURTHER DIVERSIFICATION OF MOVEMENT PATTERNS
    public AbstractMovementPattern movPatternCalm;
    public AbstractMovementPattern movPatternAlert;

}
