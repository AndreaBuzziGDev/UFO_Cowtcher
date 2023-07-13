using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowdex : MonoSingleton<Cowdex>
{
    //DATA
    private Dictionary<ScriptableCow.UniqueID, IndexedCow> PlayableCowdex = new();//THE ACTUAL "ENCYCLOPEDIA OF COWS"
    private Dictionary<ScriptableCow.UniqueID, ScriptableCow> CowArchive = new();//A MAP FOR EACH SCRIPTABLE COW
    /*
     * NOTE: This might benefit from a refactor, that further separates each class' concerns.
     * Specifically, another component/prefab/class could handle the list of cows that a specific level/scene can manage.
     * This could separate the nature of the controller from the nature of what is being controlled.
     */

    [SerializeField] private List<ScriptableCow> FullListOfExistingCows = new();//PUT ALL SCRIPTABLE OBJECT COWS INSIDE HERE.



    //METHODS

    //...

    // Start is called before the first frame update
    void Start()
    {
        //TODO: INITIALIZE COWDEX

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //FUNCTIONALITIES
    public void BuildCowdex()
    {
        //BuildCowArchive();
        //BuildCowRitualInformation
    }

    public void BuildCowArchive()
    {
        foreach(ScriptableCow sc in FullListOfExistingCows)
        {
            CowArchive.Add(sc.UID, sc);
            IndexedCow ic = new IndexedCow(IndexedCow.CowKnowledgeState.Unknown, sc);
            PlayableCowdex.Add(sc.UID, ic);
        }
    }



    //TODO: DEVELOP A DEBUG FUNCTIONALITY THAT DETECTS DUPLICATES AMONG THE FullListOfExistingCows AND REPORTS THEM AS ERRORS ON THE GAME/EDITOR CONSOLE.


}
