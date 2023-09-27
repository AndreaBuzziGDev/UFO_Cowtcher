using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerHelper
{
    //USE ALL AND ONLY STATIC CODE HERE

    
    //TALLY CHANCE SYSTEM
    ///GET THE TALLY
    public static int GetTally(Dictionary<CowSO.UniqueID, int> tallySpawnChances)
    {
        int result = 0;
        foreach (KeyValuePair<CowSO.UniqueID, int> entry in tallySpawnChances)
        {
            result += entry.Value;
        }
        Debug.Log("SpawnManagerHelper - Chance tally is " + result);


        return result;
    }

    ///GET THE COW CORRESPONDING TO THE GIVEN INTEGER
    public static CowSO.UniqueID GetCorrespondingCowFromTally(Dictionary<CowSO.UniqueID, int> tallySpawnChances, int randomChance)
    {
        CowSO.UniqueID choice = CowSO.UniqueID.ANY;
        int totalTally = 1;

        foreach (KeyValuePair<CowSO.UniqueID, int> entry in tallySpawnChances)
        {
            if (randomChance > totalTally)
            {
                totalTally += entry.Value;
            }
            else
            {
                choice = entry.Key;
                Debug.Log("SpawnManagerHelper - Found matching cow UID " + entry.Key + " for randomChance: " + randomChance + " from Tally-Based System");

                break;
            }
        }

        if (choice == CowSO.UniqueID.ANY)
        {
            Debug.LogError("SpawnManagerHelper - ERROR! No matching cow for randomChance: " + randomChance + " from Tally-Based System");
        }

        return choice;
    }




}
