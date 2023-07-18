using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCowctorAlert : AbstractMovementAlert
{
    //DATA
    ///TEMPLATE
    private readonly MPCowctorAlertSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    [SerializeField] private float timerSameDirectionMovement;
    [SerializeField] private float MinDirectionPersistenceSlider;



    //CONSTRUCTOR
    public MPCowctorAlert(MPCowctorAlertSO inputTemplate)
    {
        this.template = inputTemplate;
        this.MinDirectionPersistenceSlider = template.MinDirectionPersistenceSlider;
    }

    ///TEMPLATE
    public override IMovementPattern Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(Cow interestedCow)
    {
        Vector3 result;

        float randomChance = Random.Range(0, timerSameDirectionMovement - MinDirectionPersistenceSlider);
        if (timerSameDirectionMovement > randomChance)
        {
            result = interestedCow.MovementDirection;
        }
        else 
        {
            result = UtilsRadius.Vector3OnUnitCircle(1).normalized;
            ResetTimers();
        }

        return result.normalized;

    }

    public override Vector3 ManagePanic(Cow myCow)
    {
        //TODO: IMPLEMENT SO THAT COW WILL RANDOMLY DECIDE ONE DIRECTION AND KEEP IT
        //NB: COULD BE A "FLEE DIRECTION" VECTOR THAT IS HANDLED BY THE ManageMovement Alert CODE
        //GetFleeFromMap();

        return myCow.MovementDirection.normalized;//WITH THIS IMPLEMENTATION, THEY SIMPLY KEEP THE LAST DIRECTION
    }

    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        this.timerSameDirectionMovement -= delta;
    }
    public override void ResetTimers()
    {
        this.timerSameDirectionMovement = template.timerSameDirectionMovement;
    }


}

