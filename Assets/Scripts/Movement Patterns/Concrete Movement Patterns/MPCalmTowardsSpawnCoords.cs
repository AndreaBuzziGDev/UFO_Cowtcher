using UnityEngine;

public class MPCalmTowardsSpawnCoords : AbstractMovementPattern
{
    //DATA
    ///TEMPLATE
    private readonly MPCalmTowardsSpawnCoordsSO template;


    //CONSTRUCTOR
    public MPCalmTowardsSpawnCoords(MPCalmTowardsSpawnCoordsSO inputTemplate)
    {
        this.template = inputTemplate;
    }


    ///TEMPLATE
    public override IMovementPattern Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        Vector3 toSpawnCoords = interestedCow.CowScript.SpawnCoords - interestedCow.transform.position;

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