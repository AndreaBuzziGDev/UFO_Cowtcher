using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Bouncy", menuName = "MovementPattern/Alert/Bouncy")]
public class MPAlertBouncySO: MPAbstractAlertSO
{
    [SerializeField] public float jumpHeight = 0.5f;
    [SerializeField] public float timerMoving = 2f;
    [SerializeField] public float timerStill = 1f;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPAlertBouncy(this);
    }
}
