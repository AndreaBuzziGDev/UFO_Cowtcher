using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Calm Stillness", menuName = "MovementPattern/Calm/Stillness")]
public class MPCalmStillnessSO : MPAbstractCalmSO
{
    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPCalmStillness(this);
    }
}
