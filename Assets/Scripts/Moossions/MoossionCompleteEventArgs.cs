using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoossionCompleteEventArgs : EventArgs
{
    //DATA
    private int moossionIndex;
    public int MoossionIndex { get { return moossionIndex; } }


    //CONSTRUCTOR
    public MoossionCompleteEventArgs(int index)
    {
        moossionIndex = index;
    }

}
