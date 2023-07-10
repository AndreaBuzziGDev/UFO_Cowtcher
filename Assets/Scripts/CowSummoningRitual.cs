using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSummoningRitual
{
    //DATA
    private Dictionary<ScriptableCow.UniqueID, RitualModule> ritualDictionary = new();

    private List<RitualModule> modules = new List<RitualModule>();//TODO: modules seems obsolete/useless since we have a dictionary with more functionalities.
    public List<RitualModule> Modules { get { return modules; } }
    

    //CONSTRUCTOR
    public CowSummoningRitual(IndexedCow baseCowInformation)
    {
        //TODO: USE baseCowInformation TO CREATE RitualModule(s)
        //1) IndexedCow -> Scriptable Cow
        ScriptableCow sc = baseCowInformation.ReferenceTemplate;

        //2) Scriptable Cow -> Scriptable Ritual
        ScriptableRitual sr = sc.SummoningRitual;

        //3) Ogni scriptable ritual -> N RitualModule DOVE: N è il numero di UniqueIDs di mucche diversi.
        Dictionary<ScriptableCow.UniqueID, int> plottedRituals = new();
        foreach(ScriptableCow.UniqueID uid in sr.RequiredCows)
        {
            if (plottedRituals.ContainsKey(uid))
            {
                plottedRituals[uid]++;
            }
            else
            {
                plottedRituals.Add(uid, 1);
            }
        }

        //TODO: CREA RITUALMODULE
        foreach (KeyValuePair<ScriptableCow.UniqueID, int> entry in plottedRituals)
        {
            RitualModule iteratedModule = new RitualModule(entry.Key, entry.Value);
            modules.Add(iteratedModule);
            ritualDictionary.Add(entry.Key, iteratedModule);
        }

    }


    //METHODS
    public void ChangeCapturedCowCount(ScriptableCow.UniqueID cowUID, int delta)
    {
        RitualModule rm = ritualDictionary[cowUID];
        rm.ChangeAmount(delta);
    }


    public bool IsReadyToSpawn()
    {
        //TODO: THIS MIGHT BE CLEANED UP
        if (ritualDictionary.Count > 0)
        {
            foreach (KeyValuePair<ScriptableCow.UniqueID, RitualModule> entry in ritualDictionary)
            {
                if (!entry.Value.IsReadyToSpawn)
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }

        return true;
    }

    public void HandleCowSpawn()
    {
        foreach (KeyValuePair<ScriptableCow.UniqueID, RitualModule> entry in ritualDictionary)
        {
            entry.Value.HandleCowSpawn();
        }
    }

}
