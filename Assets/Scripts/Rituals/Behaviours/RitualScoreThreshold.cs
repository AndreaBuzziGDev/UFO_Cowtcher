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
    }


    //METHODS
    public override void DoRitual()
    {
        Debug.Log("RitScoreThreshold");
    }
}