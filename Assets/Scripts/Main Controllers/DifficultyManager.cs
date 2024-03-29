using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoSingleton<DifficultyManager>
{
    //ENUMS
    public enum eFuelPenaltyMode
    {
        ModeFraction
    }


    //DATA
    ///FUNCTIONALITY DATA
    [SerializeField] private bool captureScalingDifficulty;
    public bool IsCaptureScaling { get { return captureScalingDifficulty; } }


    ///FUEL RECOVERY PENALTY MODE
    [SerializeField] private eFuelPenaltyMode fuelPenaltyMode = 0;
    public eFuelPenaltyMode FuelPenaltyMode { get { return fuelPenaltyMode; } }




    ///STRUCTURAL DATA
    Dictionary<CowSO.UniqueID, int> CapturedCowsCounter = new();





    //METHODS
    //...


    //INITIALIZATION
    public void Initialization()
    {
        InitializeCowCounter();


    }
    
    ///CAPTURED COW DIFFICULTY REGISTER
    private void InitializeCowCounter()
    {
        //GENERAL EQUALIZED DIFFICULTY --> START AT 0
        CapturedCowsCounter = new();

    }





    //FUNCTIONALITIES
    public void CountCapturedCow(CowSO.UniqueID interestedCowUID)
    {
        if (CapturedCowsCounter.ContainsKey(interestedCowUID))
        {
            CapturedCowsCounter[interestedCowUID]++;
        }
        else
            CapturedCowsCounter.Add(interestedCowUID, 1);
    }

    public int GetCountCapturedCow(CowSO.UniqueID interestedCowUID)
    {
        if (captureScalingDifficulty && CapturedCowsCounter.ContainsKey(interestedCowUID)) 
            return CapturedCowsCounter[interestedCowUID];
        else
            return 0;
    }



    //UTILITIES
    



}
