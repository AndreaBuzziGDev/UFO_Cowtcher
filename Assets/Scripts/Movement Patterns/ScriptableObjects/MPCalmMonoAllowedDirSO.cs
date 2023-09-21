using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Random Only Allowed", menuName = "MovementPattern/Calm/Random Only Allowed")]
public class MPCalmMonoAllowedDirSO : MPAbstractCalmSO
{
    [SerializeField] public float timerStill = 1;
    [SerializeField] public float timerMoving = 2;
    [SerializeField] [Range(-0.5f, 1.0f)] public float randomizerSlider = 0.5f;

    [SerializeField] public List<Vector3> AllowedDirections = new();

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPCalmMonoAllowedDir(this);
    }
}
