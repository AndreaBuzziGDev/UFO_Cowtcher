using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPLegendaryAlert : AbstractMovementAlert
{
    //DATA
    ///TEMPLATE
    private readonly MPLegendaryAlertSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private float timerToPlayerStun = 10.0f;
    private float stunDuration = 1.0f;


    //CONSTRUCTOR
    public MPLegendaryAlert(MPLegendaryAlertSO inputTemplate)
    {
        this.template = inputTemplate;
        this.stunDuration = template.stunDuration;
        ResetTimers();
    }


    ///TEMPLATE
    public override MPAbstractParentSO Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement myCowMovement)
    {
        Vector3 menacePosition = GameController.Instance.FindUFOAnywhere().GetPositionXZ();
        Vector3 desiredDirection = myCowMovement.transform.position - menacePosition;

        return desiredDirection.normalized;
    }

    public override Vector3 ManagePanic(CowMovement myCow)
    {
        //LEGENDARY COWS RUN 10% FASTER WHEN IN PANIC
        return 1.1f * ManageMovement(myCow);
    }

    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        this.timerToPlayerStun -= delta;
    }
    public override void ResetTimers()
    {
        this.timerToPlayerStun = 10.0f;
    }
}
