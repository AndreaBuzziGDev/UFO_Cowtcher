using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cow", menuName = "Cow")]
public class CowSO : ScriptableObject
{
    //ENUMS
    //NB: "ANY" RESERVED FOR APPLICATIONS THAT DO NOT NEED SPECIFYING A COW (LIKE NON-SPECIFIC RITUALS)
    public enum UniqueID
    {
        ANY,
        C000Jamal,
        C001Kevin,
        C002,
        C003,
        C004,
        C005,
        C006,
        C007,
        C008,

        R000Kowbra,
        R001PumpCow,
        R002Cowttleman,
        R003Scarecow,

        L000Cowctor,
        L001Cowgon,
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
    public UniqueID UID = UniqueID.C000Jamal;
    public Rarity rarity = Rarity.Common;



    /// SIMPLE DATA
    public string Name;
    public string Description;

    [Tooltip("the probability for this cow type to spawn randomly after being unlocked.")]
    [Range(0, 100f)] public float spawnProbability = 20.0f;

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
    [Tooltip("Time before the cow will respawn after being caught")]
    public float TimerRespawn = 5.0f;


    ///MOVEMENT PATTERNS
    public MPAbstractCalmSO movPatternCalm;
    public MPAbstractAlertSO movPatternAlert;

    ///STATUS ALTERATION
    public ItemPickup InstantlyDeployedItemPickup;


    ///SPAWN AND RESPAWN DATA
    public RitualAbstractSO SummoningRitual;//TODO: MUST BE NULL-SAFE
    public List<HideoutSO.Type> FavouriteHideoutTypes = new();
    public List<SpawnPoint.Type> AllowedSpawnPointTypes = new();


}
