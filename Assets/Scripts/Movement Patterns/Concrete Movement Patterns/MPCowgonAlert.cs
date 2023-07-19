using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCowgonAlert : AbstractMovementAlert
{
    //DATA
    ///TEMPLATE
    private readonly MPCowgonAlertSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private float timerToPlayerStun = 10.0f;
    private float stunDuration = 1.0f;


    //CONSTRUCTOR
    public MPCowgonAlert(MPCowgonAlertSO inputTemplate)
    {
        this.template = inputTemplate;
        this.stunDuration = template.stunDuration;
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

        //TODO: DEBUFF UFO WITH "STUN" FOR 1 SECOND EVERY 10 SECONDS
        if (timerToPlayerStun <= 0.0f)
        {
            PlayerController pc = GameController.Instance.FindPlayerAnywhere();

            //STUN IF WITHIN RADIUS
            Vector3 cowPos = interestedCow.transform.position;
            Vector3 baseUFOPos = new Vector3(pc.transform.position.x, 0, pc.transform.position.z);//TODO: THIS IS USED OFTEN. EXPORT AS FUNCTIONALITY/UTILITY?
            if ((cowPos-baseUFOPos).magnitude < interestedCow.AlertRadius )
            {
                pc.ApplyStun(this.stunDuration);
                UIController.Instance.IGPanel.DebuffPanel.fadeToTransparent = true;
                  
            }
            ResetTimers();
        }


        return vertLessDirection.normalized;
    }

    public override Vector3 ManagePanic(Cow myCow)
    {
        //TODO: IMPLEMENT SO THAT COW WILL RANDOMLY DECIDE ONE DIRECTION AND KEEP IT
        //NB: COULD BE A "FLEE DIRECTION" VECTOR THAT IS HANDLED BY THE ManageMovement Alert CODE
        //GetFleeFromMap();

        return myCow.MovementDirection.normalized;//WITH THIS IMPLEMENTATION, THEY SIMPLY KEEP THE LAST DIRECTION AND FLEE
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
