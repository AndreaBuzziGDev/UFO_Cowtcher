using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowHelper
{

    //CHECK IF PLAYER IS WITHIN ALERT RADIUS
    public static bool IsUFOWithinRadius(Cow interestedCow)
    {
        //TODO: UFO POSITION HAS TO BE PROJECTED TO THE GROUND

        Vector3 cowPos = interestedCow.transform.position;
        Vector3 ufoPos = GameController.Instance.FindUFOAnywhere().transform.position;

        Vector3 distanceVec = cowPos - ufoPos;
        float distance = distanceVec.magnitude;

        return (distance < interestedCow.AlertRadius);//TODO: COW UNITS
    }

    public static Hideout FindHideout(Cow interestedCow)
    {
        if (interestedCow.CowTemplate != null && interestedCow.CowTemplate.FavouriteHideoutTypes.Count > 0)
        {
            List<Hideout> avHideouts = HideoutManager.Instance.GetAvailableHideouts(interestedCow.CowTemplate.FavouriteHideoutTypes[0]);
            if (avHideouts.Count > 0)
            {
                Debug.Log("Cow " + interestedCow.CowName + " has chosen the " + avHideouts[0] + " as a target Hideout.");

                return avHideouts[0];
            }

        }

        return null;
    }

    public static bool CanEnterHideout(Cow interestedCow)
    {
        Hideout h = interestedCow.TargetHideout;
        if (h != null && h.HasAvailableSlots())
        {
            float distance = (interestedCow.transform.position - h.transform.position).magnitude;
            if (distance <= h.HideoutTemplate.CowAllowedRadius)
            {
                return true;
            }
        }

        return false;
    }

    public static void EnterHideout(Cow interestedCow)
    {
        //NOTIFY THE HIDEOUT THAT THE COW WANTS TO ENTER INSIDE
        //NB: SYNCHRONIZATION ISSUES!!!

        //IF COW HAS ENTERED HIDEOUT, TRANSITION TO HIDDEN STATE
        //IF COW HAS ENTERED HIDEOUT, DISABLE COW
        Debug.Log("Cow " + interestedCow.CowName + " want to enter hideout");

    }


}
