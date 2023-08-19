using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerHelper
{
    //USE ALL AND ONLY STATIC CODE HERE

    
    //TALLY CHANCE SYSTEM
    public int GetTally(Dictionary<CowSO.UniqueID, int> tallySpawnChances)
    {
        int result = 0;
        foreach (KeyValuePair<CowSO.UniqueID, int> entry in tallySpawnChances)
        {
            result += entry.Value;
        }

        return result;
    }



}
