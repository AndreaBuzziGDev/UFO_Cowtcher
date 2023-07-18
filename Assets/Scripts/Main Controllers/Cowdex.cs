using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private Dictionary<ScriptableCow.UniqueID, Cow> CowArchive = new();//A MAP FOR EACH SCRIPTABLE COW
    private Dictionary<ScriptableCow.UniqueID, ScriptableCow> ScriptableCowArchive = new();//A MAP FOR EACH SCRIPTABLE COW
    private Dictionary<ScriptableCow.UniqueID, IndexedCow> PlayableCowdex = new();//THE ACTUAL "ENCYCLOPEDIA OF COWS"
    private Dictionary<ScriptableCow.UniqueID, RitualAbstractSO> AllSummoningRitualTemplates = new();//THE "ENCYCLOPEDIA OF TEMPLATE SUMMONING RITUALS"
    private Dictionary<ScriptableCow.UniqueID, RitualAbstract> AllRituals = new();//THE "ENCYCLOPEDIA OF ACTUAL CONCRETE SUMMONING RITUALS"




    //METHODS

    //...

    //TODO: STUDY AND APPLY THE SAME CHANGES TO THE Awake METHOD MADE TO GameController IN THIS MONOSINGLETON AS WELL


    // Start is called before the first frame update
    void Start()
    {
        BuildCowdex();
        BuildSummoningRituals();

        //TODO: INTRODUCE DEBUGGING FUNCTIONALITIES (FIND DUPLICATES ETC)

    }





    //INITIALIZATION
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
        foreach (KeyValuePair<ScriptableCow.UniqueID, RitualAbstractSO> entry in AllSummoningRitualTemplates)
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
    public List<Cow> GetCows(List<ScriptableCow.UniqueID> UIDs)
    {
        List<Cow> requiredCows = new();
        foreach (ScriptableCow.UniqueID UID in UIDs) requiredCows.Add(GetCow(UID));
        return requiredCows;
    }
    public Cow GetCow(ScriptableCow.UniqueID UID)
    {
        //TRY & CATCH? THERE ARE NO COWS SUPPOSED TO BE MISSING IN THIS LIST. ERROR INTENDED?
        return CowArchive[UID];
    }

    ///RETRIEVE ANY ScriptableCow
    public List<ScriptableCow> GetScriptableCows(List<ScriptableCow.UniqueID> UIDs)
    {
        List<ScriptableCow> requiredScriptableCows = new();
        foreach (ScriptableCow.UniqueID UID in UIDs) requiredScriptableCows.Add(GetScriptableCow(UID));
        return requiredScriptableCows;
    }
    public ScriptableCow GetScriptableCow(ScriptableCow.UniqueID UID)
    {
        return ScriptableCowArchive[UID];
    }


    ///RETRIEVE ANY IndexedCow
    public List<IndexedCow> GetIndexedCows(List<ScriptableCow.UniqueID> UIDs)
    {
        List<IndexedCow> relatedCows = new();
        foreach (ScriptableCow.UniqueID UID in UIDs) relatedCows.Add(GetIndexedCow(UID));
        return relatedCows;
    }
    public IndexedCow GetIndexedCow(ScriptableCow.UniqueID UID)
    {
        return PlayableCowdex[UID];
    }


    //TODO: IMPLEMENT FUNCTIONALITIES TO RETRIEVE DATA RELATIVE TO SUMMONING RITUALS






    //TODO: DEVELOP A DEBUG FUNCTIONALITY THAT DETECTS DUPLICATES AMONG THE FullListOfExistingCows AND REPORTS THEM AS ERRORS ON THE GAME/EDITOR CONSOLE.



}
