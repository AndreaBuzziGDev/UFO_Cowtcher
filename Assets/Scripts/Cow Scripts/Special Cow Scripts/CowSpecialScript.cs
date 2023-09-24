using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CowSpecialScript : MonoBehaviour
{
    //DATA
    [SerializeField] private Cow myCow;
    [SerializeField] private CowMovement myMovement;//JUST IN CASE

    [SerializeField] private float specialEffectActivationTimerMax = 10.0f;
    private float specialEffectActivationTimer;



    //METHODS
    //...

    // Update is called once per frame
    void FixedUpdate()
    {
        if (myCow != null)
        {
            HandleSpecialEffectLogic();
        }
    }



    //FUNCTIONALITIES
    private void HandleSpecialEffectLogic()
    {
        if (myCow.IsAlert)
        {
            if (specialEffectActivationTimer > 0)
                specialEffectActivationTimer -= Time.fixedDeltaTime;
            else
            {
                specialEffectActivationTimer = specialEffectActivationTimerMax;
                EnableDedicatedBehaviour();
            }
        }
        else if (myCow.IsCalm)
        {
            specialEffectActivationTimer = specialEffectActivationTimerMax;
            DisableDedicatedBehaviour();
        }
    }


    //ABSTRACT METHODOLOGY
    protected abstract void EnableDedicatedBehaviour();
    protected abstract void DisableDedicatedBehaviour();



}
