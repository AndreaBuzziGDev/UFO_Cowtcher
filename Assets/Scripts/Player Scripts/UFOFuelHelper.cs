using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFuelHelper
{
    public enum eFuelPenaltyMode
    {
        ModeFraction
    }


    public static int HandleFuelRecoveryAmount(CowSO cowTemplate)
    {
        switch (DifficultyManager.Instance.FuelPenaltyMode)
        {
            case DifficultyManager.eFuelPenaltyMode.ModeFraction:
                return FractionMode(cowTemplate);
            default:
                return 0;
        }
    }



    //METHODS
    public static int FractionMode(CowSO cowTemplate)
    {

        Debug.Log("UFO - Cow " + cowTemplate.UID + " Already Captured : " + DifficultyManager.Instance.GetCountCapturedCow(cowTemplate.UID));

        float factoredFuel = ((float)cowTemplate.FuelRecoveryAmount) / (1 + DifficultyManager.Instance.GetCountCapturedCow(cowTemplate.UID));
        Debug.Log("UFO - factoredFuel: " + factoredFuel);

        float ceiledFuel = Mathf.Ceil(factoredFuel);
        Debug.Log("UFO - ceiledFuel: " + ceiledFuel);

        int intFuel = (int)ceiledFuel;
        Debug.Log("UFO - intFuel: " + intFuel);

        return intFuel;
    }


}
