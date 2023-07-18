using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RitualAbstractSO : ScriptableObject
{
    //DATA
    [SerializeField] private List<ScriptableCow.UniqueID> requiredCows = new List<ScriptableCow.UniqueID>();
    public List<ScriptableCow.UniqueID> RequiredCows { get { return requiredCows; } }

    //TODO: IGNORE RITUAL TYPES (WILL NOT BE USED
    [SerializeField] private ERitualType type = 0;
    public ERitualType Type { get { return type; } }

    //TODO: POLISH - UNNEEDED
    public enum ERitualType
    {
        SimpleCapture,
        SequentialCapture,
        ItemProximity,
        ScoreThreshold
    }




    //METHODS
    public abstract RitualAbstract GetRitual();


}
