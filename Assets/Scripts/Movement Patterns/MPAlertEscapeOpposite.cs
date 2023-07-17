using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Escape Opposite", menuName = "MovementPattern/Alert/Escape Opposite")]
public class MPAlertEscapeOpposite : AbstractMovementAlert
{

    public override Vector3 ManageMovement(Cow interestedCow)
    {
        UFO menace = (UFO) FindObjectOfType<UFO>();
        Vector3 menacePosition = menace.transform.position;
        Vector3 desiredDirection = interestedCow.transform.position - menacePosition;
        Vector3 vertLessDirection = new Vector3(desiredDirection.x, 0, desiredDirection.z);

        return vertLessDirection.normalized;
    }

    public override Vector3 ManagePanic(Cow myCow)
    {
        Hideout targetHideout = myCow.TargetHideout;
        Vector3 hideoutDirection = targetHideout.transform.position - myCow.transform.position;

        UFO myUFO = FindObjectOfType<UFO>();
        Vector3 flatUfoVector = new Vector3(myUFO.transform.position.x, targetHideout.transform.position.y, myUFO.transform.position.z);
        Vector3 ufoHideoutVector = targetHideout.transform.position - flatUfoVector;

        Debug.Log("hideoutDirection: " + hideoutDirection);
        Debug.Log("ufoHideoutVector: " + ufoHideoutVector);

        if (ufoHideoutVector.magnitude <= hideoutDirection.magnitude)
        {
            Debug.Log("UFO IS CLOSER TO HIDEOUT THAN COW!");
            return ManageMovement(myCow);
        }

        return hideoutDirection.normalized;
    }

}
