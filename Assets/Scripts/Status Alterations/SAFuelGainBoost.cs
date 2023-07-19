using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAFuelGainBoost : SAAbstract
{
    //DATA
    ///USEFUL BUFF DATA
    public float buffDuration;
    public float additionalFuelGainPercent;
    UFO pc;

    ///TEMPLATE
    SAFuelGainBoostSO template;



    //CONSTRUCTOR
    public SAFuelGainBoost(SAFuelGainBoostSO inputTemplate)
    {
        this.template = inputTemplate;
        this.type = template.buffType;
        this.buffDuration = template.buffDuration;
        this.additionalFuelGainPercent = template.additionalFuelGainPercent;
        pc = GameController.Instance.FindUFOAnywhere();
    }

    //METHODS
    ///TEMPLATE
    public override SAAbstractSO Template() => template;

    ///BUFF
    public override void ApplyBuff()
    {
        pc.ChangeFuelBoostMultiplier(this.additionalFuelGainPercent);
    }

    public override void ExpireBuff()
    {
        pc.ChangeFuelBoostMultiplier(-this.additionalFuelGainPercent);
    }



    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        this.buffDuration -= delta;
    }
    public override bool IsStillRunning()
    {
        return (this.buffDuration > 0);
    }
}
