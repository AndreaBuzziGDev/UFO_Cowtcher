using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAFuelLossInstant : SAAbstract
{
    //DATA
    ///USEFUL BUFF DATA
    public float currentFuelPercentLoss;
    public bool hasExpired = false;

    ///TEMPLATE
    SAFuelLossInstantSO template;



    //CONSTRUCTOR
    public SAFuelLossInstant(SAFuelLossInstantSO inputTemplate)
    {
        this.template = inputTemplate;
        this.type = template.buffType;
        this.currentFuelPercentLoss = template.currentFuelPercentLoss;
    }

    //METHODS
    ///TEMPLATE
    public override SAAbstractSO Template() => template;

    ///BUFF
    public override void ApplyBuff()
    {
        UFO playerUFO = GameController.Instance.FindUFOAnywhere();
        
        float instantFuelLossPercent = (playerUFO.FuelAmount / 100) * currentFuelPercentLoss;
        playerUFO.ChangeFuel(-instantFuelLossPercent);

        this.hasExpired = true;
        UIController.Instance.IGPanel.BuffPanel.ActivateFuelLoss();

    }
    public override void ExpireBuff()
    {
        UIController.Instance.IGPanel.BuffPanel.DeactivateFuelLoss();
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
