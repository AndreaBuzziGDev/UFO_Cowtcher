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


        //GO IN A RANDOM DIRECTION
        if (timerMoving > 0) 
            return nextRandomDirection;

        //GO BACK TO PATROL POINT
        Vector3 toLastAlertCoords = interestedCow.CowScript.LastAlertCoords - interestedCow.transform.position;
        if (toLastAlertCoords.magnitude < 0.1)
            ResetTimers();

        return toLastAlertCoords.normalized;
    }

    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        if (timerMoving > 0) timerMoving -= delta;
    }
    public override void ResetTimers()
    {
        this.timerMoving = template.timerMoving;

        nextRandomDirection = UtilsRadius.RandomPositionOnCircleRadius(1);
    }

}
