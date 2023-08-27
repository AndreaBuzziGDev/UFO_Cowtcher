using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageExpBarHelper
{

    public static void HandleIncreaseExperience(SceneNavigationController.eStageSceneName targetScene, int expGained)
    {
        //TARGET SCENE NAME
        string targetSceneName = SceneNavigationController.Instance.GetAssociatedName(targetScene);

        //EXPERIENCE LEVEL INFO
        int lvlInfo = SaveSystem.LoadStageLevelInfo(targetSceneName);
        Debug.Log("StageExpBar - lvlInfo: " + lvlInfo);

        //EXPERIENCE ADVANCES ONLY IN LEVELS 1-6 INCLUDED
        if (lvlInfo < 7)
        {
            //EXPERIENCE AMOUNT INFO
            int expInfo = SaveSystem.LoadStageEXPInfo(targetSceneName);
            Debug.Log("StageExpBar - expInfo: " + expInfo);

            int newExpAmount = expInfo + expGained;
            Debug.Log("StageExpBar - newExpAmount: " + newExpAmount);

            int lvlCounter = 1;
            int experienceCapTally = 0;

            while (true) {
                //CURRENT EXP LEVEL CAP
                int expCapCurrentLevel = SceneNavigationController.Instance.GetAssociatedLevelExperienceCap(targetScene, lvlCounter);
                Debug.Log("StageExpBar - expCapCurrentLevel: " + expCapCurrentLevel);

                experienceCapTally += expCapCurrentLevel;
                Debug.Log("StageExpBar - experienceCapTally: " + experienceCapTally);

                if (newExpAmount < experienceCapTally) break;
                else
                {
                    lvlCounter++;
                }
            }
            Debug.Log("StageExpBar - lvlCounter: " + lvlCounter);



            //SAVING NEW LEVEL INFO
            SaveSystem.SetStageLevelInfo(targetSceneName, lvlCounter);
            Debug.Log("StageExpBar - NEW LEVEL: " + lvlCounter);

            //SAVING NEW LEVEL EXPERIENCE
            SaveSystem.SetStageEXPInfo(targetSceneName, newExpAmount);
            Debug.Log("StageExpBar - NEW EXPERIENCE POINTS: " + newExpAmount);
        }
    }


}
