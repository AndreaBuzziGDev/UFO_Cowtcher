using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RitualAbstract
{
    //DATA
    [SerializeField] protected List<ScriptableCow.UniqueID> requiredCows = new List<ScriptableCow.UniqueID>();
    public List<ScriptableCow.UniqueID> RequiredCows { get { return requiredCows; } }

    protected Dictionary<ScriptableCow.UniqueID, CowSummoningRitualModule> ritualDictionary = new();


    //METHODS
    public virtual bool HasCow(ScriptableCow.UniqueID UID)
    {
        //TODO: THIS SHOULD NOT ALLOW "UID" TO BE "ANY" IN INPUT.

        //IF RITUAL CONTAINS "ANY" COW --> DEFAULT TRUE
        if (requiredCows.Contains(ScriptableCow.UniqueID.ANY)) return true;
        return requiredCows.Contains(UID);
    }

    public void BuildRitualModules()
    {
        Dictionary<ScriptableCow.UniqueID, int> plottedRituals = new();
        foreach (ScriptableCow.UniqueID uid in requiredCows)
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

        //
        foreach (KeyValuePair<ScriptableCow.UniqueID, int> entry in plottedRituals)
        {
            CowSummoningRitualModule iteratedModule = new CowSummoningRitualModule(entry.Key, entry.Value);
            ritualDictionary.Add(entry.Key, iteratedModule);
        }
    }


    public abstract void DoRitual(ScriptableCow.UniqueID UID);


}
