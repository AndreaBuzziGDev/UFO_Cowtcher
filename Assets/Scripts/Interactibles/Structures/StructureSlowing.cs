using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureSlowing : StructureAbstract
{
    //DATA


    //CONSTRUCTOR
    public StructureSlowing(StructureSlowingSO templateSO) : base(templateSO)
    {
        Debug.Log("FEATURE_STRUCTURE - Calling the StructureSlowingSO Constructor");
        Debug.Log("FEATURE_STRUCTURE - StructureSlowingSO: " + templateSO);

    }

    //METHODS

    ///STRUCTURE FUNCTIONALITIES
    public override void DoBehaviour()
    {
        //DO SOMETHING...

    }

}
