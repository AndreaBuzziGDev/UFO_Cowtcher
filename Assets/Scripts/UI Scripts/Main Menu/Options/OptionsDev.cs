using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class OptionsDev : MonoBehaviour
{
    //DATA


    //METHODS
    //...

    //FUNCTIONALITIES
    public void ResetAllExperience()
    {
        SaveSystem.ResetStageExpInfo();
        SaveSystem.ResetStageLevelInfo();

        //DEBUGGING
        Debug.Log("DEVELOPER MANUAL RESET - EXPERIENCE");
        Debug.Log("DEVELOPER MANUAL RESET - Stage 1 Experience: " + SaveSystem.LoadStageEXPInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage1)));
        Debug.Log("DEVELOPER MANUAL RESET - Stage 2 Experience: " + SaveSystem.LoadStageEXPInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage2)));
        Debug.Log("DEVELOPER MANUAL RESET - Stage 3 Experience: " + SaveSystem.LoadStageEXPInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage3)));
        Debug.Log("DEVELOPER MANUAL RESET - Stage 4 Experience: " + SaveSystem.LoadStageEXPInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage4)));

    }


    public void ResetAllCowdex()
    {
        SaveSystem.ResetCowProgress();

        //DEBUGGING
        Debug.Log("DEVELOPER MANUAL RESET - COWDEX");
        //TODO: USE FOR CYCLE...
        foreach (CowSO.UniqueID interestedID in Enum.GetValues(typeof(CowSO.UniqueID)).Cast<CowSO.UniqueID>().ToList())
        {
            Debug.Log("DEVELOPER MANUAL RESET - COW: " + interestedID + " Progress is: " + SaveSystem.LoadCowProgress(interestedID));
        }
    }


    public void ResetStageUnlocks()
    {
        SaveSystem.ResetStagesUnlock();

        //DEBUGGING
        Debug.Log("DEVELOPER MANUAL RESET - STAGE UNLOCKS");
        Debug.Log("DEVELOPER MANUAL RESET - Stage 1 Level: " + SaveSystem.LoadStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage1)));
        Debug.Log("DEVELOPER MANUAL RESET - Stage 2 Level: " + SaveSystem.LoadStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage2)));
        Debug.Log("DEVELOPER MANUAL RESET - Stage 3 Level: " + SaveSystem.LoadStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage3)));
        Debug.Log("DEVELOPER MANUAL RESET - Stage 4 Level: " + SaveSystem.LoadStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage4)));

    }


    public void ResetHighScore()
    {
        SaveSystem.ResetHighScore();

        //DEBUGGING
        Debug.Log("DEVELOPER MANUAL RESET - HIGHSCORE");
        Debug.Log("DEVELOPER MANUAL RESET - VALUE: " + SaveSystem.LoadHighScore());

    }



}
