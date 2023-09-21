using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Towards UFO", menuName = "MovementPattern/Alert/Towards UFO")]
public class MPAlertTowardsUFOSO : MPAbstractAlertSO
{
    [SerializeField] public float timerMoving = 1f;
    [SerializeField] public float timerStill = 0.25f;
    [SerializeField] [Range(0, 1.0f)] public float randomizerSlider = 0;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPAlertTowardsUFO(this);
    }
}
