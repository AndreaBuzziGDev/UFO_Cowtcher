using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Calm Patrol", menuName = "MovementPattern/Calm/Patrol")]
public class MPCalmPatrolSO : MPAbstractCalmSO
{
    [SerializeField] public float timerMoving = 0.5f;
    [SerializeField] [Range(-0.5f, 1.0f)] public float randomizerSlider = 0.15f;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPCalmPatrol(this);
    }
}
