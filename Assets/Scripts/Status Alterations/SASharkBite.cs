using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SASharkBite : SAAbstract
{
    //DATA
    ///USEFUL BUFF DATA
    public float currentScoreLoss;
    public bool hasExpired = false;

    PlayerController pc;

    ///TEMPLATE
    SASharkBiteSO template;


    //EVENTS
    public static event EventHandler<SharkBiteEventArgs> SharkBite;




    //CONSTRUCTOR
    public SASharkBite(SASharkBiteSO inputTemplate)
    {
        this.template = inputTemplate;
        this.type = template.buffType;
        float currentScoreLoss = 20.0f;

        pc = GameController.Instance.FindPlayerAnywhere();
    }

    //METHODS
    ///TEMPLATE
    public override SAAbstractSO Template() => template;

    ///BUFF
    public override void ApplyBuff()
    {
        //FIRE EVENT
        SharkBiteEventArgs myEventArg = new SharkBiteEventArgs(this.currentScoreLoss);
        OnSharkBite(myEventArg);

        hasExpired = true;
    }

    public override void ExpireBuff()
    {
        //NOT NEEDED

    }



    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        //NOT NEEDED

    }
    public override bool IsStillRunning()
    {
        return !this.hasExpired;
    }




    //EVENT-FIRING METHOD
    private void OnSharkBite(SharkBiteEventArgs myEventArg)
    {
        // make a copy to be more thread-safe
        EventHandler<SharkBiteEventArgs> handler = SharkBite;

        if (handler != null)
        {
            // invoke the subscribed event-handler(s)
            handler(this, myEventArg);
        }
    }

}
