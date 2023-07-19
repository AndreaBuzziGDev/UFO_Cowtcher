using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Calm Pumpcow", menuName = "MovementPattern/Calm/Pumpcow Calm")]
public class MPPumpcowCalmSO : MPAbstractCalmSO
{
    public float DashSpeed = 3f;
    public float DashDuration = 1.1f;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPPumpcowCalm(this);
    }
}
