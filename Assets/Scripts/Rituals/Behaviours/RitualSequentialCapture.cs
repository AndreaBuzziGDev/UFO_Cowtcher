using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualSequentialCapture : RitualAbstract
{
    //DATA
    RitualSequentialCaptureSO template;


    //CONSTRUCTOR
    public RitualSequentialCapture(RitualSequentialCaptureSO inputTemplate)
    {
        this.template = inputTemplate;
        requiredCows = template.RequiredCows;
    }

    //METHODS
    public override void DoRitual(ScriptableCow.UniqueID UID)
    {
        Debug.Log("RitSequentialCapture");
    }
}
