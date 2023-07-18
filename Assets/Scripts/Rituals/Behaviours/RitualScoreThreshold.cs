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
        requiredCows = template.RequiredCows;
        BuildRitualModules(this.requiredCows);
    }

    //METHODS
    public override void DoRitual(ScriptableCow.UniqueID UID)
    {
        Debug.Log("RitScoreThreshold");
    }
}