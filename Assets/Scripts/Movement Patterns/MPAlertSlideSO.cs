using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Slide", menuName = "MovementPattern/Alert/Slide")]
public class MPAlertSlideSO : MPAbstractAlertSO
{
    [SerializeField] public float sameDirectionTimer = 3.0f;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPAlertSlide(this);
    }
}
