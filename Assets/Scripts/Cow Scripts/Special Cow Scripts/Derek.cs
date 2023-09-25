using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Derek : CowSpecialScript
{
    //DATA
    [SerializeField] private float ringPowerDuration = 5.0f;
    [SerializeField] [Range(0, 100)] private float ufoSpeedDecreasePercent = 20;
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
        specialEffectActivationTimer = 0.1f;//RING POWER STARTS IMMEDIATELY
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
                ApplySpecialEffect(this.ringPowerDuration);
            }
        }
    }




    //FUNCTIONALITIES
    public static void ApplySpecialEffect(float ringPowerDuration)
    {
        //CHOOSE RANDOMLY - DRAGON, DUTCH, TULCU, COWALANCHE, SAURON

        //TODO: ONLY IF THE CORRESPONDING COW HAS BEEN UNLOCKED

        int randomIndex = Random.Range(0, 5);
        switch (randomIndex)
        {
            case 0:
                Cowgon.ApplyStun(1);
                break;
            case 1:
                Cowtchman.ApplyCurse(5);
                break;
            case 2:
                Tulcu.ApplyTerror(1);
                break;
            case 3:
                Cowalanche.ApplyAvalanche(5,25);
                break;
            case 4:
                Cowron.ApplyRingPower();
                break;
            default:
                break;
        }

    }

}