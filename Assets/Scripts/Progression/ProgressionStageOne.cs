using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionStageOne : IProgressionRewards
{
    //UNLOCKS

    public void UnlockCompleted1()
    {
        //UNLOCKS KOWBRA
        SaveInfoCow.Knowledge knowValue = SaveSystem.LoadCowProgress(CowSO.UniqueID.R000Kowbra).KnowledgeValue;

        if (knowValue == SaveInfoCow.Knowledge.Unknown)
        {
            SaveSystem.SaveCowProgress(CowSO.UniqueID.R000Kowbra, SaveInfoCow.Knowledge.Known);
            Debug.Log("Stage 1 Progression - Completed Level 1 - Unlocked Kowbra.");
        }
        else
        {
            Debug.Log("Stage 1 Progression - Completed Level 1 - Kowbra is already " + knowValue.ToString());
        }
    }

    public void UnlockCompleted2()
    {
        //UNLOCKS SCARECOW
        SaveInfoCow.Knowledge knowValue = SaveSystem.LoadCowProgress(CowSO.UniqueID.R003Scarecow).KnowledgeValue;

        if (knowValue == SaveInfoCow.Knowledge.Unknown)
        {
            SaveSystem.SaveCowProgress(CowSO.UniqueID.R003Scarecow, SaveInfoCow.Knowledge.Known);
            Debug.Log("Stage 1 Progression - Completed Level 2 - Unlocked Scarecow.");
        }
        else
        {
            Debug.Log("Stage 1 Progression - Completed Level 2 - Scarecow is already " + knowValue.ToString());
        }
    }

    public void UnlockCompleted3()
    {
        //UNLOCKS COWTTLEMAN
        SaveInfoCow.Knowledge knowValue = SaveSystem.LoadCowProgress(CowSO.UniqueID.R002Cowttleman).KnowledgeValue;

        if (knowValue == SaveInfoCow.Knowledge.Unknown)
        {
            SaveSystem.SaveCowProgress(CowSO.UniqueID.R002Cowttleman, SaveInfoCow.Knowledge.Known);
            Debug.Log("Stage 1 Progression - Completed Level 3 - Unlocked Cowttleman.");
        }
        else
        {
            Debug.Log("Stage 1 Progression - Completed Level 3 - Cowttleman is already " + knowValue.ToString());
        }
    }

    public void UnlockCompleted4()
    {
        //UNLOCKS PUMPCOW
        SaveInfoCow.Knowledge knowValue = SaveSystem.LoadCowProgress(CowSO.UniqueID.R001PumpCow).KnowledgeValue;

        if (knowValue == SaveInfoCow.Knowledge.Unknown)
        {
            SaveSystem.SaveCowProgress(CowSO.UniqueID.R001PumpCow, SaveInfoCow.Knowledge.Known);
            Debug.Log("Stage 1 Progression - Completed Level 4 - Unlocked PumpCow.");
        }
        else
        {
            Debug.Log("Stage 1 Progression - Completed Level 4 - PumpCow is already " + knowValue.ToString());
        }

        //UNLOCK STAGE 2
        if (SaveSystem.IsStageUnlocked("Stage 2"))
        {
            Debug.Log("Stage 1 Progression - Completed Level 4 - Stage 2 is Already Unlocked.");
        }
        else
        {
            SaveSystem.SetStageUnlocked("Stage 2", true);
            Debug.Log("Stage 1 Progression - Completed Level 4 - Unlocked Stage 2.");
        }

    }

    public void UnlockCompleted5()
    {
        //UNLOCKS COWCTOR
        SaveInfoCow.Knowledge knowValue = SaveSystem.LoadCowProgress(CowSO.UniqueID.L000Cowctor).KnowledgeValue;

        if (knowValue == SaveInfoCow.Knowledge.Unknown)
        {
            SaveSystem.SaveCowProgress(CowSO.UniqueID.L000Cowctor, SaveInfoCow.Knowledge.Known);
            Debug.Log("Stage 1 Progression - Completed Level 5 - Unlocked Cowctor.");
        }
        else
        {
            Debug.Log("Stage 1 Progression - Completed Level 5 - Cowctor is already " + knowValue.ToString());
        }
    }

    public void UnlockCompleted6()
    {
        //UNLOCKS COWGON
        SaveInfoCow.Knowledge knowValue = SaveSystem.LoadCowProgress(CowSO.UniqueID.L001Cowgon).KnowledgeValue;

        if (knowValue == SaveInfoCow.Knowledge.Unknown)
        {
            SaveSystem.SaveCowProgress(CowSO.UniqueID.L001Cowgon, SaveInfoCow.Knowledge.Known);
            Debug.Log("Stage 1 Progression - Completed Level 6 - Unlocked Cowgon.");
        }
        else
        {
            Debug.Log("Stage 1 Progression - Completed Level 6 - Cowgon is already " + knowValue.ToString());
        }
    }

}
