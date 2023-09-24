using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPTwistingCalm : AbstractMovementPattern
{
    //DATA
    ///TEMPLATE
    private readonly MPTwistingCalmSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private float timerSameDirectionMovement;
    private float directionChangeRate;
    private float frequency;
    private float magnitude;


    //CONSTRUCTOR
    public MPTwistingCalm(MPTwistingCalmSO inputTemplate)
    {
        this.template = inputTemplate;
        this.timerSameDirectionMovement = template.TimerSameDirectionMovement;
        this.directionChangeRate = template.DirectionChangeRate;
        this.frequency = template.Frequency;
        this.magnitude = template.Magnitude;
    }

    ///TEMPLATE
    public override MPAbstractParentSO Template() => template;


    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        Vector3 result = interestedCow.MovementDirection;

        if (directionChangeRate <= 0.0f)
        {
            directionChangeRate = template.DirectionChangeRate;

            if (result == Vector3.zero) 
                result = UtilsRadius.RandomPositionOnCircleRadius(1);

            Vector3 crossProduct = Vector3.Cross(result, interestedCow.transform.up);

            result = interestedCow.MovementDirection + magnitude * Mathf.Sin(Time.time * frequency) * crossProduct;
        }

        if (timerSameDirectionMovement <= 0.0f)
        {
            result = UtilsRadius.RandomPositionOnCircleRadius(1).normalized;
            ResetSameDirectionTimer();
        }

        return result.normalized;
    }

    public override void ResetTimers()
    {
        //CAN'T USE IT HERE
    }


    private void ResetSameDirectionTimer()
    {
        timerSameDirectionMovement = template.TimerSameDirectionMovement;
    }

    public override void UpdateTimers(float delta)
    {
        timerSameDirectionMovement -= delta;
        directionChangeRate -= delta;
    }
}
