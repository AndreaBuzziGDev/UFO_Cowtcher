using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPPumpcowCalm : AbstractMovementPattern
{
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


    public override Vector3 ManageMovement(Cow interestedCow)
    {
        Vector3 result = interestedCow.MovementDirection;

        if (dashDuration <= 0f)
        {
            ResetTimers();
            result = UtilsRadius.Vector3OnUnitCircle(dashSpeed);
        }

        return result * dashDuration;
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
