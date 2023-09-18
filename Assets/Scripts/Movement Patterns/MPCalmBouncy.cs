using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCalmBouncy : AbstractMovementPattern
{
    //DATA
    ///TEMPLATE
    private readonly MPCalmBouncySO template;

    //CONSTRUCTOR
    public MPCalmBouncy(MPCalmBouncySO inputTemplate)
    {
        this.template = inputTemplate;
    }


    ///TEMPLATE
    public override IMovementPattern Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        return Vector3.zero;
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
