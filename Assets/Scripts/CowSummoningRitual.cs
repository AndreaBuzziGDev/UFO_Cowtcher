using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSummoningRitual
{
    //TODO: DEVELOP UNIT TESTS


    //TODO: HANDLE MANAGEMENT FOR SPECIAL BEHAVIOURS IN RITUALS (iRitualBehaviour)
    //NB: AN ALTERNATE IMPLEMENTATION OF SUMMONING RITUALS CAN BE ACHIEVED BY MAKING THIS CLASS ABSTRACT AND HANDLING THE CONCRETE DETAILS IN A CHILD CLASS

    //TODO: HANDLE TYPE "ANY" CORRECTLY



    //DATA
    private Dictionary<ScriptableCow.UniqueID, RitualModule> ritualDictionary = new();


    private iRitualBehaviour behaviour;
    public iRitualBehaviour Behaviour { get { return behaviour; } }

    

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

        //
        foreach (KeyValuePair<ScriptableCow.UniqueID, int> entry in plottedRituals)
        {
            RitualModule iteratedModule = new RitualModule(entry.Key, entry.Value);
            ritualDictionary.Add(entry.Key, iteratedModule);
        }

        //
        behaviour = mapBehaviour(sr.Type);
    }



    //RITUAL TYPE MAPPING
    private iRitualBehaviour mapBehaviour(ScriptableRitual.ERitualType type)
    {
        switch (type)
        {
            case ScriptableRitual.ERitualType.SequentialCapture:
                return new RitSequentialCapture();
            case ScriptableRitual.ERitualType.ItemProximity:
                return new RitProximity();
            case ScriptableRitual.ERitualType.ScoreThreshold:
                return new RitScoreThreshold();
            default:
                //HAS SimpleCapture EMBEDDED
                return null;
        }

    }




    //METHODS
    //TODO: DEVELOP A METHOD THAT CALLS THE iRitualBehaviour LOGIC AND THE REST OF THE PROCEDURES




    public bool HasCow(ScriptableCow.UniqueID searchedID) => ritualDictionary.ContainsKey(searchedID);//TODO: HANDLE TYPE "ANY" CORRECTLY

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
