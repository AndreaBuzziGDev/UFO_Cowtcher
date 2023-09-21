using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCalmBouncy : AbstractMovementPattern
{
    //DATA
    ///TEMPLATE
    private readonly MPCalmBouncySO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private float jumpHeight;
    private float stepMovementDuration;

    private Vector3 nextRandomDirection = Vector3.forward;



    //CONSTRUCTOR
    public MPCalmBouncy(MPCalmBouncySO inputTemplate)
    {
        this.template = inputTemplate;
        this.jumpHeight = inputTemplate.jumpHeight;
        this.stepMovementDuration = inputTemplate.stepMovementDuration;

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
