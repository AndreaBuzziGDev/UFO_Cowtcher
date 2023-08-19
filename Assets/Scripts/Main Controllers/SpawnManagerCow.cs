using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerCow : MonoSingleton<SpawnManagerCow>
{
    //DATA

    ///ALLOWED COW TYPES
    [SerializeField] private List<CowSO.UniqueID> allowedCowIDs = new();

    ///SCRIPTABLE OBJECTS TO TRACK ALLOWED COW SPAWNS
    [SerializeField] private AllowedCowsSO allowedStage1;
    [SerializeField] private AllowedCowsSO allowedStage2;
    [SerializeField] private AllowedCowsSO allowedStage3;
    [SerializeField] private AllowedCowsSO allowedStage4;


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



    //INITIALIZATION



    //FUNCTIONALITY



    //UTILITY


}
