using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Random", menuName = "MovementPattern/Calm/Random")]
public class MPCalmRandomDirectionSO : MPAbstractCalmSO
{
    [SerializeField] public float timerMoving = 2f;
    [SerializeField] public float timerStill = 1f;
    [SerializeField] [Range(-0.5f, 1.0f)] public float randomizerSlider = 0.5f;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPCalmRandomDirection(this);
    }
}
