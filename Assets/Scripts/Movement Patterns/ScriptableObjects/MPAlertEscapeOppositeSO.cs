using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Escape Opposite", menuName = "MovementPattern/Alert/Escape Opposite")]
public class MPAlertEscapeOppositeSO : MPAbstractAlertSO
{
    MPAlertEscapeOpposite movPattern;

    public override AbstractMovementPattern GetMovPattern()
    {
        if (movPattern == null) movPattern = new MPAlertEscapeOpposite(this);
        return movPattern;
    }
}
