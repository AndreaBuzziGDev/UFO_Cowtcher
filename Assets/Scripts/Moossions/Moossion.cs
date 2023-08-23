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
    
    

}
