using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossCaptSpecific : Moossion
{
    //DATA
    private CowSO.UniqueID targetUID;
    public CowSO.UniqueID TargetUID { get { return targetUID; } }


    //CONSTRUCTOR
    public MoossCaptSpecific(Type type, int quantity, CowSO.UniqueID cowUID) : base(type, quantity)
    {
        this.targetUID = cowUID;
    }



    //METHODS
    //MOOSSIONS SHOULD INTERCEPT AN EVENT THAT CARRIES THE INFOS ON A CAPTURED COW.
    //THE CONTENT OF THIS EVENT SHOULD BE CHECKED AND THE MISSION SHOULD PROGRESS IF THE CHECK IS PASSED.


}
