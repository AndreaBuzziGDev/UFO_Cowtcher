using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: IT COULD MAKE SENSE TO UNIFY THE BEHAVIOUR FOR LEGENDARY MOVEMENTS

[CreateAssetMenu(fileName = "New Alert Cowctor", menuName = "MovementPattern/Alert/Cowctor")]
public class MPAlertCowctor : AbstractMovementAlert
{

    [SerializeField] [Range(1, 9)] private float MinDirectionPersistenceSlider = 4.0f;


    public override Vector3 ManageMovement(Cow interestedCow)
    {
        Vector3 result;

        float randomChance = Random.Range(0, TimerAlertSpecialMovement - MinDirectionPersistenceSlider);
        if (interestedCow.TimerAlertSpecialMovement > randomChance)
        {
            result = interestedCow.MovementDirection;
        }
        else 
        {
            result = UtilsRadius.Vector3OnUnitCircle(1).normalized;
            interestedCow.ResetTimerAlertSpecialMovement();
        }

        return result.normalized;

    }

    public override Vector3 ManagePanic(Cow myCow)
    {
        //TODO: IMPLEMENT SO THAT COW WILL RANDOMLY DECIDE ONE DIRECTION AND KEEP IT
        //NB: COULD BE A "FLEE DIRECTION" VECTOR THAT IS HANDLED BY THE ManageMovement Alert CODE
        //GetFleeFromMap();

        return myCow.MovementDirection.normalized;//WITH THIS IMPLEMENTATION, THEY SIMPLY KEEP THE LAST DIRECTION
    }

}

