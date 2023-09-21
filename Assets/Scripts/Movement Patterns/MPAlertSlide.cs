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
        Vector3 menacePosition = GameController.Instance.FindUFOAnywhere().GetPositionXZ();
        Vector3 desiredDirection = interestedCow.transform.position - menacePosition;

        //USE CowMovement OR Cow OR SOME OTHER SCRIPT TO DETECT IF A COLLISION HAPPENED, AND IF IT DID, USE IT TO CHANGE DIRECTION (SHOULD BOUNCE)

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
