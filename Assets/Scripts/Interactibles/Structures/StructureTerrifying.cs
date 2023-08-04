using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureTerrifying : StructureAbstract
{
    //DATA
    private float cowTerrifyDuration = 5.0f;
    private float ufoTerrifyDuration = 5.0f;

    //CONSTRUCTOR
    public StructureTerrifying(StructureTerrifyingSO templateSO) : base(templateSO)
    {
        cowTerrifyDuration = templateSO.CowTerrifyDuration;
        ufoTerrifyDuration = templateSO.UfoTerrifyDuration;
    }

    //METHODS

    ///STRUCTURE FUNCTIONALITIES
    public override void DoBehaviour(InteractibleStructure wrappingStructure)
    {
        //DO SOMETHING...
        if (activationSource == eActivationSource.UFO)
        {
            //THIS VERSION = TERRIFIES ALL THE COWS ON THE MAP
            CowManager.Instance.ApplyGlobalTerrify(cowTerrifyDuration);
        }
        else
        {
            //...

        }

    }

}
