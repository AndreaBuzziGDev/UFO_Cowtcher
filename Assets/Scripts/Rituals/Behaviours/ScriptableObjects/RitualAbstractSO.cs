using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RitualAbstractSO : ScriptableObject
{
    //DATA
    //TODO: ADD TOOLTIPS TO DATA

    //TODO: THIS ACCIDENTALLY CREATE A "CIRCULAR REFERENCE" BETWEEN THE ScriptableCow AND THE TARGET SPAWNED COW. IT WORKS BUT IT COULD BE BETTER.
    [SerializeField] public CowSO.UniqueID targetSpawnedCow;

    [SerializeField] private List<CowSO.UniqueID> requiredCows = new List<CowSO.UniqueID>();
    public List<CowSO.UniqueID> RequiredCows { get { return requiredCows; } }


    //METHODS
    public abstract RitualAbstract GetRitual();


}
