using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAFuelConsumption : SAAbstract
{
    //DATA
    ///USEFUL BUFF DATA
    public SAAbstract.EBuffType type;
    public float buffDuration;
    public float consumptionIncrease;
    public bool hasExpired = false;

    PlayerController pc;

    ///TEMPLATE
    SAFuelConsumptionSO template;


    //CONSTRUCTOR
    public SAFuelConsumption(SAFuelConsumptionSO inputTemplate)
    {
        this.template = inputTemplate;
        this.type = template.buffType;//TODO: IMPLEMENT THIS
        this.buffDuration = template.buffDuration;

        pc = GameController.Instance.FindPlayerAnywhere();
    }

    //METHODS
    ///TEMPLATE
    public override SAAbstractSO Template() => template;

    ///BUFF
    public override void ApplyBuff()
    {
        //TODO: IMPLEMENT

        hasExpired = true;
    }

    public override void ExpireBuff()
    {
        //TODO: IMPLEMENT

    }



    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        //TODO: IMPLEMENT

    }
    public override bool IsStillRunning()
    {
        //TODO: IMPLEMENT/UPDATE
        return !this.hasExpired;
    }

}
