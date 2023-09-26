using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tulcu : CowSpecialScript
{
    //DATA
    [SerializeField] private float terrorDuration = 1.0f;
    [SerializeField] private int terrorIterations = 3;
    [SerializeField] private float subsequentApplicationDelay = 3.0f;

    [SerializeField] private float specialEffectActivationTimerMax = 0.1f;
    private float specialEffectActivationTimer;

    ///TECHNICAL DATA
    private UFO playerUFO;



    //METHODS
    // Start is called before the first frame update
    void Start()
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
            {
                if (!GlobalEffectTulcu.Instance.IsTerrorActive)
                    specialEffectActivationTimer -= Time.fixedDeltaTime;
            }
            else
            {
                specialEffectActivationTimer = specialEffectActivationTimerMax;

                //SPECIAL EFFECT - APPLY STUN
                ApplyTerror(this.terrorDuration, this.terrorIterations, this.subsequentApplicationDelay);
            }
        }
    }




    //FUNCTIONALITIES
    public static void ApplyTerror(float terrorDuration, int terrorIterations, float waveDelay)
    {
        GlobalEffectTulcu.Instance.ApplyTerror(terrorDuration, terrorIterations, waveDelay);

        //TODO: DO SOME VISUAL EFFECTS ON THE COW?

    }

}