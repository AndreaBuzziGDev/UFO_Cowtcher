using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPKowbraCalm : AbstractMovementPattern
{
    //DATA
    ///TEMPLATE
    private readonly MPKowbraCalmSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private float timerSameDirectionMovement;
    private float directionChangeRate;
    private float frequency;
    private float magnitude;


    //CONSTRUCTOR
    public MPKowbraCalm(MPKowbraCalmSO inputTemplate)
    {
        this.template = inputTemplate;
        this.timerSameDirectionMovement = template.TimerSameDirectionMovement;
        this.directionChangeRate = template.DirectionChangeRate;
        this.frequency = template.Frequency;
        this.magnitude = template.Magnitude;
    }

    ///TEMPLATE
    public override IMovementPattern Template() => template;


    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        Vector3 result = interestedCow.MovementDirection;

        if (directionChangeRate <= 0.0f)
        {
            ResetChageRateTimer();

            Vector3 crossProduct = Vector3.Cross(interestedCow.MovementDirection, interestedCow.transform.up);

            result = interestedCow.MovementDirection + magnitude * Mathf.Sin(Time.time * frequency) * crossProduct;
        }

        if (timerSameDirectionMovement <= 0.0f)
        {
            result = UtilsRadius.Vector3OnUnitCircle(1).normalized;
            ResetSameDirectionTimer();
        }

        return result.normalized;
    }

    public override void ResetTimers()
    {
        //CAN'T USE IT HERE
    }

    private void ResetChageRateTimer()
    {
        directionChangeRate = template.DirectionChangeRate;
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
