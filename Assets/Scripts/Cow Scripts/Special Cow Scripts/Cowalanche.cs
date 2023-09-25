using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowalanche : CowSpecialScript
{
    //DATA
    [SerializeField] private float avalancheDuration = 5.0f;
    [SerializeField] [Range(0, 100)] private float cowSpeedIncreasePercent = 50;
    [SerializeField] private float specialEffectActivationTimerMax = 5.0f;//TODO: THIS IS THE DELAY, SHOULD ALSO USE A DIFFERENT ITEM TO IMPLEMENT THE SUBSEQUENT DELAYS?
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
        specialEffectActivationTimer = 0.1f;//AVALANCHE STARTS IMMEDIATELY
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
                ApplySpecialEffect(this.avalancheDuration);
            }
        }
    }


    protected override void DisableDedicatedBehaviour()
    {
        //TODO: CHECK IF IT NEEDS IMPLEMENTATION

    }

    //FUNCTIONALITIES
    public static void ApplySpecialEffect(float avalancheDuration)
    {
        //TODO: IMPLEMENT

        //APPLY AVALANCHE TO UFO (FIRE EVENT?)
        //APPLY AVALANCHE TO COWS (FIRE EVENT?)

        //playerController.ApplyStun(this.stunDuration);
        UIController.Instance.IGPanel.DebuffPanel.fadeToTransparent = true;

        //TODO: DO SOME VISUAL EFFECTS ON THE COW?

    }

}