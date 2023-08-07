using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Terrifying Structure", menuName = "Structure/Terrifying")]
public class StructureTerrifyingSO : StructureAbstractSO
{
    //NB: TERRIFY = STUN

    //DATA
    [SerializeField] [Range(1.0f, 100.0f)] public float CowTerrifyDuration = 5.0f;
    [SerializeField] [Range(1.0f, 100.0f)] public float UfoTerrifyDuration = 5.0f;


    //METHODS
    public override StructureAbstract GetStructure()
    {
        return new StructureTerrifying(this);
    }
}
