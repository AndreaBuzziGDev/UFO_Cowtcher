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
        this.requiredCows = template.RequiredCows;
        this.targetSpawnedCow = template.targetSpawnedCow;
        BuildRitualModules(this.requiredCows);
    }

    //METHODS
    public override void DoRitual(CowSO.UniqueID UID)
    {
        Debug.Log("RitSequentialCapture");
    }
}
