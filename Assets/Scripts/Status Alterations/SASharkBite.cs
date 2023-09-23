using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SASharkBite : SAAbstract
{
    //DATA
    ///USEFUL BUFF DATA
    public float currentScoreLoss;
    public bool hasExpired = false;

    PlayerController pc;

    ///TEMPLATE
    SASharkBiteSO template;


    ///EVENT
    



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
