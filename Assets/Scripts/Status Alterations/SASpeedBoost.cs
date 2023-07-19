using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SASpeedBoost : SAAbstract
{
    //DATA
    ///USEFUL BUFF DATA
    public float buffDuration;
    public float speedBoostIntensity;

    ///TEMPLATE
    SASpeedBoostSO template;



    //CONSTRUCTOR
    public SASpeedBoost(SASpeedBoostSO inputTemplate)
    {
        this.template = inputTemplate;
        this.type = template.buffType;
        this.buffDuration = template.buffDuration;
        this.speedBoostIntensity = template.speedBoostIntensity;
    }

    //METHODS
    ///TEMPLATE
    public override SAAbstractSO Template() => template;

    ///BUFF
    public override void ApplyBuff()
    {
        if (IsStillRunning())
        {
            PlayerController pc = GameController.Instance.FindPlayerAnywhere();
            pc.SetBonusMovSpeed(this.speedBoostIntensity);
            BuffPanel buffpanel = UIController.Instance.IGPanel.BuffPanel.GetComponent<BuffPanel>();
            buffpanel.ActivateFuelBoost();
        }
        else
        {
            BuffPanel buffpanel = UIController.Instance.IGPanel.BuffPanel.GetComponent<BuffPanel>();
            buffpanel.DeActivateFuelBoost();
        }

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
