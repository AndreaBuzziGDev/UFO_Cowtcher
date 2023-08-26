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

        //DEBUGGING
        Debug.Log("DEVELOPER MANUAL RESET - EXPERIENCE");

    }


    public void ResetAllCowdex()
    {
        SaveSystem.ResetCowProgress();

        //DEBUGGING
        Debug.Log("DEVELOPER MANUAL RESET - COWDEX");

    }


    public void ResetStageUnlocks()
    {
        SaveSystem.ResetStagesUnlock();

        //DEBUGGING
        Debug.Log("DEVELOPER MANUAL RESET - STAGE UNLOCKS");

    }


    public void ResetHighScore()
    {
        SaveSystem.ResetHighScore();

        //DEBUGGING
        Debug.Log("DEVELOPER MANUAL RESET - HIGHSCORE");

    }



}
