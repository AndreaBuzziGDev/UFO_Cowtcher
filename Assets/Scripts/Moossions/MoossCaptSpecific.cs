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
        string defaultDesc = "Capture " + TargetQuantity + " " + Cowdex.Instance.GetCow(targetUID).CowTemplate.CowName;
        if (TargetQuantity > 1) return defaultDesc + "(s)";
        else return defaultDesc;
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
    public static CowSO.UniqueID GetRandomTargetCow()
    {
        List<IndexedCow> playableCows = Cowdex.Instance.GetAllIndexedActualCows();

        //TODO: CROSS THIS INFORMATION WITH THE ALLOWED COWS ON THIS STAGE
        List<CowSO.UniqueID> uniqueIDs = new List<CowSO.UniqueID> { CowSO.UniqueID.C000_BlackCow, CowSO.UniqueID.C001_WhiteCow };
        foreach (IndexedCow ic in playableCows)
        {
            if (ic.KnowledgeState > 0)
            {
                if (ic.ReferenceTemplate.UID != CowSO.UniqueID.C000_BlackCow || ic.ReferenceTemplate.UID != CowSO.UniqueID.C001_WhiteCow)
                {
                    uniqueIDs.Add(ic.ReferenceTemplate.UID);
                }
            }
        }

        int randomIndex = Random.Range(0, uniqueIDs.Count);

        return uniqueIDs[randomIndex];
    }

}
