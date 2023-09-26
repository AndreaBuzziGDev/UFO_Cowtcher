using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowron : CowSpecialScript
{
    //DATA
    [SerializeField] private float ringPowerDuration = 5.0f;
    [SerializeField] [Range(0, 100)] private float speedMalus = 50;
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
                ApplyRingPower(ringPowerDuration, speedMalus);
            }
        }
    }




    //FUNCTIONALITIES
    public static void ApplyRingPower(float ringPowerDuration, float speedMalus)
    {
        GlobalEffectSauron.Instance.ApplyRingPower(ringPowerDuration, -speedMalus);//REMEMBER: NEGATIVE SPEED BONUS

        //playerController.ApplyStun(this.stunDuration);
        UIController.Instance.IGPanel.DebuffPanel.fadeToTransparent = true;

        //TODO: DO SOME VISUAL EFFECTS ON THE COW?

    }

}
