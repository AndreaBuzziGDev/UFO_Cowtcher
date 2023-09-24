using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPAlertEscapeOpposite : AbstractMovementAlert
{
    //DATA
    ///TEMPLATE
    private readonly MPAlertEscapeOppositeSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    //NON


    //CONSTRUCTOR
    public MPAlertEscapeOpposite(MPAlertEscapeOppositeSO inputTemplate)
    {
        this.template = inputTemplate;
        ResetTimers();
    }


    ///TEMPLATE
    public override MPAbstractParentSO Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        Vector3 menacePosition = GameController.Instance.FindUFOAnywhere().GetPositionXZ();
        Vector3 desiredDirection = interestedCow.transform.position - menacePosition;

        return desiredDirection.normalized;
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
