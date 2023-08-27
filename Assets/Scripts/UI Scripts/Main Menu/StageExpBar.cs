using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageExpBar : MonoBehaviour
{
    //DATA
    [SerializeField] private TMPro.TextMeshProUGUI levelCounterText;
    [SerializeField] private Image experienceBar;


    //METHODS
    //...

    //FUNCTIONALITIES
    ///UPDATE EXPERIENCE SYSTEM
    public void UpdateExpSystem(SceneNavigationController.eStageSceneName targetScene, int expGained)
    {
        if (targetScene == SceneNavigationController.eStageSceneName.UnsetScene)
        {
            //DO NOTHING ON UNSETSCENE

        }
        else
        {
            //TARGET SCENE NAME
            string targetSceneName = SceneNavigationController.Instance.GetAssociatedName(targetScene);

            //EXPERIENCE LEVEL INFO
            int lvlInfo = SaveSystem.LoadStageLevelInfo(targetSceneName);
            Debug.Log("StageExpBar - lvlInfo: " + lvlInfo);

            //EXPERIENCE ADVANCES ONLY LEVELS 1-6 INCLUDED
            if (lvlInfo < 7)
            {
                //EXPERIENCE AMOUNT INFO
                int expInfo = SaveSystem.LoadStageEXPInfo(targetSceneName);
                Debug.Log("StageExpBar - expInfo: " + expInfo);

                //EXPERIENCE CAP
                int experienceCapForCurrentLevel = SceneNavigationController.Instance.GetAssociatedLevelExperienceCap(targetScene, lvlInfo);
                Debug.Log("StageExpBar - experienceCapForCurrentLevel: " + experienceCapForCurrentLevel);

                //IF EXPERIENCE EXCEEDS CAP...
                //TODO: THIS SHOULD BE A RECURSIVELY-CALLED METHOD. PLAYER MIGHT LEVEL UP MULTIPLE TIMES IN A SINGLE SHOT.
                if (expInfo + expGained >= experienceCapForCurrentLevel)
                {
                    //INCREASE LEVEL
                    lvlInfo++;

                    //LEVEL 7 EXPERIENCE IS ALWAYS 0
                    if (lvlInfo == 7) expInfo = 0;
                    //NEW EXPERIENCE IS THE DIFFERENCE BETWEEN SUM AND CAP
                    else expInfo = (expInfo + expGained) - experienceCapForCurrentLevel;//TODO: GRANT 1 EXP IF LEVEL UP IS EXACTLY ON THE EDGE

                    //SAVING NEW LEVEL INFO
                    SaveSystem.SetStageLevelInfo(targetSceneName, lvlInfo);
                    Debug.Log("StageExpBar - NEW LEVEL: " + lvlInfo);

                    //SAVING NEW LEVEL EXPERIENCE
                    SaveSystem.SetStageEXPInfo(targetSceneName, expInfo);
                    Debug.Log("StageExpBar - NEW EXPERIENCE POINTS: " + expInfo);

                }
                else
                {
                    //SAVING EXPERIENCE
                    SaveSystem.SetStageEXPInfo(targetSceneName, expInfo + expGained);

                    int newExpInfo = SaveSystem.LoadStageEXPInfo(targetSceneName);
                    Debug.Log("StageExpBar - NO LEVEL UP, newExpInfo: " + newExpInfo);
                }

            }

        }
    }


    ///GUI UPDATE
    public void UpdateExpBar(SceneNavigationController.eStageSceneName targetScene)
    {
        if(targetScene == SceneNavigationController.eStageSceneName.UnsetScene)
        {
            //UPDATING GUI
            levelCounterText.text = "?";
            experienceBar.fillAmount = 0;
        }
        else
        {
            //EXPERIENCE LEVEL INFO
            int lvlInfo = SaveSystem.LoadStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(targetScene));

            if(lvlInfo < 7)
            {
                //EXPERIENCE AMOUNT INFO
                int expInfo = SaveSystem.LoadStageEXPInfo(SceneNavigationController.Instance.GetAssociatedName(targetScene));

                //COMPLETING INFO
                int expMax = SceneNavigationController.Instance.GetAssociatedLevelExperienceCap(targetScene, lvlInfo);
                if (expInfo == expMax) expInfo = expMax;

                //UPDATING GUI
                levelCounterText.text = lvlInfo.ToString();
                experienceBar.fillAmount = ((float)expInfo / (float)expMax);
            }
            else
            {
                //UPDATING GUI
                levelCounterText.text = lvlInfo.ToString();
                experienceBar.fillAmount = 1;
            }

        }
    }

}
