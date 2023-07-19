using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Pumpcow", menuName = "MovementPattern/Alert/Pumpcow Alert")]
public class MPPumpcowAlertSO : MPAbstractAlertSO
{
    public float DashSpeed = 3f;
    public float DashDuration = 1.1f;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPPumpcowAlert(this);
    }
}
