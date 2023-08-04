using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureSlowing : StructureAbstract
{
    //DATA
    private float slowDownPercentage;
    private float slowDownDuration;

    //CONSTRUCTOR
    public StructureSlowing(StructureSlowingSO templateSO) : base(templateSO)
    {
        slowDownPercentage = templateSO.SlowDownPercentage;
        slowDownDuration = templateSO.SlowDownDuration;
    }

    //METHODS

    ///STRUCTURE FUNCTIONALITIES
    public override void DoBehaviour(InteractibleStructure wrappingStructure)
    {
        //DO SOMETHING...
        if(activationSource == eActivationSource.UFO)
        {
            //THIS VERSION = SLOW DOWN ALL COWS ON THE MAP BY THE SAME AMOUNT FOR A GIVEN TIME
            CowManager.Instance.ApplyGlobalSpeedChange(-slowDownPercentage, slowDownDuration);


        }

    }

}
