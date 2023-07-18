using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Proximity Ritual", menuName = "Rituals/Proximity")]
public class RitualProximitySO : RitualAbstractSO
{
    //DATA


    //METHODS
    public override RitualAbstract GetRitual()
    {
        return new RitualProximity(this);
    }
}
