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
                Debug.Log("StageExpBar - lvlInfo: " + lvlInfo);
                int expMax = SceneNavigationController.Instance.GetAssociatedLevelExperienceCap(targetScene, lvlInfo - 1);
                if (expInfo == expMax) expInfo = expMax;

                //UPDATING GUI
                levelCounterText.text = lvlInfo.ToString();
                experienceBar.fillAmount = expInfo / expMax;
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
