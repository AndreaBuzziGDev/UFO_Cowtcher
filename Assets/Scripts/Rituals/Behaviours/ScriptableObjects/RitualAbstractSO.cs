using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RitualAbstractSO : ScriptableObject
{
    //DATA
    [SerializeField] private List<ScriptableCow.UniqueID> requiredCows = new List<ScriptableCow.UniqueID>();
    public List<ScriptableCow.UniqueID> RequiredCows { get { return requiredCows; } }


    //METHODS
    public abstract RitualAbstract GetRitual();


}
