using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RitualAbstract
{
    //TODO: IMPLEMENT METHOD THAT CHECKS WETHER THIS RITUAL SHOULD "BE DONE" OR NO

    //ENUMS
    //TODO: FOR NOW IGNORE RITUAL TYPE
    public enum ERitualType
    {
        SimpleCapture,
        SequentialCapture,
        ItemProximity,
        ScoreThreshold
    }

    //DATA




    //METHODS
    public abstract void DoRitual();

}
