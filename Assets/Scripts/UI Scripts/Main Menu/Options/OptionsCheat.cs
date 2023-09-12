using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsCheat : MonoBehaviour
{
    //DATA

    //METHODS
    //...

    //FUNCTIONALITIES
    public void CheatOne()
    {
        SaveSystem.SetStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage1), 5);

        //DEBUGGING
        Debug.Log("DEVELOPER CHEAT - STAGE 1 LEVEL 5");
        Debug.Log("DEVELOPER CHEAT - RESULT: " + SaveSystem.LoadStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage1)));
    }
    public void CheatTwo()
    {
        SaveSystem.SetStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage1), 7);

        //DEBUGGING
        Debug.Log("DEVELOPER CHEAT - STAGE 1 LEVEL 7");
        Debug.Log("DEVELOPER CHEAT - RESULT: " + SaveSystem.LoadStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage1)));
    }
    public void CheatThree()
    {
        SaveSystem.SetStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage2), 7);

        //DEBUGGING
        Debug.Log("DEVELOPER CHEAT - STAGE 2 LEVEL 7");
        Debug.Log("DEVELOPER CHEAT - RESULT: " + SaveSystem.LoadStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage2)));
    }
    public void CheatFour()
    {
        SaveSystem.SetStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage3), 7);

        //DEBUGGING
        Debug.Log("DEVELOPER CHEAT - STAGE 3 LEVEL 7");
        Debug.Log("DEVELOPER CHEAT - RESULT: " + SaveSystem.LoadStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage3)));
    }
    public void CheatFive()
    {
        SaveSystem.SetStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage4), 7);

        //DEBUGGING
        Debug.Log("DEVELOPER CHEAT - STAGE 4 LEVEL 7");
        Debug.Log("DEVELOPER CHEAT - RESULT: " + SaveSystem.LoadStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(SceneNavigationController.eStageSceneName.Stage4)));
    }

}
