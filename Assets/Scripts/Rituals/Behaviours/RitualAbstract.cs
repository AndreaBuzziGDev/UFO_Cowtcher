using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RitualAbstract
{
    //DATA
    
    protected CowSO.UniqueID targetSpawnedCow;
    public CowSO.UniqueID TargetSpawnedCow { get { return targetSpawnedCow; } }


    protected List<CowSO.UniqueID> requiredCows = new List<CowSO.UniqueID>();
    public List<CowSO.UniqueID> RequiredCows { get { return requiredCows; } }

    protected Dictionary<CowSO.UniqueID, CowSummoningRitualModule> ritualDictionary = new();


    //METHODS
    //TODO: EVENTUALLY CAN BE DRASTICALLY SIMPLIFIED BY USING A BASE CONSTRUCTOR FOR THIS ABSTRACT CLASS, TO BE CALLED IN CHILD CLASSES.

    protected void BuildRitualModules(List<CowSO.UniqueID> buildRequiredCows)
    {
        Dictionary<CowSO.UniqueID, int> plottedRituals = new();
        foreach (CowSO.UniqueID uid in buildRequiredCows)
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
        foreach (KeyValuePair<CowSO.UniqueID, int> entry in plottedRituals)
        {
            CowSummoningRitualModule iteratedModule = new CowSummoningRitualModule(entry.Key, entry.Value);
            ritualDictionary.Add(entry.Key, iteratedModule);
        }
    }

    public virtual bool HasCow(CowSO.UniqueID UID)
    {
        //TODO: THIS SHOULD NOT ALLOW "UID" TO BE "ANY" IN INPUT.

        //IF RITUAL CONTAINS "ANY" COW --> DEFAULT TRUE
        if (requiredCows.Contains(CowSO.UniqueID.ANY)) return true;
        return requiredCows.Contains(UID);
    }

    public virtual bool StrictlyHasCow(CowSO.UniqueID UID)
    {
        return requiredCows.Contains(UID);
    }


    public virtual bool IsReadyToSpawn()
    {
        if (ritualDictionary.Count > 0)
        {
            foreach (KeyValuePair<CowSO.UniqueID, CowSummoningRitualModule> entry in ritualDictionary)
            {
                if (!entry.Value.IsReadyToSpawn) return false;
            }

            return true;
        }

        return true;
    }

    public void HandleCowSpawn()
    {
        foreach (KeyValuePair<CowSO.UniqueID, CowSummoningRitualModule> entry in ritualDictionary)
        {
            entry.Value.HandleCowSpawn();
            UIController.Instance.IGPanel.RitualPanel.fadeToTransparent = true;
        }
    }


    //ABSTRACT METHODS
    public abstract void DoRitual(CowSO.UniqueID UID);



    //INTERNAL UTILITIES
    //THIS MUST NOT BE DIRECTLY ACCESSIBLE FROM THE OUTSIDE
    protected virtual void ChangeCapturedCowAmount(CowSO.UniqueID cowUID, int delta)
    {
        if (cowUID == CowSO.UniqueID.ANY)
        {
            Debug.Log("RitualAbstract - Changing counter by " + delta + " for Cow: " + CowSO.UniqueID.ANY);
            ritualDictionary[CowSO.UniqueID.ANY].ChangeAmount(delta);
        }
        else
        {
            if (StrictlyHasCow(cowUID))
            {
                Debug.Log("RitualAbstract - Changing counter by " + delta + " for Cow: " + cowUID);
                ritualDictionary[cowUID].ChangeAmount(delta);
            }

            //ALSO INCREASE "ANY" COW COUNTER
            if (HasCow(CowSO.UniqueID.ANY))
            {
                Debug.Log("RitualAbstract - Changing counter by " + delta + " for Cow: " + CowSO.UniqueID.ANY);
                ritualDictionary[CowSO.UniqueID.ANY].ChangeAmount(delta);
            }
        }
    }


}
