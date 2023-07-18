using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Threshold Ritual", menuName = "Rituals/Threshold")]
public class RitualScoreThresholdSO : RitualAbstractSO
{
    //DATA


    //METHODS
    public override RitualAbstract GetRitual()
    {
        return new RitualScoreThreshold(this);
    }
}
