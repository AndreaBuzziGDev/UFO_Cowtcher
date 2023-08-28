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


    //EVENT HANDLING




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
    public abstract void HandleProgressLogic(Cow CapturedCow);

    ///PROGRESS BY SET QUANTITY
    public void DoProgress(int progressQuantity)
    {
        if(!IsComplete) currentQuantity += progressQuantity;
    }


    //UTILITIES
    public int GetRandomTargetQuantity(Type moossionType)
    {
        switch (moossionType)
        {
            case Type.CaptureGeneric:
                return Random.Range(20, 41);
            case Type.CaptureSpecific:
                return Random.Range(5, 11);
            case Type.CaptureBuff:
                return Random.Range(10, 26);
            case Type.CaptureTurret:
                return Random.Range(10, 16);
            default:
                Debug.LogError("Moossion Type: " + moossionType + " is not supported, defaulting 3");
                return 3;
        }

    }

}
