using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionSystem
{
    private static ProgressionStageOne stage1 = new ProgressionStageOne();
    private static ProgressionStageTwo stage2 = new ProgressionStageTwo();
    private static ProgressionStageThree stage3 = new ProgressionStageThree();
    private static ProgressionStageFour stage4 = new ProgressionStageFour();


    public static void UnlockAllAvailableRewards()
    {
        UnlockRewardsForLevel(SceneNavigationController.eStageSceneName.Stage1);
        UnlockRewardsForLevel(SceneNavigationController.eStageSceneName.Stage2);
        UnlockRewardsForLevel(SceneNavigationController.eStageSceneName.Stage3);
        UnlockRewardsForLevel(SceneNavigationController.eStageSceneName.Stage4);
    }

    public static void UnlockRewardsForLevel(SceneNavigationController.eStageSceneName intendedScene)
    {
        IProgressionRewards myProgression;
        switch (intendedScene)
        {
            case SceneNavigationController.eStageSceneName.Stage1:
                myProgression = stage1;
                break;
            case SceneNavigationController.eStageSceneName.Stage2:
                myProgression = stage2;
                break;
            case SceneNavigationController.eStageSceneName.Stage3:
                myProgression = stage3;
                break;
            case SceneNavigationController.eStageSceneName.Stage4:
                myProgression = stage4;
                break;
            default:
                myProgression = null;
                break;
        }

        if (myProgression != null)
        {
            //GET LEVEL
            string stageName = SceneNavigationController.Instance.GetAssociatedName(intendedScene);
            int stageLevel = SaveSystem.LoadStageLevelInfo(stageName);
            Debug.Log("ProgressionSystem - Handling Progression for Stage " + stageName);
            Debug.Log("ProgressionSystem - Unlocking all stuff up until level " + stageLevel);

            if (stageLevel > 1) myProgression.UnlockCompleted1();
            if (stageLevel > 2) myProgression.UnlockCompleted2();
            if (stageLevel > 3) myProgression.UnlockCompleted3();
            if (stageLevel > 4) myProgression.UnlockCompleted4();
            if (stageLevel > 5) myProgression.UnlockCompleted5();
            if (stageLevel > 6) myProgression.UnlockCompleted6();
        }
    }

}
