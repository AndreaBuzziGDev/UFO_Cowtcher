using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Towards UFO", menuName = "MovementPattern/Alert/Towards UFO")]
public class MPAlertTowardsUFOSO : MPAbstractAlertSO
{
    [SerializeField] public float timerMoving = 2f;
    [SerializeField] public float timerStill = 1f;
    [SerializeField] [Range(0, 1.0f)] public float randomizerSlider = 0.5f;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPAlertTowardsUFO(this);
    }
}
