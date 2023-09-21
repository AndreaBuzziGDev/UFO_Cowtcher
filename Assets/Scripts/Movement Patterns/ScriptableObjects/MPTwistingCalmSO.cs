using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Calm Kowbra", menuName = "MovementPattern/Calm/Kowbra Calm")]
public class MPTwistingCalmSO : MPAbstractCalmSO
{
    public float TimerSameDirectionMovement = 2f;
    public float DirectionChangeRate = 0.1f;
    public float Frequency = 10f;
    [Range(0, 1.0f)]public float Magnitude = 1.0f;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPTwistingCalm(this);
    }
}
