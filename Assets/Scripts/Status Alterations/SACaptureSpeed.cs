using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SACaptureSpeed : SAAbstract
{
    //DATA
    ///USEFUL BUFF DATA
    public float buffDuration;
    public float captureSpeedIntensity;
    public bool isDebuff;
    PlayerController pc;

    ///TEMPLATE
    SACaptureSpeedSO template;



    //CONSTRUCTOR
    public SACaptureSpeed(SACaptureSpeedSO inputTemplate)
    {
        this.template = inputTemplate;
        this.type = template.buffType;
        this.buffDuration = template.buffDuration;
        this.captureSpeedIntensity = template.captureSpeedIntensity;
        this.isDebuff = template.isDebuff;
        pc = GameController.Instance.FindPlayerAnywhere();
    }

    //METHODS
    ///TEMPLATE
    public override SAAbstractSO Template() => template;

    ///BUFF
    public override void ApplyBuff()
    {
        /*
        if (isDebuff) pc.SetBonusMovSpeed(-this.captureSpeedIntensity);
        else pc.SetBonusMovSpeed(this.captureSpeedIntensity);
        UIController.Instance.IGPanel.BuffPanel.ActivateSpeedBoost();
        */
    }

    public override void ExpireBuff()
    {
        /*
        pc.SetBonusMovSpeed(0);
        UIController.Instance.IGPanel.BuffPanel.DeactivateSpeedBoost();
        */
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
