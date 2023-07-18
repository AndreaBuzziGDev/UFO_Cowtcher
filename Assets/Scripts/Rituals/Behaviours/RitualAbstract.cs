using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RitualAbstract
{
    //DATA
    
    protected ScriptableCow.UniqueID targetSpawnedCow;
    public ScriptableCow.UniqueID TargetSpawnedCow { get { return targetSpawnedCow; } }


    protected List<ScriptableCow.UniqueID> requiredCows = new List<ScriptableCow.UniqueID>();
    public List<ScriptableCow.UniqueID> RequiredCows { get { return requiredCows; } }

    protected Dictionary<ScriptableCow.UniqueID, CowSummoningRitualModule> ritualDictionary = new();


    //METHODS
    //TODO: EVENTUALLY CAN BE DRASTICALLY SIMPLIFIED BY USING A BASE CONSTRUCTOR FOR THIS ABSTRACT CLASS, TO BE CALLED IN CHILD CLASSES.

    protected void BuildRitualModules(List<ScriptableCow.UniqueID> buildRequiredCows)
    {
        Dictionary<ScriptableCow.UniqueID, int> plottedRituals = new();
        foreach (ScriptableCow.UniqueID uid in buildRequiredCows)
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

    public virtual bool HasCow(ScriptableCow.UniqueID UID)
    {
        //TODO: THIS SHOULD NOT ALLOW "UID" TO BE "ANY" IN INPUT.

        //IF RITUAL CONTAINS "ANY" COW --> DEFAULT TRUE
        if (requiredCows.Contains(ScriptableCow.UniqueID.ANY)) return true;
        return requiredCows.Contains(UID);
    }


    public virtual bool IsReadyToSpawn()
    {
        if (ritualDictionary.Count > 0)
        {
            foreach (KeyValuePair<ScriptableCow.UniqueID, CowSummoningRitualModule> entry in ritualDictionary)
            {
                Debug.Log("Cow Module: " + entry.Key + " Ready to Spawn: " + entry.Value.IsReadyToSpawn);
                if (!entry.Value.IsReadyToSpawn) return false;
            }

            return true;
        }

        return true;
    }

    public void HandleCowSpawn()
    {
        foreach (KeyValuePair<ScriptableCow.UniqueID, CowSummoningRitualModule> entry in ritualDictionary)
        {
            entry.Value.HandleCowSpawn();
        }
    }


    //ABSTRACT METHODS
    public abstract void DoRitual(ScriptableCow.UniqueID UID);



    //INTERNAL UTILITIES
    //THIS MUST NOT BE DIRECTLY ACCESSIBLE FROM THE OUTSIDE
    protected virtual void ChangeCapturedCowAmount(ScriptableCow.UniqueID cowUID, int delta)
    {
        if (cowUID == ScriptableCow.UniqueID.ANY)
        {
            Debug.Log("RitualAbstract - Changing counter by " + delta + " for Cow: " + ScriptableCow.UniqueID.ANY);
            ritualDictionary[ScriptableCow.UniqueID.ANY].ChangeAmount(delta);
        }
        else
        {
            Debug.Log("RitualAbstract - Changing counter by " + delta + " for Cow: " + cowUID);
            ritualDictionary[cowUID].ChangeAmount(delta);

            //ALSO INCREASE "ANY" COW COUNTER
            if (HasCow(ScriptableCow.UniqueID.ANY))
            {
                Debug.Log("RitualAbstract - Changing counter by " + delta + " for Cow: " + ScriptableCow.UniqueID.ANY);
                ritualDictionary[ScriptableCow.UniqueID.ANY].ChangeAmount(delta);
            }
        }
    }


}
