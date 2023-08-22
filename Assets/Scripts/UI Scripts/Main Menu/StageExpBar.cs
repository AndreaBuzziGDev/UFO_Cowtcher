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
        //BASE INFO
        int expInfo = SaveSystem.LoadStageEXPInfo(SceneNavigationController.Instance.GetAssociatedName(targetScene));
        //TODO: UPGRADE TO RETURN "?" ON UNSETSCENE
        int lvlInfo = SaveSystem.LoadStageLevelInfo(SceneNavigationController.Instance.GetAssociatedName(targetScene));

        //COMPLETING INFO
        //TODO: UPGRADE TO MAKE BAR 0% ON UNSETSCENE
        int expMax = SceneNavigationController.Instance.GetAssociatedLevelExperienceCap(targetScene, lvlInfo);

    }

}
