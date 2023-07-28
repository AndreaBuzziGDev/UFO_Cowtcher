using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCalmTowardsSpawnCoords : AbstractMovementPattern
{
    //DATA
    ///TEMPLATE
    private readonly MPCalmTowardsSpawnCoordsSO template;
    private Vector3 spawnCoords;


    //CONSTRUCTOR
    public MPCalmTowardsSpawnCoords(MPCalmTowardsSpawnCoordsSO inputTemplate)
    {
        this.template = inputTemplate;
        spawnCoords = Vector3.zero;//TODO: FIX THIS
    }


    ///TEMPLATE
    public override IMovementPattern Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(Cow interestedCow)
    {
        Vector3 toSpawnCoords = spawnCoords - interestedCow.transform.position;

        if (toSpawnCoords.magnitude >= 0.1)
        {
            return (toSpawnCoords).normalized;
        }
        else
        {
            return Vector3.zero;
        }
    }

    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        //NOT NEEDED

    }
    public override void ResetTimers()
    {
        //NOT NEEDED

    }
}