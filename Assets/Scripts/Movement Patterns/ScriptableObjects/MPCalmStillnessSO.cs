using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCalmStillnessSO : MPAbstractCalmSO
{
    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPCalmStillness(this);
    }
}
