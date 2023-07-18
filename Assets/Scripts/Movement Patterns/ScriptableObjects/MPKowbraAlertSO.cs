using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Kowbra", menuName = "MovementPattern/Alert/Kowbra Alert")]
public class MPKowbraAlertSO : MPAbstractAlertSO
{
    public float DirectionChangeRate = 0.1f;
    public float Frequency = 10f;
    [Range(0, 1.0f)]public float Magnitude = 1.0f;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPKowbraAlert(this);
    }
}
