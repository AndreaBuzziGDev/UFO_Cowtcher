using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPAlertSlide : AbstractMovementAlert
{
    //DATA
    ///TEMPLATE
    private readonly MPAlertSlideSO template;

    //CONSTRUCTOR
    public MPAlertSlide(MPAlertSlideSO inputTemplate)
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
