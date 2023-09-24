using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAFreeze : SAAbstract
{
    //DATA
    ///USEFUL BUFF DATA
    public float buffDuration;
    public bool hasExpired = false;

    PlayerController pc;

    ///TEMPLATE
    SAFreezeSO template;



    //CONSTRUCTOR
    public SAFreeze(SAFreezeSO inputTemplate)
    {
        this.template = inputTemplate;
        this.type = template.buffType;
        this.buffDuration = template.buffDuration;

        pc = GameController.Instance.FindPlayerAnywhere();
    }

    //METHODS
    ///TEMPLATE
    public override SAAbstractSO Template() => template;

    ///BUFF
    public override void ApplyBuff()
    {
        pc.ApplyFrozen(buffDuration);
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

}
