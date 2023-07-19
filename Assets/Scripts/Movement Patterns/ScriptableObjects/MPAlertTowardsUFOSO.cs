using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Towards UFO", menuName = "MovementPattern/Alert/Towards UFO")]
public class MPAlertTowardsUFOSO : MPAbstractAlertSO
{
    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPAlertTowardsUFO(this);
    }
}
