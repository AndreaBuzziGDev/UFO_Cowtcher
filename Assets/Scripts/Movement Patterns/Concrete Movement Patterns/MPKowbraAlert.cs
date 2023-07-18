using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPKowbraAlert : AbstractMovementAlert
{
    //DATA
    ///TEMPLATE
    private readonly MPKowbraAlertSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private float directionChangeRate;
    private float frequency;
    private float magnitude;


    //CONSTRUCTOR
    public MPKowbraAlert(MPKowbraAlertSO inputTemplate)
    {
        this.template = inputTemplate;
        this.directionChangeRate = template.DirectionChangeRate;
        this.frequency = template.Frequency;
        this.magnitude = template.Magnitude;
        ResetTimers();
    }


    ///TEMPLATE
    public override IMovementPattern Template() => template;


    public override Vector3 ManageMovement(Cow interestedCow)
    {

        Vector3 menacePosition = GameController.Instance.FindUFOAnywhere().transform.position;
        Vector3 desiredDirection = interestedCow.transform.position - menacePosition;
        Vector3 alertDirection = new Vector3(desiredDirection.x, 0, desiredDirection.z);

        if (directionChangeRate <= 0.0f)
        {
            ResetTimers();
            Vector3 crossProduct = Vector3.Cross(alertDirection, interestedCow.transform.up);

            alertDirection = interestedCow.MovementDirection + magnitude * Mathf.Sin(Time.time * frequency) * crossProduct;
        }

        return alertDirection.normalized;
    }

    public override Vector3 ManagePanic(Cow myCow)
    {
        Hideout targetHideout = myCow.TargetHideout;
        Vector3 hideoutDirection = targetHideout.transform.position - myCow.transform.position;

        //TODO: THIS CODE WILL EVENTUALLY BE MOVED ELSEWHERE
        UFO menace = GameController.Instance.FindUFOAnywhere();
        Vector3 flatUfoVector = new Vector3(menace.transform.position.x, targetHideout.transform.position.y, menace.transform.position.z);
        Vector3 ufoHideoutVector = targetHideout.transform.position - flatUfoVector;

        Debug.Log("hideoutDirection: " + hideoutDirection);
        Debug.Log("ufoHideoutVector: " + ufoHideoutVector);

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
