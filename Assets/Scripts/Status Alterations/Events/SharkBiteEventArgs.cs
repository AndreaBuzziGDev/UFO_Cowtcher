using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SharkBiteEventArgs : EventArgs
{
    //DATA
    private float currentScoreLoss;
    public float TargetScoreLoss { get { return currentScoreLoss; } }

    //CONSTRUCTOR
    public SharkBiteEventArgs(float lossPercent)
    {
        this.currentScoreLoss = lossPercent;
    }

}

