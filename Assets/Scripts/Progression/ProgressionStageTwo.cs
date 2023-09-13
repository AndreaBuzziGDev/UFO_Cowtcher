using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionStageTwo : IProgressionRewards
{
    //DATA
    ///STAGE NAME
    string stageName = "Stage 2";

    ///UNLOCKED COWS
    CowSO.UniqueID cowUnlock1 = CowSO.UniqueID.R004_Hippocowmp;
    CowSO.UniqueID cowUnlock2 = CowSO.UniqueID.R005_Hermitcow;
    CowSO.UniqueID cowUnlock3 = CowSO.UniqueID.R006_Cowloon;
    CowSO.UniqueID cowUnlock4 = CowSO.UniqueID.R007_Sharkow;
    CowSO.UniqueID cowUnlock5 = CowSO.UniqueID.L002_Cowhtulhu;
    CowSO.UniqueID cowUnlock6 = CowSO.UniqueID.L003_Flying_Cowtchman;

    ///UNLOCKED STAGES
    string unlockedStage = "Stage 3";



    //METHODS
    public void UnlockCompleted1()
    {
        //UNLOCKS Hippocowmp
        SaveInfoCow.Knowledge knowValue = SaveSystem.LoadCowProgress(cowUnlock1).KnowledgeValue;

        if (knowValue == SaveInfoCow.Knowledge.Unknown)
        {
            SaveSystem.SaveCowProgress(cowUnlock1, SaveInfoCow.Knowledge.Known);
            Debug.Log(stageName + " Progression - Completed Level 1 - Unlocked " + cowUnlock1);
        }
        else
        {
            Debug.Log(stageName + " Progression - Completed Level 1 - " + cowUnlock1 + " is already " + knowValue.ToString());
        }
    }

    public void UnlockCompleted2()
    {
        //UNLOCKS Hermitcow
        SaveInfoCow.Knowledge knowValue = SaveSystem.LoadCowProgress(cowUnlock2).KnowledgeValue;

        if (knowValue == SaveInfoCow.Knowledge.Unknown)
        {
            SaveSystem.SaveCowProgress(cowUnlock2, SaveInfoCow.Knowledge.Known);
            Debug.Log(stageName + " Progression - Completed Level 2 - Unlocked " + cowUnlock2);
        }
        else
        {
            Debug.Log(stageName + " Progression - Completed Level 2 - " + cowUnlock2 + " is already " + knowValue.ToString());
        }
    }

    public void UnlockCompleted3()
    {
        //UNLOCKS Cowloon
        SaveInfoCow.Knowledge knowValue = SaveSystem.LoadCowProgress(cowUnlock3).KnowledgeValue;

        if (knowValue == SaveInfoCow.Knowledge.Unknown)
        {
            SaveSystem.SaveCowProgress(cowUnlock3, SaveInfoCow.Knowledge.Known);
            Debug.Log(stageName + " Progression - Completed Level 3 - Unlocked " + cowUnlock3);
        }
        else
        {
            Debug.Log(stageName + " Progression - Completed Level 3 - " + cowUnlock3 + " is already " + knowValue.ToString());
        }
    }

    public void UnlockCompleted4()
    {
        //UNLOCKS Sharkow
        SaveInfoCow.Knowledge knowValue = SaveSystem.LoadCowProgress(cowUnlock4).KnowledgeValue;

        if (knowValue == SaveInfoCow.Knowledge.Unknown)
        {
            SaveSystem.SaveCowProgress(cowUnlock4, SaveInfoCow.Knowledge.Known);
            Debug.Log(stageName + " Progression - Completed Level 4 - Unlocked " + cowUnlock4);
        }
        else
        {
            Debug.Log(stageName + " Progression - Completed Level 4 - " + cowUnlock4 + " is already " + knowValue.ToString());
        }

        //UNLOCK STAGE 3
        if (SaveSystem.IsStageUnlocked(unlockedStage))
        {
            Debug.Log(stageName + " Progression - Completed Level 4 - " + unlockedStage + " is Already Unlocked.");
        }
        else
        {
            SaveSystem.SetStageUnlocked(unlockedStage, true);
            Debug.Log(stageName + " Progression - Completed Level 4 - Unlocked " + unlockedStage);
        }
    }

    public void UnlockCompleted5()
    {
        //UNLOCKS Cowhtulhu
        SaveInfoCow.Knowledge knowValue = SaveSystem.LoadCowProgress(cowUnlock5).KnowledgeValue;

        if (knowValue == SaveInfoCow.Knowledge.Unknown)
        {
            SaveSystem.SaveCowProgress(cowUnlock5, SaveInfoCow.Knowledge.Known);
            Debug.Log(stageName + " Progression - Completed Level 5 - Unlocked " + cowUnlock5);
        }
        else
        {
            Debug.Log(stageName + " Progression - Completed Level 5 - " + cowUnlock5 + " is already " + knowValue.ToString());
        }
    }

    public void UnlockCompleted6()
    {
        //UNLOCKS Flying Cowtchman
        SaveInfoCow.Knowledge knowValue = SaveSystem.LoadCowProgress(cowUnlock6).KnowledgeValue;

        if (knowValue == SaveInfoCow.Knowledge.Unknown)
        {
            SaveSystem.SaveCowProgress(cowUnlock6, SaveInfoCow.Knowledge.Known);
            Debug.Log(stageName + " Progression - Completed Level 6 - Unlocked " + cowUnlock6);
        }
        else
        {
            Debug.Log(stageName + " Progression - Completed Level 6 - " + cowUnlock6 + " is already " + knowValue.ToString());
        }
    }
}
