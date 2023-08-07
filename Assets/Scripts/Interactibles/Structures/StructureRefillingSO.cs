using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Refilling Structure", menuName = "Structure/Refilling")]
public class StructureRefillingSO : StructureAbstractSO
{
    //DATA
    [SerializeField] [Range(1.0f, 100.0f)] public float RefillingQuantity = 15.0f;
    [SerializeField] [Range(1.0f, 100.0f)] public float RefillingSpeed = 5.0f;


    //METHODS
    public override StructureAbstract GetStructure()
    {
        return new StructureRefilling(this);
    }
}
