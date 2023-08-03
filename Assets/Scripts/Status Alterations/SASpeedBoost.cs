using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SASpeedBoost : SAAbstract
{
    //DATA
    ///USEFUL BUFF DATA
    public float buffDuration;
    public float speedBoostIntensity;
    public bool isDebuff;
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
        this.isDebuff = template.isDebuff;
        pc = GameController.Instance.FindPlayerAnywhere();
    }

    //METHODS
    ///TEMPLATE
    public override SAAbstractSO Template() => template;

    ///BUFF
    public override void ApplyBuff()
    {
        if (isDebuff) pc.SetBonusMovSpeed(-this.speedBoostIntensity);
        else pc.SetBonusMovSpeed(this.speedBoostIntensity);
        UIController.Instance.IGPanel.BuffPanel.ActivateSpeedBoost();
    }

    public override void ExpireBuff()
    {
        pc.SetBonusMovSpeed(0);
        UIController.Instance.IGPanel.BuffPanel.DeactivateSpeedBoost();
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
