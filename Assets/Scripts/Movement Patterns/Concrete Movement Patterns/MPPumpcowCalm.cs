using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPPumpcowCalm : AbstractMovementPattern
{
    //NB: WON'T USE THIS.


    //DATA
    ///TEMPLATE
    private readonly MPPumpcowCalmSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private float dashSpeed;
    private float dashDuration;


    //CONSTRUCTOR
    public MPPumpcowCalm(MPPumpcowCalmSO inputTemplate)
    {
        this.template = inputTemplate;
        this.dashSpeed = template.DashSpeed;
        this.dashDuration = template.DashDuration;
    }

    ///TEMPLATE
    public override IMovementPattern Template() => template;


    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        Vector3 result = interestedCow.MovementDirection;

        if (dashDuration <= 0f)
        {
            ResetTimers();
            result = UtilsRadius.RandomPositionOnCircleRadius(1);
        }

        return result.normalized * dashSpeed * dashDuration;
    }

    //METHODS
    public override void ResetTimers()
    {
        this.dashDuration = template.DashDuration;
    }

    public override void UpdateTimers(float delta)
    {
        this.dashDuration -= delta;
    }
}
