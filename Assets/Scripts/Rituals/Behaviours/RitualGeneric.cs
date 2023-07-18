using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualGeneric : RitualAbstract
{
    //DATA
    RitualGenericSO template;


    //CONSTRUCTOR
    public RitualGeneric(RitualGenericSO inputTemplate)
    {
        this.template = inputTemplate;
    }

    //METHODS
    public override void DoRitual()
    {
        Debug.Log("RitualGeneric");
    }
}
