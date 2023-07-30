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
        this.requiredCows = template.RequiredCows;
        this.targetSpawnedCow = template.targetSpawnedCow;
        BuildRitualModules(this.requiredCows);
    }

    //METHODS
    public override void DoRitual(CowSO.UniqueID UID) => ChangeCapturedCowAmount(UID, 1);

}
