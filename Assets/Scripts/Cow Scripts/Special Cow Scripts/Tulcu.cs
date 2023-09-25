using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tulcu : CowSpecialScript
{
    //DATA
    [SerializeField] private float terrorDuration = 1.0f;
    [SerializeField] private float specialEffectActivationTimerMax = 3.0f;//TODO: THIS IS THE DELAY, SHOULD ALSO USE A DIFFERENT ITEM TO IMPLEMENT THE SUBSEQUENT DELAYS?
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
                ApplyTerror(this.terrorDuration);
            }
        }
    }


    protected override void DisableDedicatedBehaviour()
    {
        //TODO: CHECK IF IT NEEDS IMPLEMENTATION

    }

    //FUNCTIONALITIES
    public static void ApplyTerror(float terrorDuration)
    {
        //TODO: IMPLEMENT

        //APPLY TERROR TO PLAYER (FIRE EVENT?) - SHOULD IT BE PAIRED WITH A COROUTINE TO HANDLE RE-ITERATED TERROR?
        //APPLY TERROR TO COWS (FIRE EVENT?) - SHOULD IT BE PAIRED WITH A COROUTINE TO HANDLE RE-ITERATED TERROR?

        //playerController.ApplyStun(this.stunDuration);
        UIController.Instance.IGPanel.DebuffPanel.fadeToTransparent = true;

        //TODO: DO SOME VISUAL EFFECTS ON THE COW?

    }

}