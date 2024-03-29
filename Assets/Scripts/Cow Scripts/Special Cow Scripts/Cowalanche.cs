using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowalanche : CowSpecialScript
{
    //DATA
    [SerializeField] private float avalancheDuration = 5.0f;
    [SerializeField] [Range(0, 100)] private float cowSpeedIncreasePercent = 50;
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
            {
                if (!GlobalEffectAvalanche.Instance.IsAvalanche)
                    specialEffectActivationTimer -= Time.fixedDeltaTime;
            }
            else
            {
                specialEffectActivationTimer = specialEffectActivationTimerMax;

                //SPECIAL EFFECT - APPLY STUN
                ApplyAvalanche(this.avalancheDuration, this.cowSpeedIncreasePercent);
            }
        }
    }




    //FUNCTIONALITIES
    public static void ApplyAvalanche(float avalancheDuration, float speedBonusPercent)
    {
        //ACCELERATE INTENDED COWS
        GlobalEffectAvalanche.Instance.ApplyAvalanche(avalancheDuration, speedBonusPercent);
        //TODO: SHOULD SLOW DOWN UFO

        //playerController.ApplyStun(this.stunDuration);
        UIController.Instance.IGPanel.DebuffPanel.fadeToTransparent = true;

        //TODO: DO SOME VISUAL EFFECTS ON THE COW?

    }

}