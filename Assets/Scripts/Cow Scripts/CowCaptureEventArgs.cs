using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CowCaptureEventArgs : EventArgs
{
    //DATA
    private Cow captured;
    public Cow CapturedCow { get { return captured; } }


    //CONSTRUCTOR
    public CowCaptureEventArgs(Cow capturedCow)
    {
        captured = capturedCow;
    }

}
