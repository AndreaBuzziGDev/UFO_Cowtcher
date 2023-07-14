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
        //TODO: IMPLEMENT

        return null;
    }

    public static bool CanEnterHideout(Cow interestedCow)
    {
        Hideout h = interestedCow.TargetHideout;
        if (h != null && !h.IsFull())
        {
            return true;
        } 
        else
        {
            return false;
        }
    }

    public static void EnterHideout(Cow interestedCow)
    {
        //NOTIFY THE HIDEOUT THAT THE COW WANTS TO ENTER INSIDE
        //NB: SYNCHRONIZATION ISSUES!!!

        //IF COW HAS ENTERED HIDEOUT, TRANSITION TO HIDDEN STATE
        //IF COW HAS ENTERED HIDEOUT, DISABLE COW

    }


}
