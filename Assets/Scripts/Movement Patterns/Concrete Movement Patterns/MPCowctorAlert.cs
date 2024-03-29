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
    public override MPAbstractParentSO Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        Vector3 result;

        float randomChance = Random.Range(0, template.timerSameDirectionMovement - MinDirectionPersistenceSlider);
        Debug.Log("MinDirectionPersistenceSlider: " + MinDirectionPersistenceSlider);
        Debug.Log("timerSameDirectionMovement: " + timerSameDirectionMovement);
        Debug.Log("randomChance: " + randomChance);

        if (timerSameDirectionMovement > randomChance)
        {
            result = interestedCow.MovementDirection;
        }
        else 
        {
            result = UtilsRadius.RandomPositionOnCircleRadius(1).normalized;
            ResetTimers();
        }
        Debug.Log("result: " + result);

        return result.normalized;

    }

    public override Vector3 ManagePanic(CowMovement myCow)
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

