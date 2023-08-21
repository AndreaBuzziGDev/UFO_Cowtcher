using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTestScript : MonoBehaviour
{
    //DATA
    [SerializeField] private CowSO.UniqueID testCowUID = CowSO.UniqueID.C002;
    [SerializeField] private string testStageName = "Stage 1";


    //METHODS
    //...

    //COWS
    ///TEST SAVE COW
    public void TestSaveCow()
    {
        SaveSystem.SaveCowProgress(testCowUID, SaveInfoCow.Knowledge.Known);
        Debug.Log("Saved Cow with UID: " + testCowUID);
    }


    ///TEST LOAD COW
    public void TestLoadCow()
    {
        SaveInfoCow cowSI = SaveSystem.LoadCowProgress(testCowUID);
        Debug.Log("cowSI CowUID: " + cowSI.CowUID);
        Debug.Log("cowSI KnowledgeValue: " + cowSI.KnowledgeValue);
        Debug.Log("cowSI IsKnown: " + cowSI.IsKnown);
        Debug.Log("cowSI IsCaptured: " + cowSI.IsCaptured);

    }


    ///TEST RESET COW
    public void TestResetCow()
    {
        SaveSystem.ResetCowProgress();
        Debug.Log("reset cow with UID: " + testCowUID);
        TestLoadCow();
    }



    //LEVELS
    ///TEST SAVE LEVEL UNLOCK
    public void TestSaveLevelUnlock()
    {
        //testStageName
        SaveSystem.SetStageUnlocked(testStageName, true);
        Debug.Log("Saved Stage: " + testStageName);
    }

    ///TEST LOAD LEVEL UNLOCK
    public void TestLoadLevelUnlock()
    {
        bool result = SaveSystem.IsStageUnlocked(testStageName);
        Debug.Log("Stage name " + testStageName + " is Unlocked: " + result);
    }

    ///TEST RESET LEVEL UNLOCK
    public void TestResetLevelUnlock()
    {
        SaveSystem.ResetStagesUnlock();
        Debug.Log("Reset All Stages");
    }




    //...

}
