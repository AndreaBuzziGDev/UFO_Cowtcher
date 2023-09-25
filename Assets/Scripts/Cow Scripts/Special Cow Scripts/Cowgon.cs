using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowgon : CowSpecialScript
{
    //DATA
    [SerializeField] private float stunDuration = 1.0f;
    [SerializeField] private float specialEffectActivationTimerMax = 10.0f;
    private float specialEffectActivationTimer;

    ///TECHNICAL DATA
    private UFO playerUFO;
    private PlayerController playerController;



    //METHODS
    private void Start()
    {
        playerUFO = GameController.Instance.FindUFOAnywhere();
        playerController = GameController.Instance.FindPlayerAnywhere();
    }

    //ABSTRACT CONCRETIZATION
    protected override void HandleDedicatedBehaviour()
    {
        //IF WITHIN ALERT RADIUS
        if ((myCow.transform.position - playerUFO.GetPositionXZ()).magnitude < myCow.AlertRadius)
        {
            //HANDLE A TIMER
            if (specialEffectActivationTimer > 0)
                specialEffectActivationTimer -= Time.fixedDeltaTime;
            else
            {
                specialEffectActivationTimer = specialEffectActivationTimerMax;

                //SPECIAL EFFECT - APPLY STUN
                ApplyStun();
            }
        }
    }


    protected override void DisableDedicatedBehaviour()
    {
        //TODO: CHECK IF IT NEEDS IMPLEMENTATION

    }

    //FUNCTIONALITIES
    public void ApplyStun()
    {
        playerController.ApplyStun(this.stunDuration);
        UIController.Instance.IGPanel.DebuffPanel.fadeToTransparent = true;
    }

}
