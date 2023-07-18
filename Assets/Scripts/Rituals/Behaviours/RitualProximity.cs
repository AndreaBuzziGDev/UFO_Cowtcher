using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualProximity : RitualAbstract
{
    //DATA
    RitualProximitySO template;


    //CONSTRUCTOR
    public RitualProximity(RitualProximitySO inputTemplate)
    {
        this.template = inputTemplate;
        this.requiredCows = template.RequiredCows;
        this.targetSpawnedCow = template.targetSpawnedCow;
        BuildRitualModules(this.requiredCows);
    }

    //METHODS

    public override void DoRitual(ScriptableCow.UniqueID UID)
    {
        Debug.Log("RitProximity");
    }
}
