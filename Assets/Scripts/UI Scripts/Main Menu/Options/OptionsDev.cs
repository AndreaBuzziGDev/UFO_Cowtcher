using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    }


    public void ResetAllCowdex()
    {
        SaveSystem.ResetCowProgress();

    }


    public void ResetStageUnlocks()
    {
        SaveSystem.ResetStagesUnlock();


    }


    //TODO: RESET HIGH SCORE




}
