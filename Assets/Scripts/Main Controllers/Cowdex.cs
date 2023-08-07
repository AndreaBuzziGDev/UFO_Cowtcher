using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cowdex : MonoSingleton<Cowdex>
{
    //DATA
    /*
     * NOTE: This might benefit from a refactor, that further separates each class' concerns.
     * Specifically, another component/prefab/class could handle the list of cows that a specific level/scene can manage.
     * This could separate the nature of the controller from the nature of what is being controlled.
     */

    [SerializeField] private List<Cow> FullListOfExistingCows = new();//PUT ALL "PREFAB" COWS INSIDE HERE.

    ///DATA STRUCTURES
    private Dictionary<CowSO.UniqueID, Cow> CowArchive = new();//A MAP FOR EACH SCRIPTABLE COW
    private Dictionary<CowSO.UniqueID, CowSO> ScriptableCowArchive = new();//A MAP FOR EACH SCRIPTABLE COW
    private Dictionary<CowSO.UniqueID, IndexedCow> PlayableCowdex = new();//THE ACTUAL "ENCYCLOPEDIA OF COWS"
    private Dictionary<CowSO.UniqueID, RitualAbstractSO> AllSummoningRitualTemplates = new();//THE "ENCYCLOPEDIA OF TEMPLATE SUMMONING RITUALS"
    private Dictionary<CowSO.UniqueID, RitualAbstract> AllRituals = new();//THE "ENCYCLOPEDIA OF ACTUAL CONCRETE SUMMONING RITUALS"




    //METHODS

    //...

    //TODO: STUDY AND APPLY THE SAME CHANGES TO THE Awake METHOD MADE TO GameController IN THIS MONOSINGLETON AS WELL


    // Start is called before the first frame update
    void Start()
    {
        //...

    }





    //INITIALIZATION
    ///OVERALL INITIALIZATION PROCEDURE
    public void Initialization()
    {
        BuildCowdex();
        BuildSummoningRituals();

        //TODO: INTRODUCE DEBUGGING FUNCTIONALITIES (FIND DUPLICATES ETC)

    }

    ///MAIN INITIALIZATION
    public void BuildCowdex()
    {
        Debug.Log("FullListOfExistingCows: " + FullListOfExistingCows.Count);

        foreach(Cow iteratedCow in FullListOfExistingCows)
        {
            //Cow
            CowArchive.Add(iteratedCow.CowTemplate.UID, iteratedCow);

            //ScriptableCow
            ScriptableCowArchive.Add(iteratedCow.CowTemplate.UID, iteratedCow.CowTemplate);

            //IndexedCow
            IndexedCow ic = new IndexedCow(IndexedCow.CowKnowledgeState.Unknown, iteratedCow.CowTemplate);
            PlayableCowdex.Add(iteratedCow.CowTemplate.UID, ic);

            //Summoning Ritual Templates
            AllSummoningRitualTemplates.Add(iteratedCow.CowTemplate.UID, iteratedCow.CowTemplate.SummoningRitual);
        }
        Debug.Log("Cowdex - CowArchive size:  " + CowArchive.Count);
        Debug.Log("Cowdex - ScriptableCowArchive size:  " + ScriptableCowArchive.Count);
        Debug.Log("Cowdex - PlayableCowdex size:  " + PlayableCowdex.Count);
        Debug.Log("Cowdex - AllSummoningRitualTemplates size:  " + AllSummoningRitualTemplates.Count);
    }


    ///SUMMONING RITUAL INITIALIZATION
    public void BuildSummoningRituals()
    {
        foreach (KeyValuePair<CowSO.UniqueID, RitualAbstractSO> entry in AllSummoningRitualTemplates)
        {
            if (entry.Value != null)
            {
                AllRituals.Add(entry.Key, entry.Value.GetRitual());
            }
        }
        Debug.Log("Cowdex - AllRituals size:  " + AllRituals.Count);
    }






    //FUNCTIONALITIES
    ///DATA RETRIEVAL

    ///RETRIEVE ANY Cow
    
    ///ALL
    public List<Cow> GetAllCows() => CowArchive.Values.ToList();

    ///SOME
    public List<Cow> GetCows(List<CowSO.UniqueID> UIDs)
    {
        //TODO: IMPROVE: THIS SHOULD HANDLE PROPERLY EVENTUAL DUPLICATE UIDs

        List<Cow> requiredCows = new();
        foreach (CowSO.UniqueID UID in UIDs) requiredCows.Add(GetCow(UID));
        return requiredCows;
    }

    ///ONE
    public Cow GetCow(CowSO.UniqueID UID)
    {
        //TRY & CATCH? THERE ARE NO COWS SUPPOSED TO BE MISSING IN THIS LIST. ERROR INTENDED?
        return CowArchive[UID];
    }

    ///RETRIEVE ANY ScriptableCow
    public List<CowSO> GetScriptableCows(List<CowSO.UniqueID> UIDs)
    {
        //TODO: IMPROVE: THIS SHOULD HANDLE PROPERLY EVENTUAL DUPLICATE UIDs

        List<CowSO> requiredScriptableCows = new();
        foreach (CowSO.UniqueID UID in UIDs) requiredScriptableCows.Add(GetScriptableCow(UID));
        return requiredScriptableCows;
    }
    public CowSO GetScriptableCow(CowSO.UniqueID UID)
    {
        return ScriptableCowArchive[UID];
    }


    ///RETRIEVE ANY IndexedCow
    public List<IndexedCow> GetIndexedCows(List<CowSO.UniqueID> UIDs)
    {
        //TODO: IMPROVE: THIS SHOULD HANDLE PROPERLY EVENTUAL DUPLICATE UIDs

        List<IndexedCow> relatedCows = new();
        foreach (CowSO.UniqueID UID in UIDs) relatedCows.Add(GetIndexedCow(UID));
        return relatedCows;
    }
    public IndexedCow GetIndexedCow(CowSO.UniqueID UID)
    {
        return PlayableCowdex[UID];
    }


    ///RETRIEVE ANY Scriptable Object Ritual





    //TODO: IMPLEMENT FUNCTIONALITIES TO RETRIEVE DATA RELATIVE TO SUMMONING RITUALS
    ///RETRIEVE ANY CONCRETE RITUAL - FEEDING THE "SPAWNED COW" UID AS ARGUMENT
    public List<RitualAbstract> GetRituals(List<CowSO.UniqueID> UIDs)
    {
        //TODO: IMPROVE: THIS SHOULD HANDLE PROPERLY EVENTUAL DUPLICATE UIDs

        List<RitualAbstract> interestedRituals = new();
        foreach (CowSO.UniqueID UID in UIDs) interestedRituals.Add(GetRitual(UID));
        return interestedRituals;
    }
    public RitualAbstract GetRitual(CowSO.UniqueID UID)
    {
        return AllRituals[UID];
    }


    ///RETRIEVE ANY CONCRETE RITUAL - BASED ON IF THEY CONTAIN THE INTERESTED COW UID
    public List<RitualAbstract> GetRitualsThatContainCow(CowSO.UniqueID UID)
    {
        List<RitualAbstract> involvedRituals = new();
        foreach (KeyValuePair<CowSO.UniqueID, RitualAbstract> entry in AllRituals)
        {
            if (entry.Value.HasCow(UID)) involvedRituals.Add(entry.Value);
        }

        return involvedRituals;
    }





    //TODO: DEVELOP A DEBUG FUNCTIONALITY THAT DETECTS DUPLICATES AMONG THE FullListOfExistingCows AND REPORTS THEM AS ERRORS ON THE GAME/EDITOR CONSOLE.



}
