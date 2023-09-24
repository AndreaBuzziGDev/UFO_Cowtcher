using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SAPickupEventArgs : EventArgs
{
    //DATA
    private SAAbstract.EBuffType statusAlterationID;
    public SAAbstract.EBuffType StatusAlterationID { get { return statusAlterationID; } }


    //CONSTRUCTOR
    public SAPickupEventArgs(SAAbstract.EBuffType buffID)
    {
        statusAlterationID = buffID;
    }

}
