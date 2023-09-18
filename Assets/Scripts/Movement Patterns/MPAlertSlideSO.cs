using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Slide", menuName = "MovementPattern/Alert/Slide")]
public class MPAlertSlideSO : MPAbstractAlertSO
{
    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPAlertSlide(this);
    }
}
