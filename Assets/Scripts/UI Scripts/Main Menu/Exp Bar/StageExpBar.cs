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
        if (targetScene != SceneNavigationController.eStageSceneName.UnsetScene)
        {
            StageExpBarHelper.HandleIncreaseExperience(targetScene, expGained);
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

                //EXPERIENCE CAP CURRENT LEVEL
                int expMax = SceneNavigationController.Instance.GetAssociatedLevelExperienceCap(targetScene, lvlInfo);


                //FILL AMOUNT EXP BAR
                int expPreviousTally = 0;
                for (int i = 1; i < lvlInfo; i++)
                {
                    expPreviousTally += SceneNavigationController.Instance.GetAssociatedLevelExperienceCap(targetScene, i);
                }
                Debug.Log("StageExpBar - expInfo: " + expInfo);
                Debug.Log("StageExpBar - expPreviousTally: " + expPreviousTally);

                int factoredExp = expInfo - expPreviousTally;
                Debug.Log("StageExpBar - factoredExp: " + factoredExp);

                float expBarFillAmount = (float)factoredExp / (float)expMax;
                Debug.Log("StageExpBar - fillAmount: " + expBarFillAmount);


                //UPDATING GUI
                levelCounterText.text = lvlInfo.ToString();
                experienceBar.fillAmount = expBarFillAmount;

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
