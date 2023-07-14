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
        //TODO: IMPLEMENT

        return false;
    }


}
