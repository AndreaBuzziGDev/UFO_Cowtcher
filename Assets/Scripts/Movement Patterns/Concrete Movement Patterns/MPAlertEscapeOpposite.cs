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
    public override IMovementPattern Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        Vector3 menacePosition = GameController.Instance.FindUFOAnywhere().transform.position;
        Vector3 desiredDirection = interestedCow.transform.position - menacePosition;
        Vector3 vertLessDirection = new Vector3(desiredDirection.x, 0, desiredDirection.z);

        return vertLessDirection.normalized;
    }

    public override Vector3 ManagePanic(CowMovement myCow)
    {
        if (CowHideoutHelper.ShouldRunForHideout(myCow.CowScript))
        {
            //
            return CowHideoutHelper.HideoutDirection(myCow.CowScript).normalized;
        }
        else
        {
            return ManageMovement(myCow);
        }
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
