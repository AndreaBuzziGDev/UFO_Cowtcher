using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPAlertTowardsUFO : AbstractMovementAlert
{
    //DATA
    ///TEMPLATE
    private readonly MPAlertTowardsUFOSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    //NON


    //CONSTRUCTOR
    public MPAlertTowardsUFO(MPAlertTowardsUFOSO inputTemplate)
    {
        this.template = inputTemplate;
    }


    ///TEMPLATE
    public override IMovementPattern Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(Cow interestedCow)
    {
        Vector3 ufoPos = GameController.Instance.FindUFOAnywhere().transform.position;
        Vector3 planeProjectedUfoPos = new Vector3(ufoPos.x, 0, ufoPos.z);


        return (planeProjectedUfoPos - interestedCow.transform.position);
    }

    public override Vector3 ManagePanic(Cow myCow)
    {
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
