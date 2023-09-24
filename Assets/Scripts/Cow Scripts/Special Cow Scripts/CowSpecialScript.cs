using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CowSpecialScript : MonoBehaviour
{
    //DATA
    [SerializeField] private Cow myCow;
    [SerializeField] private CowMovement myMovement;

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
                HandleDedicatedBehaviour();
            }
        }
        else if (myCow.IsCalm)
        {
            specialEffectActivationTimer = specialEffectActivationTimerMax;
            //TODO: DISABLE SPECIAL SCRIPT

        }
    }


    //ABSTRACT METHODOLOGY
    protected abstract void HandleDedicatedBehaviour();

}
