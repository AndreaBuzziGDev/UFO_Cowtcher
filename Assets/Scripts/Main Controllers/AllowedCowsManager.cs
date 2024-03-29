using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class AllowedCowsManager : MonoSingleton<AllowedCowsManager>
{
    //DATA

    ///
    [SerializeField] private bool allowAllCows = false;
    public bool AllowAllCows { get { return allowAllCows; } }

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

    //INITIALIZATION
    public void Initialization()
    {
        Debug.Log("SpawnManagerCow - All Cows Allowed: " + allowAllCows);

        AllowedCowsSO allowedCows = GetAllowedCowsForMyScene();
        if (allowedCows != null) allowedCowIDs = allowedCows.AllowedCowsUIDList;
        else Debug.Log("SpawnManagerCow - Empty filter.");
    }


    //FUNCTIONALITY
    private AllowedCowsSO GetAllowedCowsForMyScene()
    {
        return GetMatchingAllowedCows(SceneManager.GetActiveScene().name);
    }
    private AllowedCowsSO GetMatchingAllowedCows(string sceneName)
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
