using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MPAlertEscapeOpposite", menuName = "MovementPattern/Alert/Cowgon")]
public class MPAlertCowgon : AbstractMovementAlert
{
    public override Vector3 ManageMovement(Cow interestedCow)
    {
        UFO menace = (UFO)FindObjectOfType<UFO>();
        Vector3 menacePosition = menace.transform.position;
        Vector3 desiredDirection = interestedCow.transform.position - menacePosition;
        Vector3 vertLessDirection = new Vector3(desiredDirection.x, 0, desiredDirection.z);

        //TODO: DEBUFF UFO WITH "STUN" FOR 1 SECOND EVERY 10 SECONDS


        return vertLessDirection.normalized;
    }

    public override Vector3 ManagePanic(Cow myCow)
    {
        //TODO: IMPLEMENT SO THAT COW WILL RANDOMLY DECIDE ONE DIRECTION AND KEEP IT
        //NB: COULD BE A "FLEE DIRECTION" VECTOR THAT IS HANDLED BY THE ManageMovement Alert CODE
        //GetFleeFromMap();

        return myCow.MovementDirection.normalized;//WITH THIS IMPLEMENTATION, THEY SIMPLY KEEP THE LAST DIRECTION
    }

}
