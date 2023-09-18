using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Bouncy", menuName = "MovementPattern/Alert/Bouncy")]
public class MPAlertBouncySO: MPAbstractAlertSO
{
    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPAlertBouncy(this);
    }
}
