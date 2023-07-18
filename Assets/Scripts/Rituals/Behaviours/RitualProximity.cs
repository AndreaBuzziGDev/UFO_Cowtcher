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
        requiredCows = template.RequiredCows;
    }

    //METHODS

    public override void DoRitual(ScriptableCow.UniqueID UID)
    {
        Debug.Log("RitProximity");
    }
}
