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

}
