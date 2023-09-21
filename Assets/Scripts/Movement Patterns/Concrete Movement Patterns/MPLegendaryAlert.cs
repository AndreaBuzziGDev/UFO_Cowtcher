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

        //TODO: DEBUFF UFO WITH "STUN" FOR 1 SECOND EVERY 10 SECONDS
        //TODO: THIS NEEDS TO BE REWORKED - ANOTHER SCRIPT WILL CARRY ON THE WORK NEEDED FOR THIS TO OPERATE INDEPENDENTLY FROM EACH LEGENDARY COW
        if (timerToPlayerStun <= 0.0f)
        {
            PlayerController pc = GameController.Instance.FindPlayerAnywhere();

            //STUN IF WITHIN RADIUS
            Vector3 cowPos = myCowMovement.transform.position;
            Vector3 baseUFOPos = new Vector3(pc.transform.position.x, 0, pc.transform.position.z);//TODO: THIS IS USED OFTEN. EXPORT AS FUNCTIONALITY/UTILITY?
            if ((cowPos-baseUFOPos).magnitude < myCowMovement.CowScript.AlertRadius )
            {
                pc.ApplyStun(this.stunDuration);
                UIController.Instance.IGPanel.DebuffPanel.fadeToTransparent = true;
                  
            }
            ResetTimers();
        }


        return desiredDirection.normalized;
    }

    public override Vector3 ManagePanic(CowMovement myCow)
    {
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
