using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualGeneric : RitualAbstract
{
    //DATA
    RitualSequentialCaptureSO template;


    //CONSTRUCTOR
    public RitualGeneric(RitualSequentialCaptureSO inputTemplate)
    {
        this.template = inputTemplate;
    }

    //METHODS
    public override void DoRitual()
    {
        Debug.Log("RitualGeneric");
    }
}
