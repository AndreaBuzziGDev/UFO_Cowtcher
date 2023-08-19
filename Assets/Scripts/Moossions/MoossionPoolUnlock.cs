using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossionPoolUnlock
{
    //DATA
    ///TARGET MOOSSION POOL
    [SerializeField] private static List<MoossionUnlock> moossionPool = new();
    public static List<MoossionUnlock> MoossionPool { get { return moossionPool; } }



    //METHODS
    //...



    //INITIALIZATION
    public static void BakeMoossionPool()
    {
        //moossionPool.Add();

    }



    //MOOSSIONS FOR UNLOCK




}
