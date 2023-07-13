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



    //METHODS

    //...
    // Start is called before the first frame update
    void Start()
    {
        BuildCowdex();

        //TODO: INTRODUCE DEBUGGING FUNCTIONALITIES (FIND DUPLICATES ETC)

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //FUNCTIONALITIES
    ///INITIALIZATION
    public void BuildCowdex()
    {
        foreach(Cow iteratedCow in FullListOfExistingCows)
        {
            //Cow
            CowArchive.Add(iteratedCow.CowTemplate.UID, iteratedCow);

            //ScriptableCow
            ScriptableCowArchive.Add(iteratedCow.CowTemplate.UID, iteratedCow.CowTemplate);

            //IndexedCow
            IndexedCow ic = new IndexedCow(IndexedCow.CowKnowledgeState.Unknown, iteratedCow.CowTemplate);
            PlayableCowdex.Add(iteratedCow.CowTemplate.UID, ic);
        }
    }



    ///DATA RETRIEVAL

    ///RETRIEVE ANY Cow
    public Cow GetCow(ScriptableCow.UniqueID UID)
    {
        return CowArchive[UID];
    }

    ///RETRIEVE ANY ScriptableCow
    public ScriptableCow GetScriptableCow(ScriptableCow.UniqueID UID)
    {
        return ScriptableCowArchive[UID];
    }

    ///RETRIEVE ANY IndexedCow
    public IndexedCow GetIndexedCow(ScriptableCow.UniqueID UID)
    {
        return PlayableCowdex[UID];
    }






    //TODO: DEVELOP A DEBUG FUNCTIONALITY THAT DETECTS DUPLICATES AMONG THE FullListOfExistingCows AND REPORTS THEM AS ERRORS ON THE GAME/EDITOR CONSOLE.



}
