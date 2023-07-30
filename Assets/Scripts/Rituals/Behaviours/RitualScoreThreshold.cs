using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualScoreThreshold : RitualAbstract
{
    //DATA
    RitualScoreThresholdSO template;


    //CONSTRUCTOR
    public RitualScoreThreshold(RitualScoreThresholdSO inputTemplate)
    {
        this.template = inputTemplate;
        this.requiredCows = template.RequiredCows;
        this.targetSpawnedCow = template.targetSpawnedCow;
        BuildRitualModules(this.requiredCows);
    }

    //METHODS
    public override void DoRitual(CowSO.UniqueID UID)
    {
        Debug.Log("RitScoreThreshold");
    }
}