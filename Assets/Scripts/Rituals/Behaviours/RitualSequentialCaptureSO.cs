using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sequential Ritual", menuName = "Rituals/Sequential")]
public class RitualSequentialCaptureSO : RitualAbstractSO
{
    //DATA


    //METHODS
    public override RitualAbstract GetRitual()
    {
        new RitualSequentialCapture(this);
    }
}
