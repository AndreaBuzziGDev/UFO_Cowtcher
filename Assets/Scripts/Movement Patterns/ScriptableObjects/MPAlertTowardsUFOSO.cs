using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPAlertTowardsUFOSO : MPAbstractAlertSO
{
    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPAlertTowardsUFO(this);
    }
}
