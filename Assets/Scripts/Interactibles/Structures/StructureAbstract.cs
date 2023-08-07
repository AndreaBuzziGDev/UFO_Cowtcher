using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StructureAbstract
{
    //ENUMS
    public enum eActivationSource
    {
        UFO,
        Cow
    }


    //DATA
    ///
    public eActivationSource activationSource;

    ///SIMPLE DATA
    private float operativeRadius;
    public float OperativeRadius { get { return operativeRadius; } }




    ///TEMPLATE
    protected StructureAbstractSO template;


    //CONSTRUCTOR
    ///TO BE IMPLEMENTED/EXTENDED IN CHILD CLASS
    public StructureAbstract(StructureAbstractSO templateSO)
    {
        this.template = templateSO;
        this.operativeRadius = template.operativeRadius;
    }


    //METHODS

    ///TEMPLATE
    //TODO: CAN BE MOVED ELSEWHERE
    public StructureAbstractSO Template() => template;

    ///STRUCTURE FUNCTIONALITIES
    public abstract void DoBehaviour(InteractibleStructure wrappingStructure);


}
