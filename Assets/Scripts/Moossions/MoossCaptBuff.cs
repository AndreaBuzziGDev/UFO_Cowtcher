using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossCaptBuff : Moossion
{
    //ENUMS
    public enum SoughtBuff
    {
        SpeedMovementBoost,
        FuelGainBoost
    }

    //DATA
    private SoughtBuff buff;

    public SoughtBuff Buff { get { return buff; } }


    //CONSTRUCTOR
    public MoossCaptBuff(Type type, int quantity, SoughtBuff targetBuff) : base(type, quantity)
    {
        buff = targetBuff;
    }



    //METHODS
    //MOOSSIONS SHOULD INTERCEPT AN EVENT THAT CARRIES THE INFOS ON A CAPTURED COW.
    //THE CONTENT OF THIS EVENT SHOULD BE CHECKED AND THE MISSION SHOULD PROGRESS IF THE CHECK IS PASSED.




    //UTILITIES
    public static SoughtBuff GetRandomTarget()
    {
        //TODO: IMPLEMENT A COW-TYPE TRACKING SYSTEM
        //TODO: WAIT FOR SpawnManager TO BE COMPLETE FOR THIS


        //TODO: RANDOMIZE EVEN FURTHER
        List<SoughtBuff> uniqueIDs = new List<SoughtBuff> { SoughtBuff.FuelGainBoost, SoughtBuff.SpeedMovementBoost };

        int randomIndex = Random.Range(0, uniqueIDs.Count - 1);

        return uniqueIDs[randomIndex];
    }

}
