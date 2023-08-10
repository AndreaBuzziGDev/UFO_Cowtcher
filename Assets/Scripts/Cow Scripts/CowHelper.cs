using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowHelper
{
    //CHECK IF PLAYER IS WITHIN ALERT RADIUS
    public static bool IsUFOWithinRadius(Cow interestedCow)
    {
        Vector3 cowPos = interestedCow.transform.position;
        UFO player = GameController.Instance.FindUFOAnywhere();
        Vector3 ufoPos = new Vector3(player.transform.position.x, 0, player.transform.position.z);

        Vector3 distanceVec = cowPos - ufoPos;

        return (distanceVec.magnitude < interestedCow.AlertRadius);//TODO: COW UNITS
    }

}
