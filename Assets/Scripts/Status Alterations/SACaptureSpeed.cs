using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SACaptureSpeed : SAAbstract
{
    //DATA
    ///USEFUL BUFF DATA
    public float buffDuration;
    public float captureSpeedIntensity;
    Abductor abductorScriptReference;

    ///TEMPLATE
    SACaptureSpeedSO template;



    //CONSTRUCTOR
    public SACaptureSpeed(SACaptureSpeedSO inputTemplate)
    {
        this.template = inputTemplate;
        this.type = template.buffType;
        this.buffDuration = template.buffDuration;
        this.captureSpeedIntensity = template.captureSpeedIntensity; 
        abductorScriptReference = GameController.Instance.FindAbductorAnywhere();
    }

    //METHODS
    ///TEMPLATE
    public override SAAbstractSO Template() => template;

    ///BUFF
    public override void ApplyBuff()
    {
        abductorScriptReference.SetCaptureSpeedBoost(this.captureSpeedIntensity);
        UIController.Instance.IGPanel.BuffPanel.ActivateSpeedBoost();
        
    }

    public override void ExpireBuff()
    {
        abductorScriptReference.SetCaptureSpeedBoost(0);
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
