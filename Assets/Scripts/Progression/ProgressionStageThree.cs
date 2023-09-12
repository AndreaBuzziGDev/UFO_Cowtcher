using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionStageThree : IProgressionRewards
{
    //DATA
    ///STAGE NAME
    string stageName = "Stage 3";

    ///UNLOCKED COWS
    CowSO.UniqueID cowUnlock1 = CowSO.UniqueID.R008_Ice_Cowm;
    CowSO.UniqueID cowUnlock2 = CowSO.UniqueID.R009_Cowdolf;
    CowSO.UniqueID cowUnlock3 = CowSO.UniqueID.R010_Cownguin;
    CowSO.UniqueID cowUnlock4 = CowSO.UniqueID.R011_Cowflake;
    CowSO.UniqueID cowUnlock5 = CowSO.UniqueID.L004_Santa_Cows;
    CowSO.UniqueID cowUnlock6 = CowSO.UniqueID.L005_Cowalanche;

    ///UNLOCKED STAGES
    string unlockedStage = "Stage 4";



    //METHODS
    public void UnlockCompleted1()
    {
        //UNLOCKS Ice Cowm
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
        //UNLOCKS Cowdolf
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
        //UNLOCKS Cownguin
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
        //UNLOCKS Cowflake
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

        //UNLOCK STAGE 4
        if (SaveSystem.IsStageUnlocked(unlockedStage))
        {
            Debug.Log(stageName + " Progression - Completed Level 4 - " + unlockedStage + " is Already Unlocked.");
        }
        else
        {
            SaveSystem.SetStageUnlocked("Stage 2", true);
            Debug.Log(stageName + " Progression - Completed Level 4 - Unlocked " + unlockedStage);
        }
    }

    public void UnlockCompleted5()
    {
        //UNLOCKS Santa Cows
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
        //UNLOCKS Cowalanche
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
