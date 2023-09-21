using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPAlertTowardsUFO : AbstractMovementAlert
{
    //DATA
    ///TEMPLATE
    private readonly MPAlertTowardsUFOSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private float timerMoving;
    private float timerStill;
    private float randomizerSlider;



    //CONSTRUCTOR
    public MPAlertTowardsUFO(MPAlertTowardsUFOSO inputTemplate)
    {
        this.template = inputTemplate;
        this.timerMoving = inputTemplate.timerMoving;
        this.timerStill = inputTemplate.timerStill;
        this.randomizerSlider = inputTemplate.randomizerSlider;
    }


    ///TEMPLATE
    public override MPAbstractParentSO Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        if (timerMoving > 0)
        {
            Vector3 ufoPos = GameController.Instance.FindUFOAnywhere().transform.position;
            Vector3 planeProjectedUfoPos = new Vector3(ufoPos.x, 0, ufoPos.z);

            Vector3 intendedDirection = planeProjectedUfoPos - interestedCow.transform.position;
            if (intendedDirection.magnitude >= 0.1)
            {
                return (planeProjectedUfoPos - interestedCow.transform.position).normalized;
            }
            else
                return Vector3.zero;
        }
        else
            return Vector3.zero;
    }

    public override Vector3 ManagePanic(CowMovement myCow)
    {
        return ManageMovement(myCow);
    }

    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        if (timerMoving > 0) timerMoving -= delta;
        else if (timerStill > 0) timerStill -= delta;
        else ResetTimers();
    }
    public override void ResetTimers()
    {
        this.timerStill = template.timerStill + Random.Range(-0.5f, this.randomizerSlider);
        this.timerMoving = template.timerMoving;
    }
}
