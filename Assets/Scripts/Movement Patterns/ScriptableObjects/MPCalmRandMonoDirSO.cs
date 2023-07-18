using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Random Mono Direction", menuName = "MovementPattern/Calm/Random Mono Direction")]
public class MPCalmRandMonoDirSO : MPAbstractCalmSO
{
    [SerializeField] public float timerStill = 1;
    [SerializeField] public float timerMoving = 2;
    [SerializeField] [Range(0.1f, 2.0f)] public float randomizerSlider = 2.0f;

    [SerializeField] public List<Vector3> AllowedDirections = new();

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPCalmRandMonoDir(this);
    }
}
