using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Kowbra", menuName = "MovementPattern/Alert/Kowbra Alert")]
public class MPTwistingAlertSO : MPAbstractAlertSO
{
    public float DirectionChangeRate = 0.1f;
    public float Frequency = 10f;
    [Range(0, 90.0f)]public float Magnitude = 30.0f;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPTwistingAlert(this);
    }
}
