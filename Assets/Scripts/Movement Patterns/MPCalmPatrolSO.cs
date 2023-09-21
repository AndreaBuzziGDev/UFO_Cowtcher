using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Calm Patrol", menuName = "MovementPattern/Calm/Patrol")]
public class MPCalmPatrolSO : MPAbstractCalmSO
{
    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPCalmPatrol(this);
    }
}
