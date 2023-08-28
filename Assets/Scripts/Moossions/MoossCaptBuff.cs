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



    //ABSTRACT METHODS CONCRETIZATION
    ///DESCRIPTION
    public override string GetDescription()
    {
        return "Capture " + TargetQuantity + " cows while under the effect of a " + GetBuffNameForDesc(buff) + " Boost.";
    }
    
    ///COW CAPTURE LOGIC PROGRESS
    public override void HandleProgressLogic(Cow CapturedCow)
    {
        Debug.Log("Moossion - LOGIC FOR MOOSSION TYPE CAPTURE BUFF HAS NOT BEEN IMPLEMENTED");
        //TODO: EVALUATE SWITCH FROM SOUGHTBUFF TO THE BUFF OF THE ITEMPICKUPS, DISCARD THE ENUM USED HERE


    }





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

    ///
    public static string GetBuffNameForDesc(SoughtBuff sought)
    {
        switch (sought)
        {
            case SoughtBuff.SpeedMovementBoost:
                return "Movement Speed";

            case SoughtBuff.FuelGainBoost:
                return "Fuel Recovery Increase";

            default:
                return "INVALID TYPE " + sought;
        }

    }

}
