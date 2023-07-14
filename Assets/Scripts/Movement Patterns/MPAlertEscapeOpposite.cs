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
        Vector3 vertLessDirection = new Vector3(desiredDirection.x, 0, desiredDirection.z);

        return vertLessDirection.normalized;
    }

    public override Vector3 ManagePanic(Cow myCow)
    {
        //TODO: IMPLEMENT
        //TODO: USE COW DATA TO KNOW WHICH HIDEOUTS

        return Vector3.zero;
    }

}
