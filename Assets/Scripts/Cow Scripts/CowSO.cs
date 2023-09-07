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
        //UNUSED
        ANY,

        //FARM
        C000_BlackCow,
        C001_WhiteCow,

        R000_Kowbra,
        R001_PumpCow,
        R002_Cowttleman,
        R003_Scarecow,

        L000_Cowctor,
        L001_Cowgon,


        //BEACH
        C002_Cowcktail,
        C003_Cowst,

        R004_Hippocowmp,
        R005_Hermitcow,
        R006_Cowloon,
        R007_Sharkow,

        L002_Cowhtulhu,
        L003_Flying_Cowtchman,


        //MOUNTAIN
        C004_Skow,
        C005_Cowld,

        R008_Ice_Cowm,
        R009_Cowdolf,
        R010_Cownguin,
        R011_Cowflake,

        L004_Santa_Cows,
        L005_Cowalanche,


        //FANTASY
        C006_Cowvalier,
        C007_Abracowdabra,

        R012_Linkow,
        R013_Super_Cowrio,
        R014_Unicowrn,
        R015_Kowtos,

        L006_Cowre_Trainer,
        L007_Cowron
    }

    public enum Rarity
    {
        Common,
        Rare,
        Legendary
    }


    //DATA
    ///UNIQUE ID & ENUMS
    public UniqueID UID = UniqueID.C000_BlackCow;
    public Rarity rarity = Rarity.Common;



    /// SIMPLE DATA
    public string CowName;

    [TextAreaAttribute]
    public string Description;

    [Tooltip("the probability for this cow type to spawn randomly after being unlocked.")]
    [Range(0, 100f)] public float spawnProbability = 20.0f;

    [Tooltip("the chance tally for this cow type to spawn randomly after being unlocked.")]
    public int spawnChanceTally = 10;


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


    //EFFECTS
    ///
    public string effect;

    ///INSTANTLY-PROVIDED STATUS ALTERATION
    [Tooltip("Instantly-Provided Status Alteration (Intended for Malicious Cows)")]
    public ItemPickup InstantlyDeployedItemPickup;

    ///ENQUEUED ASTEROID
    [Tooltip("UNUSED!")]
    public Asteroid associatedAsteroid;


    ///SPAWN AND RESPAWN DATA
    public RitualAbstractSO SummoningRitual;//TODO: MUST BE NULL-SAFE
    public List<HideoutSO.Type> FavouriteHideoutTypes = new();
    public List<SpawnPoint.Type> AllowedSpawnPointTypes = new();


}
