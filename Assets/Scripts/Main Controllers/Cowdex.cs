using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowdex : MonoSingleton<Cowdex>
{
    //DATA
    private Dictionary<ScriptableCow.UniqueID, IndexedCow> PlayableCowdex;//THE ACTUAL "ENCYCLOPEDIA OF COWS"
    /*
     * NOTE: This might benefit from a refactor, that further separates each class' concerns.
     * Specifically, another component/prefab/class could handle the list of cows that a specific level/scene can manage.
     * This could separate the nature of the controller from the nature of what is being controlled.
     */

    [SerializeField] private List<ScriptableCow> FullListOfExistingCows;//PUT ALL SCRIPTABLE OBJECT COWS INSIDE HERE.



    //METHODS

    //...

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //FUNCTIONALITIES

    //TODO: DEVELOP A DEBUG FUNCTIONALITY THAT DETECTS DUPLICATES AMONG THE FullListOfExistingCows AND REPORTS THEM AS ERRORS ON THE GAME/EDITOR CONSOLE.


}
