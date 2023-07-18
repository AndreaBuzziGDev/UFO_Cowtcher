using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Calm Cowctor", menuName = "MovementPattern/Calm/Cowctor Calm")]
public class MPCowctorCalmSO : MPAbstractCalmSO
{
    [SerializeField] public float TimerSameDirectionMovement = 3.0f;
    [SerializeField] [Range(0.1f, 2.0f)] public float accelerationMultiplier = 0.5f;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPCowctorCalm(this);
    }
}
