using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CowCaptureEventArgs : EventArgs
{
    //DATA
    private Cow captured;
    public Cow CapturedCow { get { return captured; } }

    private bool isNewlyCaptured;
    public bool IsNewlyCaptured { get { return isNewlyCaptured} }

    //CONSTRUCTOR
    public CowCaptureEventArgs(Cow capturedCow)
    {
        captured = capturedCow;
        isNewlyCaptured = SaveSystem.LoadCowProgress(capturedCow.CowTemplate.UID).IsCaptured;
    }

}
