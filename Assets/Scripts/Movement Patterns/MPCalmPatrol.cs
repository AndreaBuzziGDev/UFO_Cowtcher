using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCalmPatrol : AbstractMovementPattern
{
    //DATA
    ///TEMPLATE
    private readonly MPCalmPatrolSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private float timerMoving;
    private float randomizerSlider;

    private Vector3 initialPosition = Vector3.zero;
    private Vector3 nextRandomDirection = Vector3.forward;



    //CONSTRUCTOR
    public MPCalmPatrol(MPCalmPatrolSO inputTemplate)
    {
        this.template = inputTemplate;
        this.timerMoving = inputTemplate.timerMoving;
        this.randomizerSlider = inputTemplate.randomizerSlider;
    }


    ///TEMPLATE
    public override MPAbstractParentSO Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        if (timerMoving > 0) 
            return nextRandomDirection;

        Vector3 distance = (initialPosition - interestedCow.transform.position);
        if (distance.magnitude < 0.1)
            ResetTimers();


        return distance.normalized;
    }

    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        if (timerMoving > 0) timerMoving -= delta;
    }
    public override void ResetTimers()
    {
        this.timerStill = template.timerStill + Random.Range(-0.5f, this.randomizerSlider);
        this.timerMoving = template.timerMoving;

        nextRandomDirection = UtilsRadius.RandomPositionOnCircleRadius(1);
    }

}
