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
        PickupBuff,
        InteractTurret
    }


    //DATA
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
        moossionType = type;
        targetQuantity = quantity;
        currentQuantity = 0;
    }


    //METHODS
    public void Progress(int progressQuantity)
    {
        currentQuantity += progressQuantity;
    }

}
