using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: DELETE - THIS CLASS HAS BEEN DEPRECATED AND CAN BE ELIMINATED. CHECK REFERENCES FIRST TO ENSURE NO COMPILE ERRORS ENSUE WHEN DELETED
public class CowSummoningRitual
{
    //TODO: DEVELOP UNIT TESTS


    //TODO: HANDLE MANAGEMENT FOR SPECIAL BEHAVIOURS IN RITUALS (iRitualBehaviour)
    //NB: AN ALTERNATE IMPLEMENTATION OF SUMMONING RITUALS CAN BE ACHIEVED BY MAKING THIS CLASS ABSTRACT AND HANDLING THE CONCRETE DETAILS IN A CHILD CLASS

    //TODO: HANDLE TYPE "ANY" CORRECTLY



    //DATA
    private Dictionary<ScriptableCow.UniqueID, CowSummoningRitualModule> ritualDictionary = new();


    private RitualAbstract behaviour;
    public RitualAbstract Behaviour { get { return behaviour; } }

    

    //CONSTRUCTOR
    public CowSummoningRitual(IndexedCow baseCowInformation)
    {
        //TODO: USE baseCowInformation TO CREATE RitualModule(s)
        //1) IndexedCow -> Scriptable Cow
        ScriptableCow sc = baseCowInformation.ReferenceTemplate;

        //2) Scriptable Cow -> Scriptable Ritual
        RitualAbstractSO sr = sc.SummoningRitual;

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

        //
        foreach (KeyValuePair<ScriptableCow.UniqueID, int> entry in plottedRituals)
        {
            CowSummoningRitualModule iteratedModule = new CowSummoningRitualModule(entry.Key, entry.Value);
            ritualDictionary.Add(entry.Key, iteratedModule);
        }

        //
        //behaviour = mapBehaviour(sr.Type);
    }


    //TODO: DISCARD - USED ANOTHER DESIGN PATTERN
    //RITUAL TYPE MAPPING
    /*
    private RitualAbstract mapBehaviour(RitualAbstractSO.ERitualType type)
    {
        switch (type)
        {
            case RitualAbstractSO.ERitualType.SequentialCapture:
                return new RitualSequentialCapture();
            case RitualAbstractSO.ERitualType.ItemProximity:
                return new RitualProximity();
            case RitualAbstractSO.ERitualType.ScoreThreshold:
                return new RitualScoreThreshold();
            default:
                //HAS SimpleCapture EMBEDDED
                return null;
        }

    }
    */



    //METHODS
    //TODO: DEVELOP A METHOD THAT CALLS THE iRitualBehaviour LOGIC AND THE REST OF THE PROCEDURES




    public bool HasCow(ScriptableCow.UniqueID searchedID) => ritualDictionary.ContainsKey(searchedID);//TODO: HANDLE TYPE "ANY" CORRECTLY

    public void ChangeCapturedCowCount(ScriptableCow.UniqueID cowUID, int delta)
    {
        CowSummoningRitualModule rm = ritualDictionary[cowUID];
        rm.ChangeAmount(delta);
    }

    public bool IsReadyToSpawn()
    {
        //TODO: THIS MIGHT BE CLEANED UP
        if (ritualDictionary.Count > 0)
        {
            foreach (KeyValuePair<ScriptableCow.UniqueID, CowSummoningRitualModule> entry in ritualDictionary)
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
        foreach (KeyValuePair<ScriptableCow.UniqueID, CowSummoningRitualModule> entry in ritualDictionary)
        {
            entry.Value.HandleCowSpawn();
        }
    }



}
