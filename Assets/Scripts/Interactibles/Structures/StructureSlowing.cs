using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureSlowing : StructureAbstract
{
    //DATA
    private float SlowDownPercentage;

    //CONSTRUCTOR
    public StructureSlowing(StructureSlowingSO templateSO) : base(templateSO)
    {
        SlowDownPercentage = templateSO.SlowDownPercentage;
    }

    //METHODS

    ///STRUCTURE FUNCTIONALITIES
    public override void DoBehaviour()
    {
        //DO SOMETHING...
        if(activationSource == eActivationSource.UFO)
        {
            //THIS VERSION = SLOW DOWN ALL COWS ON THE MAP
            List<Cow> allCows = CowManager.Instance.getAllCows();
            //APPLY DEBUFF...
            //IT'S FUNDAMENTALLY BETTER TO IMPLEMENT A DEDICATED STATUS ALTERATION

        }

    }

}
