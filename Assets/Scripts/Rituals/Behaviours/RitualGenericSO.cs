using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Generic Ritual", menuName = "Rituals/Generic")]
public class RitualGenericSO : RitualAbstractSO
{
    //DATA


    //METHODS
    public override RitualAbstract GetRitual()
    {
        return new RitualGeneric(this);
    }
}
