using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPAlertRandomDirection : AbstractMovementAlert
{
    //DATA
    ///TEMPLATE
    private readonly MPAlertRandomDirectionSO template;

    //CONSTRUCTOR
    public MPAlertRandomDirection(MPAlertRandomDirectionSO inputTemplate)
    {
        this.template = inputTemplate;
    }


    ///TEMPLATE
    public override MPAbstractParentSO Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        return Vector3.zero;
    }

    public override Vector3 ManagePanic(CowMovement myCow)
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
