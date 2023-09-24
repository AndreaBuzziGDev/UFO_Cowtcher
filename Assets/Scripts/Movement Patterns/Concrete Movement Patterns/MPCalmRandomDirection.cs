using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCalmRandomDirection : AbstractMovementPattern
{
    //DATA
    ///TEMPLATE
    private readonly MPCalmRandomDirectionSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private float timerMoving;
    private float timerStill;
    private float randomizerSlider;

    private Vector3 nextRandomDirection = Vector3.forward;



    //CONSTRUCTOR
    public MPCalmRandomDirection(MPCalmRandomDirectionSO inputTemplate)
    {
        this.template = inputTemplate;
        this.timerMoving = inputTemplate.timerMoving;
        this.timerStill = inputTemplate.timerStill;
        this.randomizerSlider = inputTemplate.randomizerSlider;

    }


    ///TEMPLATE
    public override MPAbstractParentSO Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        if (timerMoving > 0) return nextRandomDirection;
        return Vector3.zero;
    }

    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        if (timerMoving > 0) timerMoving -= delta;
        else if (timerStill > 0) timerStill -= delta;
        else ResetTimers();
    }
    public override void ResetTimers()
    {
        this.timerStill = template.timerStill + Random.Range(-0.5f, this.randomizerSlider);
        this.timerMoving = template.timerMoving;

        nextRandomDirection = UtilsRadius.RandomPositionOnCircleRadius(1);
    }

}
