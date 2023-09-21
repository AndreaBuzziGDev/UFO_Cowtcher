using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPPumpcowAlert : AbstractMovementAlert
{
    //NB: WON'T USE THIS.


    //DATA
    ///TEMPLATE
    private readonly MPPumpcowAlertSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private float dashSpeed;
    private float dashDuration;



    //CONSTRUCTOR
    public MPPumpcowAlert(MPPumpcowAlertSO inputTemplate)
    {
        this.template = inputTemplate;
        this.dashSpeed = template.DashSpeed;
        this.dashDuration = template.DashDuration;
        ResetTimers();
    }


    ///TEMPLATE
    public override IMovementPattern Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        Vector3 menacePosition = GameController.Instance.FindUFOAnywhere().GetPositionXZ();
        Vector3 desiredDirection = interestedCow.transform.position - menacePosition;

        if (dashDuration <= 0f)
        {
            ResetTimers();
        }

        return desiredDirection.normalized * dashSpeed * dashDuration;
    }

    public override Vector3 ManagePanic(CowMovement myCow)
    {

        Hideout targetHideout = myCow.CowScript.TargetHideout;
        Vector3 hideoutDirection = targetHideout.transform.position - myCow.transform.position;

        //TODO: THIS CODE WILL EVENTUALLY BE MOVED ELSEWHERE
        Vector3 flatUfoVector = GameController.Instance.FindUFOAnywhere().GetPositionXZ();
        Vector3 ufoHideoutVector = targetHideout.transform.position - flatUfoVector;

        Debug.Log("hideoutDirection: " + hideoutDirection);
        Debug.Log("ufoHideoutVector: " + ufoHideoutVector);

        if (ufoHideoutVector.magnitude <= hideoutDirection.magnitude)
        {
            Debug.Log("UFO IS CLOSER TO HIDEOUT THAN COW!");
            return ManageMovement(myCow);
        }

        if (dashDuration <= 0f)
        {
            ResetTimers();
        }

        return hideoutDirection.normalized * dashSpeed * dashDuration;
    }

    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        this.dashDuration -= delta;
    }

    public override void ResetTimers()
    {
        this.dashDuration = template.DashDuration;

    }
}
