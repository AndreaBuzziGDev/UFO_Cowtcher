using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cowdex : MonoSingleton<Cowdex>
{
    //DATA
    [SerializeField] private List<Cow> FullListOfExistingCows = new();//PUT ALL "PREFAB" COWS INSIDE HERE.

    ///DATA STRUCTURES
    private Dictionary<CowSO.UniqueID, Cow> cowArchive = new();//A MAP FOR EACH PREFAB COW
    private Dictionary<CowSO.UniqueID, CowSO> scriptableCowArchive = new();//A MAP FOR EACH SCRIPTABLE COW

    ///DATA STRUCTURE ACTUALLY USED BY COWDEX GUI
    private Dictionary<CowSO.UniqueID, IndexedCow> playableCowdex = new();



    //METHODS

    //...
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
    }

    ///MAIN INITIALIZATION
    public void BuildCowdex()
    {
        Debug.Log("FullListOfExistingCows: " + FullListOfExistingCows.Count);

        foreach(Cow iteratedCow in FullListOfExistingCows)
        {
            //Cow
            cowArchive.Add(iteratedCow.CowTemplate.UID, iteratedCow);

            //ScriptableCow
            scriptableCowArchive.Add(iteratedCow.CowTemplate.UID, iteratedCow.CowTemplate);


            //BUILDING IndexedCow
            IndexedCow ic = new IndexedCow(iteratedCow);
            playableCowdex.Add(iteratedCow.CowTemplate.UID, ic);

        }
        Debug.Log("Cowdex - CowArchive size:  " + cowArchive.Count);
        Debug.Log("Cowdex - ScriptableCowArchive size:  " + scriptableCowArchive.Count);
        Debug.Log("Cowdex - PlayableCowdex size:  " + playableCowdex.Count);
    }






    //FUNCTIONALITIES
    ///DATA RETRIEVAL

    ///RETRIEVE ANY Cow
    
    ///ALL
    public List<Cow> GetAllCows() => cowArchive.Values.ToList();

    ///ALL BUT "ANY" COW
    public List<Cow> GetAllActualCows()
    {
        List<Cow> allCowsExceptANY = GetAllCows();
        allCowsExceptANY.Remove(cowArchive[CowSO.UniqueID.ANY]);

        return allCowsExceptANY;
    }


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
        return cowArchive[UID];
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
        return scriptableCowArchive[UID];
    }


    ///RETRIEVE ANY IndexedCow
    public List<IndexedCow> GetAllIndexedActualCows()
    {
        List<IndexedCow> allCowsExceptANY = GetAllIndexedCows();
        allCowsExceptANY.Remove(playableCowdex[CowSO.UniqueID.ANY]);

        return allCowsExceptANY;
    }
    public List<IndexedCow> GetAllIndexedCows() => playableCowdex.Values.ToList();
    public List<IndexedCow> GetIndexedCows(List<CowSO.UniqueID> UIDs)
    {
        //TODO: IMPROVE: THIS SHOULD HANDLE PROPERLY EVENTUAL DUPLICATE UIDs

        List<IndexedCow> relatedCows = new();
        foreach (CowSO.UniqueID UID in UIDs) relatedCows.Add(GetIndexedCow(UID));
        return relatedCows;
    }
    public IndexedCow GetIndexedCow(CowSO.UniqueID UID)
    {
        return playableCowdex[UID];
    }






    //TODO: DEVELOP A DEBUG FUNCTIONALITY THAT DETECTS DUPLICATES AMONG THE FullListOfExistingCows AND REPORTS THEM AS ERRORS ON THE GAME/EDITOR CONSOLE.



}
