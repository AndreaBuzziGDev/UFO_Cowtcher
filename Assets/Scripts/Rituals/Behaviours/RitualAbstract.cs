using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RitualAbstract
{
    //DATA
    [SerializeField] private List<ScriptableCow.UniqueID> requiredCows = new List<ScriptableCow.UniqueID>();
    public List<ScriptableCow.UniqueID> RequiredCows { get { return requiredCows; } }


    //METHODS
    public abstract void DoRitual();

    //TODO: IMPLEMENT METHOD THAT CHECKS WETHER THIS RITUAL SHOULD "BE DONE" OR NO


}
