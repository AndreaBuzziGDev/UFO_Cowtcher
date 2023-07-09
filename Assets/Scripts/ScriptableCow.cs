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

    //TODO: TIMERS FROM GDD


    ///COMPLEX DATA
    public ScriptableRitual SummoningRitual;
    
    //TODO: EVALUATE ADOPT SET AS COLLECTION TYPE
    public List<ScriptableHideout.Type> FavouriteHideoutTypes = new List<ScriptableHideout.Type>();
    public List<SpawnPoint.Type> AllowedSpawnPointTypes = new List<SpawnPoint.Type>();


    public AbstractStatusAlteration statusAlteration;

    //TODO: EVALUATE FURTHER DIVERSIFICATION OF MOVEMENT PATTERNS
    public AbstractMovementPattern movPatternCalm;
    public AbstractMovementPattern movPatternAlert;

}
