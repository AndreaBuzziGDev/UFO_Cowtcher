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
    public override Vector3 ManageMovement(Cow interestedCow)
    {
        Vector3 menacePosition = GameController.Instance.FindUFOAnywhere().transform.position;
        Vector3 desiredDirection = interestedCow.transform.position - menacePosition;
        Vector3 vertLessDirection = new Vector3(desiredDirection.x, 0, desiredDirection.z);

        return vertLessDirection.normalized;
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
