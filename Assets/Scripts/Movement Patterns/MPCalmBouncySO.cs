using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Calm Bouncy", menuName = "MovementPattern/Calm/Bouncy")]
public class MPCalmBouncySO : MPAbstractCalmSO
{
    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPCalmBouncy(this);
    }
}
