using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionStageFour : IProgressionRewards
{
    //DATA
    ///STAGE NAME
    string stageName = "Stage 4";

    ///UNLOCKED COWS
    CowSO.UniqueID cowUnlock1 = CowSO.UniqueID.R012_Linkow;
    CowSO.UniqueID cowUnlock2 = CowSO.UniqueID.R013_Super_Cowrio;
    CowSO.UniqueID cowUnlock3 = CowSO.UniqueID.R014_Unicowrn;
    CowSO.UniqueID cowUnlock4 = CowSO.UniqueID.R015_Kowtos;
    CowSO.UniqueID cowUnlock5 = CowSO.UniqueID.L006_Cowre_Trainer;
    CowSO.UniqueID cowUnlock6 = CowSO.UniqueID.L007_Cowron;

    ///UNLOCKED STAGES
    //string unlockedStage = "Stage 4";//NOT NEEDED: THERE IS NO STAGE 5



    //METHODS
    public void UnlockCompleted1()
    {
        //UNLOCKS Linkow
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
        //UNLOCKS Super Cowrio
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
        //UNLOCKS Unicowrn
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
        //UNLOCKS Kowtos
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

        //NO STAGE UNLOCKING - THERE IS NO STAGE 5
    }

    public void UnlockCompleted5()
    {
        //UNLOCKS Cowre Trainer
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
        //UNLOCKS Cowron
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
