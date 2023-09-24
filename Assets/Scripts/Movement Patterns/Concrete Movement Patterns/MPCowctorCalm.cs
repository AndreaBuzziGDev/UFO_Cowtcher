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
        this.accelerationMultiplier = template.accelerationMultiplier;
    }


    ///TEMPLATE
    public override MPAbstractParentSO Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        Vector3 result = interestedCow.MovementDirection;

        if (timerSameDirectionMovement <= 0.0f)
        {
            ResetTimers();

            result = UtilsRadius.RandomPositionOnCircleRadius(1).normalized;
        }

        //ADDED A MARGIN TO AVOID VECTOR 0 AS A RESULT
        float speedMultiplier = (template.TimerSameDirectionMovement + 0.25f) - timerSameDirectionMovement;
        result = accelerationMultiplier * speedMultiplier * result.normalized;

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
