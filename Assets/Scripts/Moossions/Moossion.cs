using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public static int MoossionCounter = 1;

    ///
    private string name;
    public string Name { get { return name; } }

    ///
    private int moossionIndex;

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


    //EVENT
    public static event EventHandler<MoossionCompleteEventArgs> MoossionComplete;



    //CONSTRUCTOR
    public Moossion(Type type, int quantity)
    {
        //NAME IS AUTONUMBER
        name = "Moossion #" + MoossionCounter;
        moossionIndex = MoossionCounter;
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
        if (!IsComplete)
        {
            currentQuantity += progressQuantity;
            if (IsComplete)
            {
                MoossionCompleteEventArgs myEventArg = new MoossionCompleteEventArgs(moossionIndex);
                OnMoossionComplete(myEventArg);
            }
        }
    }


    //UTILITIES
    public static int GetRandomTargetQuantity(Type moossionType)
    {
        switch (moossionType)
        {
            case Type.CaptureGeneric:
                return UnityEngine.Random.Range(20, 41);
            case Type.CaptureSpecific:
                return UnityEngine.Random.Range(5, 11);
            case Type.CaptureBuff:
                return UnityEngine.Random.Range(10, 26);
            case Type.CaptureTurret:
                return UnityEngine.Random.Range(10, 16);
            default:
                Debug.LogError("Moossion Type: " + moossionType + " is not supported, defaulting 3");
                return 3;
        }

    }


    //EVENT-FIRING METHOD
    private void OnMoossionComplete(MoossionCompleteEventArgs myEventArg)
    {
        // make a copy to be more thread-safe
        EventHandler<MoossionCompleteEventArgs> handler = MoossionComplete;

        if (handler != null)
        {
            // invoke the subscribed event-handler(s)
            handler(this, myEventArg);
        }
    }


}
