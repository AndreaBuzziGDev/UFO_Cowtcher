using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Calm Go to Spawn Point", menuName = "MovementPattern/Calm/Go To Spawn Point")]
public class MPCalmTowardsSpawnCoordsSO : MPAbstractCalmSO
{
    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPCalmTowardsSpawnCoords(this);
    }
}
