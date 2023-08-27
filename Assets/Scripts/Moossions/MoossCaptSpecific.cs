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



    //ABSTRACT METHODS CONCRETIZATION
    ///DESCRIPTION
    public override string GetDescription()
    {
        return "Capture " + TargetQuantity + " " + Cowdex.Instance.GetCow(targetUID).CowTemplate.CowName +" cows.";
    }

    ///COW CAPTURE LOGIC PROGRESS
    public override void HandleProgressLogic(Cow CapturedCow)
    {
        if (CapturedCow.CowTemplate.UID == targetUID)
        {
            DoProgress(1);
        }
        else
        {
            Debug.Log("A cow that is not the intended one has been captured: " + CapturedCow.CowTemplate.UID);
        }
    }




    //UTILITIES
    public static CowSO.UniqueID GetRandomTarget()
    {
        //TODO: IMPLEMENT A COW-TYPE TRACKING SYSTEM
        //TODO: WAIT FOR SpawnManager TO BE COMPLETE FOR THIS


        //TODO: RANDOMIZE EVEN FURTHER
        List<CowSO.UniqueID> uniqueIDs = new List<CowSO.UniqueID> { CowSO.UniqueID.C000BlackCow, CowSO.UniqueID.C001WhiteCow };

        int randomIndex = Random.Range(0, uniqueIDs.Count - 1);

        return uniqueIDs[randomIndex];
    }

}
