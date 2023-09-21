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
        Vector3 menacePosition = GameController.Instance.FindUFOAnywhere().GetPositionXZ();
        Vector3 alertDirection = interestedCow.transform.position - menacePosition;

        if (directionChangeRate <= 0.0f)
        {
            ResetTimers();
            Vector3 crossProduct = Vector3.Cross(alertDirection, interestedCow.transform.up);

            alertDirection = interestedCow.MovementDirection + magnitude * Mathf.Sin(Time.time * frequency) * crossProduct;
        }

        return alertDirection.normalized;
    }

    public override Vector3 ManagePanic(CowMovement myCow)
    {
        Hideout targetHideout = myCow.CowScript.TargetHideout;
        Vector3 hideoutDirection = targetHideout.transform.position - myCow.transform.position;

        if (directionChangeRate <= 0.0f)
        {
            ResetTimers();
            Vector3 crossProduct = Vector3.Cross(hideoutDirection.normalized, myCow.transform.up);

            hideoutDirection = myCow.MovementDirection + (magnitude * 2) * Mathf.Sin(Time.time * frequency) * crossProduct;
        }

        //TODO: THIS CODE WILL EVENTUALLY BE MOVED ELSEWHERE
        UFO menace = GameController.Instance.FindUFOAnywhere();
        Vector3 flatUfoVector = new Vector3(menace.transform.position.x, targetHideout.transform.position.y, menace.transform.position.z);
        Vector3 ufoHideoutVector = targetHideout.transform.position - flatUfoVector;

        //Debug.Log("hideoutDirection: " + hideoutDirection);
        //Debug.Log("ufoHideoutVector: " + ufoHideoutVector);

        if (ufoHideoutVector.magnitude <= hideoutDirection.magnitude)
        {
            Debug.Log("UFO IS CLOSER TO HIDEOUT THAN COW!");
            return ManageMovement(myCow);
        }

        return hideoutDirection.normalized;
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
