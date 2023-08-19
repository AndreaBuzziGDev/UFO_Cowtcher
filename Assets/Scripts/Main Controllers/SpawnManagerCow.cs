using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SpawnManagerCow : MonoSingleton<SpawnManagerCow>
{
    //DATA

    ///ALLOWED COW TYPES
    [SerializeField] private List<CowSO.UniqueID> allowedCowIDs = new();
    public List<CowSO.UniqueID> AllowedCowIDs { get { return allowedCowIDs; } }


    ///SCRIPTABLE OBJECTS TO TRACK ALLOWED COW SPAWNS
    [SerializeField] private AllowedCowsSO allowedStage1;
    [SerializeField] private AllowedCowsSO allowedStage2;
    [SerializeField] private AllowedCowsSO allowedStage3;
    [SerializeField] private AllowedCowsSO allowedStage4;


    //METHODS
    //...

    // Update is called once per frame
    void Update()
    {
        
    }



    //INITIALIZATION
    public void Initialization()
    {
        allowedCowIDs = GetAllowedCowsForMyScene().AllowedCowsUIDList;
    }


    //FUNCTIONALITY
    public AllowedCowsSO GetAllowedCowsForMyScene()
    {
        return GetMatchingAllowedCows(SceneManager.GetActiveScene().name);
    }
    public AllowedCowsSO GetMatchingAllowedCows(string sceneName)
    {

        return sceneName switch
        {
            "Stage 1" => allowedStage1,
            "Stage 2" => allowedStage2,
            "Stage 3" => allowedStage3,
            "Stage 4" => allowedStage4,
            _ => null,
        };
    }



    //UTILITY


}
