using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SaveSystem
{
    //SAVE SYSTEM IS DRIVEN BY STATIC CODE

    //DATA
    public const string MoossionAddress = "Moossions/";
    public const string StageAddress = "Stages/";
    public const string HSAddress = "HighScore";
    public const string CowAddress = "Cows/";




    //SAVE STAGE UNLOCKS
    public static void SetStageUnlocked(string stageName, bool unlocked)
    {
        if (unlocked)
        {
            PlayerPrefs.SetInt(StageAddress + stageName, 1);//ANY VALUE ABOVE 0 = UNLOCKED
        }
        else
        {
            PlayerPrefs.SetInt(StageAddress + stageName, 0);//0 - STAGE LOCKED
        }
        PlayerPrefs.Save();
    }

    public static bool IsStageUnlocked(string stageName)
    {
        return PlayerPrefs.GetInt(StageAddress + stageName, 0) > 0;//0 - STAGE LOCKED, ANY ABOVE = UNLOCKED
    }

    public static void ResetStagesUnlock()
    {
        //STAGE 1 IS ALWAYS UNLOCKED.
        //PlayerPrefs.SetInt(StageAddress + "Stage 1", 0);
        PlayerPrefs.SetInt(StageAddress + "Stage 2", 0);
        PlayerPrefs.SetInt(StageAddress + "Stage 3", 0);
        PlayerPrefs.SetInt(StageAddress + "Stage 4", 0);
        PlayerPrefs.Save();
    }




    //SAVE HIGH SCORE
    public static void SaveHighScore(int inputHighScore)
    {
        int currentHighScore = LoadHighScore();
        if (currentHighScore >= inputHighScore)
        {
            Debug.Log("SaveSystem - SaveHighScore - input score is not greater than current high score.");
        }
        else
        {
            PlayerPrefs.SetInt(HSAddress, inputHighScore);
            PlayerPrefs.Save();
        }
    }

    public static int LoadHighScore()
    {
        return PlayerPrefs.GetInt(HSAddress, 0);
    }

    public static void ResetHighScore()
    {
        Debug.LogError("SaveSystem - RESETTING HIGH SCORE.");
        PlayerPrefs.SetInt(HSAddress, 0);
        PlayerPrefs.Save();
    }




    //COW PROGRESS INFO
    public static void SaveCowProgress(CowSO.UniqueID cowUID, SaveInfoCow.Knowledge knowValue)//TODO: USE A CLASS TO REPRESENT DATA
    {
        int interestedID = (int)cowUID;
        PlayerPrefs.SetInt(CowAddress + interestedID, (int) knowValue);
        PlayerPrefs.Save();
    }

    public static SaveInfoCow LoadCowProgress(CowSO.UniqueID cowUID)
    {

        int interestedID = (int) cowUID;

        int knowValue = PlayerPrefs.GetInt(CowAddress + interestedID, 0);

        return new SaveInfoCow(interestedID, knowValue);
    }

    public static void ResetCowProgress()
    {
        foreach(CowSO.UniqueID interestedID in Enum.GetValues(typeof(CowSO.UniqueID)).Cast<CowSO.UniqueID>().ToList())
        {
            //PlayerPrefs.SetInt(CowAddress + interestedID, (int)SaveInfoCow.Knowledge.Unknown);
            SaveCowProgress(interestedID, SaveInfoCow.Knowledge.Unknown);
        }
    }

}
