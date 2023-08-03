using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Structure
{
    //DATA
    protected StructureSOAbstract template;

    private float operativeRadius;
    public float OperativeRadius { get { return operativeRadius; } }


    //CONSTRUCTOR
    ///TO BE IMPLEMENTED/EXTENDED IN CHILD CLASS
    public Structure(StructureSOAbstract templateSO)
    {
        this.template = templateSO;
        this.operativeRadius = template.operativeRadius;
    }


    //METHODS

    ///TEMPLATE
    public StructureSOAbstract Template()
    {
        return template;
    }

    ///


}
