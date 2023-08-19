using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Moossion
{
    //ENUMS
    public enum Type
    {
        CaptureGeneric,
        CaptureSpecific,
        CaptureBuff,
        CaptureTurret,
        PickupBuff,//UNUSED
        InteractTurret//UNUSED
    }


    //DATA
    ///
    private string name;
    public static int MoossionCounter = 1;
    public string Name { get { return name; } }

    ///
    private Type moossionType = 0;
    public Type MoossionType { get { return moossionType; } }


    ///
    private int targetQuantity;
    public int TargetQuantity { get { return targetQuantity; } }

    ///
    private int currentQuantity;
    public int CurrentQuantity { get { return currentQuantity; } }

    ///
    public bool IsComplete { get { return currentQuantity >= targetQuantity; } }



    //CONSTRUCTOR
    public Moossion(Type type, int quantity)
    {
        //NAME IS AUTONUMBER
        name = "Moossion #" + MoossionCounter;
        MoossionCounter++;

        //PROPERTIES
        moossionType = type;
        targetQuantity = quantity;
        currentQuantity = 0;
    }


    //METHODS
    ///DESCRIPTION
    public abstract string GetDescription();


    ///PROGRESSION HANDLING
    public void DoProgress(int progressQuantity)
    {
        currentQuantity += progressQuantity;
    }
    
    
    //UTILITIES
    //NB: PROCEDURAL "DIFFICULTY" FEATURES ARE WORKING, BUT HAVE BEEN SCRAPPED FOR NOW

    ///DIFFICULTY COEFFICIENT
    public static int GetDifficultyCoefficient()
    {
        int moossionCount = MoossionManager.Instance.CompletedMoossionCount;

        int moossionDifficultyCoefficient = (int) moossionCount / 3;

        if (moossionDifficultyCoefficient > 5) moossionDifficultyCoefficient = 5;

        Debug.Log("Moossion - moossionDifficultyCoefficient: " + moossionDifficultyCoefficient);

        return moossionDifficultyCoefficient;
    }

    ///DIFFICULTY REGULATION
    public static int GetDifficultyBasedRandomQuantity(int difficultyCoefficient, Type handledType)
    {
        switch (handledType)
        {
            case Type.CaptureGeneric:
                return 2 + difficultyCoefficient;

            case Type.CaptureSpecific:
                return 1 + difficultyCoefficient;

            case Type.CaptureBuff:
                return 2 + difficultyCoefficient;

            case Type.CaptureTurret:
                return 3 + difficultyCoefficient;

            default:
                return 1;
        }
    }


}
