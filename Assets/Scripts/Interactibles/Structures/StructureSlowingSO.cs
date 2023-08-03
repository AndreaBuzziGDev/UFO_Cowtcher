using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Slowing Structure", menuName = "Structure/Slowing")]
public class StructureSlowingSO : StructureAbstractSO
{
    //DATA
    [SerializeField] [Range(1.0f, 100.0f)] public float SlowDownPercentage = 15.0f;


    //METHODS
    public override StructureAbstract GetStructure()
    {
        return new StructureSlowing(this);
    }
}
