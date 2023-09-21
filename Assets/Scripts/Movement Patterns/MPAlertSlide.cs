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
    public override MPAbstractParentSO Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        //USE interestedCow.CowScript TO DETECT IF IT HIT SOMETHING

        return Vector3.zero;
    }

    public override Vector3 ManagePanic(CowMovement myCow)
    {
        if (CowHideoutHelper.ShouldRunForHideout(myCow.CowScript))
            return CowHideoutHelper.HideoutDirection(myCow.CowScript).normalized;
        else
            return ManageMovement(myCow);
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
