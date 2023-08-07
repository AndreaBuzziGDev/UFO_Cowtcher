using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StructureAbstractSO : ScriptableObject
{
    //THIS WILL BE USED TO REPLICATE THE PATTERN USED ELSEWHERE
    //DATA
    [SerializeField] [Range(1.0f, 50.0f)] public float operativeRadius = 5.0f;

    //METHODS
    public abstract StructureAbstract GetStructure();

}
