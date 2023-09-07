using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTestScript : MonoBehaviour
{
    //DATA
    [SerializeField] private CowSO.UniqueID testCowUID = CowSO.UniqueID.R000_Kowbra;
    [SerializeField] private string testStageName = "Stage 3";


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
    ///UNLOCK
    ///TEST SAVE STAGE UNLOCK
    public void TestSaveStageUnlock()
    {
        //testStageName
        SaveSystem.SetStageUnlocked(testStageName, true);
        Debug.Log("Saved Stage: " + testStageName);
    }

    ///TEST LOAD STAGE UNLOCK
    public void TestLoadStageUnlock()
    {
        bool result = SaveSystem.IsStageUnlocked(testStageName);
        Debug.Log("Stage name " + testStageName + " is Unlocked: " + result);
    }

    ///TEST RESET STAGE UNLOCK
    public void TestResetStageUnlock()
    {
        SaveSystem.ResetStagesUnlock();
        Debug.Log("Reset All Stages");
    }



    ///EXP
    ///TEST SAVE STAGE EXP
    public void TestSaveStageEXP()
    {
        SaveSystem.SetStageEXPInfo(testStageName, 10);
        Debug.Log("Saved Stage EXP: " + testStageName);
    }

    ///TEST LOAD STAGE EXP
    public void TestLoadStageEXP()
    {
        int result = SaveSystem.LoadStageEXPInfo(testStageName);
        Debug.Log("Stage name " + testStageName + " EXP: " + result);
    }

    ///TEST RESET STAGE EXP
    public void TestResetStageEXP()
    {
        SaveSystem.ResetStageExpInfo();
        Debug.Log("Reset All Stages EXP");
    }



    ///LEVEL
    ///TEST SAVE STAGE LEVEL
    public void TestSaveStageLevel()
    {
        SaveSystem.SetStageLevelInfo(testStageName, 2);
        Debug.Log("Saved Stage Level: " + testStageName);
    }

    ///TEST LOAD STAGE LEVEL
    public void TestLoadStageLevel()
    {
        int result = SaveSystem.LoadStageLevelInfo(testStageName);
        Debug.Log("Stage name " + testStageName + " Level: " + result);
    }

    ///TEST RESET STAGE LEVEL
    public void TestResetStageLevel()
    {
        SaveSystem.ResetStageLevelInfo();
        Debug.Log("Reset All Stages Levels");
    }



    //HIGHSCORE
    public void TestSaveHighscore()
    {
        SaveSystem.SaveHighScore(20000);
        Debug.Log("Saved Highscore");
    }

    ///TEST LOAD STAGE LEVEL
    public void TestLoadHighscore()
    {
        int result = SaveSystem.LoadHighScore();
        Debug.Log("Load Highscore: " + result);
    }

    ///TEST RESET STAGE LEVEL
    public void TestResetHighscore()
    {
        SaveSystem.ResetHighScore();
        Debug.Log("Reset Highscore");
    }

}
