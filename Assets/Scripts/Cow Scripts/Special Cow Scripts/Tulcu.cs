using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tulcu : CowSpecialScript
{
    //DATA
    [SerializeField] private float terrorDuration = 1.0f;
    [SerializeField] private float subsequentApplicationDelay = 3.0f;
    [SerializeField] private int maxCount = 3;
    private int count;

    [SerializeField] private float specialEffectActivationTimerMax = 5.0f;
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
                if (count == 0)
                    specialEffectActivationTimer -= Time.fixedDeltaTime;
            }
            else if(count == 0)
            {
                specialEffectActivationTimer = specialEffectActivationTimerMax;

                //SPECIAL EFFECT - APPLY STUN
                StartCoroutine(TerrorRoutine());
            }
        }
    }




    //FUNCTIONALITIES
    public static void ApplyTerror(float terrorDuration)
    {
        //APPLY TERROR TO PLAYER (FIRE EVENT?) - SHOULD IT BE PAIRED WITH A COROUTINE TO HANDLE RE-ITERATED TERROR?
        GameController.Instance.FindPlayerAnywhere().ApplyStun(terrorDuration / 3);//TODO: STUN THE UFO FOR FULL TIMER?

        //APPLY TERROR TO COWS (FIRE EVENT?) - SHOULD IT BE PAIRED WITH A COROUTINE TO HANDLE RE-ITERATED TERROR?
        CowManager.Instance.ApplyGlobalTerrify(terrorDuration);

        //playerController.ApplyStun(this.stunDuration);
        UIController.Instance.IGPanel.DebuffPanel.fadeToTransparent = true;

        //TODO: DO SOME VISUAL EFFECTS ON THE COW?

    }


    //COROUTINES
    private IEnumerator TerrorRoutine()
    {
        //APPLY TERROR
        ApplyTerror(terrorDuration);
        count++;
        yield return new WaitForSeconds(subsequentApplicationDelay);


        //IF COUNT HAS NOT BEEN MAXED OUT, RE-SCHEDULE
        if (count < maxCount)
        {
            StartCoroutine(TerrorRoutine());
        }
        else
            count = 0;
    }

}