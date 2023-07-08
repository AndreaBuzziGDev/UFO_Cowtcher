using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cow", menuName = "Cow")]
public class ScriptableCow : ScriptableObject
{
    public enum Rarity
    {
        Common,
        Rare,
        Legendary
    }
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

    public int FuelRecoveryAmount;
    //public List<Hideout.Type> FavouriteHideoutTypes = new List<Hideout.Type>();
    public float AlertRadius;
    //public List<SpawnPoint.SpawnPointType> AllowedSpawnPointTypes = new List<SpawnPoint.SpawnPointType>();
    public float Speed;
    //public ScriptableRitual SummoningRitual;

    //private PlayerStatusAlteration statusAlteration;
    //private MovementPattern movPatternCalm;
    //private MovementPattern movPatternAlert;
    
}
