using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SACaptureRadius : SAAbstract
{
    //DATA
    ///USEFUL BUFF DATA
    public float buffDuration;
    public float captureRadiusIncrease;
    Abductor abductorScriptReference;

    ///TEMPLATE
    SACaptureRadiusSO template;



    //CONSTRUCTOR
    public SACaptureRadius(SACaptureRadiusSO inputTemplate)
    {
        this.template = inputTemplate;
        this.type = template.buffType;
        this.buffDuration = template.buffDuration;
        this.captureRadiusIncrease = template.captureRadiusIncrease;
        abductorScriptReference = GameController.Instance.FindAbductorAnywhere();
    }

    //METHODS
    ///TEMPLATE
    public override SAAbstractSO Template() => template;

    ///BUFF
    public override void ApplyBuff()
    {
        abductorScriptReference.SetCaptureRadiusBoost(this.captureRadiusIncrease);
        UIController.Instance.IGPanel.BuffPanel.ActivateSpeedBoost();
    }

    public override void ExpireBuff()
    {
        abductorScriptReference.SetCaptureRadiusBoost(0);
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
