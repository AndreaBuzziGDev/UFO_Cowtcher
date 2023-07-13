using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MPAlertEscapeOpposite", menuName = "MovementPattern/Alert Escape Opposite")]
public class MPAlertEscapeOpposite : AbstractMovementAlert
{

    public override Vector3 ManageMovement(Vector3 cowPosition)
    {
        UFO menace = (UFO) FindObjectOfType<UFO>();
        Vector3 menacePosition = menace.transform.position;
        Vector3 desiredDirection = cowPosition - menacePosition;


        return desiredDirection.normalized;
    }

    public override Vector3 ManagePanic(Vector3 cowPosition)
    {
        //TODO: IMPLEMENT

        return Vector3.zero;
    }

}
