using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SASpeedBoost : SAAbstract
{
    //DATA
    ///USEFUL BUFF DATA
    public float buffDuration;
    public float speedBoostIntensity;
    PlayerController pc;

    ///TEMPLATE
    SASpeedBoostSO template;



    //CONSTRUCTOR
    public SASpeedBoost(SASpeedBoostSO inputTemplate)
    {
        this.template = inputTemplate;
        this.type = template.buffType;
        this.buffDuration = template.buffDuration;
        this.speedBoostIntensity = template.speedBoostIntensity;
        pc = GameController.Instance.FindPlayerAnywhere();
    }

    //METHODS
    ///TEMPLATE
    public override SAAbstractSO Template() => template;

    ///BUFF
    public override void ApplyBuff()
    {
        if (IsStillRunning())
        {
            pc.SetBonusMovSpeed(this.speedBoostIntensity);
        }
    }

    public override void ExpireBuff()
    {
        pc.SetBonusMovSpeed(0);
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
