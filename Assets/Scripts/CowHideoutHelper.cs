using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowHideoutHelper
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
            List<Hideout> avHideouts = HideoutManager.Instance.GetAvailableHideouts(interestedCow.FavouriteHideoutTypes[0]);
            if (avHideouts.Count > 0)
            {
                Hideout newTargetHideout = null;
                foreach(Hideout hid in avHideouts)
                {
                    if(newTargetHideout != null)
                    {
                        Vector3 distanceCowHideoutOld = interestedCow.transform.position - newTargetHideout.transform.position;
                        Vector3 distanceCowHideoutNew = interestedCow.transform.position - hid.transform.position;
                        if (distanceCowHideoutNew.magnitude < distanceCowHideoutOld.magnitude)
                        {
                            newTargetHideout = hid;
                        }

                    }
                    else
                    {
                        newTargetHideout = hid;
                    }
                }
                return newTargetHideout;
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
        Hideout target = interestedCow.TargetHideout;
        target.Host(interestedCow);

    }


}
