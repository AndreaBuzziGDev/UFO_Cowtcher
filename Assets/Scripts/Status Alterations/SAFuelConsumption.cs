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

    UFO pc;

    ///TEMPLATE
    SAFuelConsumptionSO template;


    //CONSTRUCTOR
    public SAFuelConsumption(SAFuelConsumptionSO inputTemplate)
    {
        this.template = inputTemplate;
        this.type = template.buffType;//TODO: IMPLEMENT THIS
        this.buffDuration = template.buffDuration;

        pc = GameController.Instance.FindUFOAnywhere();
    }

    //METHODS
    ///TEMPLATE
    public override SAAbstractSO Template() => template;

    ///BUFF
    public override void ApplyBuff()
    {
        pc.ChangeFuelConsumptionMultiplier(this.consumptionIncrease);
    }

    public override void ExpireBuff()
    {
        pc.ChangeFuelConsumptionMultiplier(0);
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
