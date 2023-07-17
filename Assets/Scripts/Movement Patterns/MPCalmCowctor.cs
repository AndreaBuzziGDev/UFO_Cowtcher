using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Calm Cowctor", menuName = "MovementPattern/Calm/Cowctor")]
public class MPCalmCowctor : AbstractMovementPattern
{
    [SerializeField] [Range(0.1f, 2.0f)] private float accelerationMultiplier = 0.5f;


    public override Vector3 ManageMovement(Cow interestedCow)
    {
        Vector3 result = interestedCow.MovementDirection;

        if (interestedCow.TimerCalmSpecialMovement <= 0.0f)
        {
            interestedCow.ResetTimerAlertSpecialMovement();
            result = accelerationMultiplier * UtilsRadius.Vector3OnUnitCircle(1).normalized;
        }
        float speedMultiplier = TimerCalmSpecialMovement - interestedCow.TimerCalmSpecialMovement;
        result = accelerationMultiplier * speedMultiplier * result;

        return result;
    }
}
