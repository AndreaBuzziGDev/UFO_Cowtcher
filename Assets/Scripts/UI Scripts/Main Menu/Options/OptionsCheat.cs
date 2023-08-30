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


}
