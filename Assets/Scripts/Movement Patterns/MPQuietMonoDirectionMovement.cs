using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MPQuietMonoMovement", menuName = "MovementPattern/Calm Mono Direction")]
public class MPQuietMonoDirectionMovement : AbstractMovementPattern
{
    [SerializeField] private List<Vector3> AllowedDirections = new();

    public override Vector3 ManageMovement()
    {
        if(AllowedDirections == null || AllowedDirections.Count == 0)
        {
            return Vector3.zero;
        }
        //TODO: IMPLEMENT
        //TODO: EQUAL PROBABILITY
        float eqChance = 100 / AllowedDirections.Count;


        return Vector3.zero;
    }

}
