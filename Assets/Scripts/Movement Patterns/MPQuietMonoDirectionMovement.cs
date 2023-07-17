using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Random Mono Direction", menuName = "MovementPattern/Calm/Random Mono Direction")]
public class MPQuietMonoDirectionMovement : AbstractMovementPattern
{
    [SerializeField] private List<Vector3> AllowedDirections = new();

    public override Vector3 ManageMovement(Cow interestedCow)
    {
        //NB: cowPosition is ignored in this behaviour.

        if(AllowedDirections == null || AllowedDirections.Count == 0)
        {
            return Vector3.zero;
        }

        return AllowedDirections[Random.Range(0, AllowedDirections.Count)];
    }

}
