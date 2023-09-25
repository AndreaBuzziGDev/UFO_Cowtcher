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



    //METHODS
    private void Start()
    {
        //REFERENCES
        playerUFO = GameController.Instance.FindUFOAnywhere();

        //
        specialEffectActivationTimer = specialEffectActivationTimerMax;
    }

    //ABSTRACT CONCRETIZATION

    ///BEHAVIOUR
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
                ApplySpecialEffect(this.stunDuration);
            }
        }
    }


    protected override void DisableDedicatedBehaviour()
    {
        //TODO: CHECK IF IT NEEDS IMPLEMENTATION

    }

    //FUNCTIONALITIES
    public static void ApplySpecialEffect(float stunDuration)
    {
        GameController.Instance.FindPlayerAnywhere().ApplyStun(stunDuration);
        UIController.Instance.IGPanel.DebuffPanel.fadeToTransparent = true;

        //TODO: DO SOME VISUAL EFFECTS ON THE COW?

    }

}
