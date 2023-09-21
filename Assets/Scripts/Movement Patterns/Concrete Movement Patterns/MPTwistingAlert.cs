using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPTwistingAlert : AbstractMovementAlert
{
    //DATA
    ///TEMPLATE
    private readonly MPTwistingAlertSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private float directionChangeRate;
    private float frequency;
    private float magnitude;


    //CONSTRUCTOR
    public MPTwistingAlert(MPTwistingAlertSO inputTemplate)
    {
        this.template = inputTemplate;
        this.directionChangeRate = template.DirectionChangeRate;
        this.frequency = template.Frequency;
        this.magnitude = template.Magnitude;
        ResetTimers();
    }


    ///TEMPLATE
    public override MPAbstractParentSO Template() => template;


    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        Vector3 alertDirection = interestedCow.transform.position - GameController.Instance.FindUFOAnywhere().GetPositionXZ();

        if (directionChangeRate <= 0.0f)
        {
            ResetTimers();
            Vector3 crossProduct = Vector3.Cross(alertDirection, interestedCow.transform.up);

            alertDirection = alertDirection + magnitude * Mathf.Sin(Time.time * frequency) * crossProduct;
        }

        return alertDirection.normalized;
    }

    public override Vector3 ManagePanic(CowMovement myCow)
    {

        if (CowHideoutHelper.ShouldRunForHideout(myCow.CowScript))
        {
            Vector3 hideoutDirection = CowHideoutHelper.HideoutDirection(myCow.CowScript).normalized;

            if (directionChangeRate <= 0.0f)
            {
                ResetTimers();
                Vector3 crossProduct = Vector3.Cross(hideoutDirection, myCow.transform.up);

                hideoutDirection = myCow.MovementDirection + magnitude * Mathf.Sin(Time.time * frequency) * crossProduct;
            }

            return hideoutDirection.normalized;
        }
        else
            return ManageMovement(myCow);

    }

    public override void ResetTimers()
    {
        directionChangeRate = template.DirectionChangeRate;
    }

    public override void UpdateTimers(float delta)
    {
        directionChangeRate -= delta;
    }
}
