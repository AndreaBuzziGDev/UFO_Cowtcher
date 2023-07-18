using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCowctorCalm : AbstractMovementPattern
{
    //DATA
    ///TEMPLATE
    private readonly MPCowctorCalmSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    [SerializeField] private float timerSameDirectionMovement;
    private float accelerationMultiplier;


    //CONSTRUCTOR
    public MPCowctorCalm(MPCowctorCalmSO inputTemplate)
    {
        this.template = inputTemplate;
        this.timerSameDirectionMovement = inputTemplate.TimerSameDirectionMovement;
        this.accelerationMultiplier = inputTemplate.accelerationMultiplier;
        ResetTimers();
    }


    ///TEMPLATE
    public override IMovementPattern Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(Cow interestedCow)
    {
        Vector3 result = interestedCow.MovementDirection;

        if (timerSameDirectionMovement <= 0.0f)
        {
            ResetTimers();
            result = accelerationMultiplier * UtilsRadius.Vector3OnUnitCircle(1).normalized;
        }
        float speedMultiplier = template.TimerSameDirectionMovement - timerSameDirectionMovement;
        result = accelerationMultiplier * speedMultiplier * result;

        return result;
    }

    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        timerSameDirectionMovement -= delta;

    }
    public override void ResetTimers()
    {
        timerSameDirectionMovement = template.TimerSameDirectionMovement;

    }

}
