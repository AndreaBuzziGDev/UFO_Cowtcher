using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowtchman : CowSpecialScript
{
    //DATA
    [SerializeField] private float curseDuration = 5.0f;
    [SerializeField] private float specialEffectActivationTimerMax = 5.0f;
    private float specialEffectActivationTimer;

    ///TECHNICAL DATA
    private UFO playerUFO;
    private PlayerController playerController;



    //METHODS
    // Start is called before the first frame update
    void Start()
    {
        //REFERENCES
        playerUFO = GameController.Instance.FindUFOAnywhere();
        playerController = GameController.Instance.FindPlayerAnywhere();

        //
        specialEffectActivationTimer = 0.1f;//THE CURSE PICKS UP IMMEDIATELY AFTER ENTERING ALERT RADIUS
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
                ApplyCurse(this.curseDuration);
            }
        }
    }


    protected override void DisableDedicatedBehaviour()
    {
        //TODO: CHECK IF IT NEEDS IMPLEMENTATION

    }

    //FUNCTIONALITIES
    public static void ApplyCurse(float stunDuration)
    {
        //TODO: IMPLEMENT

        //APPLY CURSE TO PLAYER (FIRE EVENT INSTEAD?)

        //USE COROUTINE TO HANDLE THE DISAPPEARANCE OF COWS?

        //playerController.ApplyStun(this.stunDuration);
        UIController.Instance.IGPanel.DebuffPanel.fadeToTransparent = true;

        //TODO: DO SOME VISUAL EFFECTS ON THE COW?

    }



    //COROUTINE
    //TODO: SHOULD THIS BE MOVED IN THE MONOSINGLETON GLOBAL ITEM CONTROLLING THE GAMEPLAY?


}
