using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Escape Opposite", menuName = "MovementPattern/Alert/Escape Opposite")]
public class MPAlertEscapeOppositeSO : MPAbstractAlertSO
{
    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPAlertEscapeOpposite(this);
    }
}
