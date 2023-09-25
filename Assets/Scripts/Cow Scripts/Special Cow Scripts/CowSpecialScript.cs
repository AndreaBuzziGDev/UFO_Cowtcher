using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CowSpecialScript : MonoBehaviour
{
    //DATA
    [SerializeField] protected Cow myCow;
    [SerializeField] protected CowMovement myMovement;//JUST IN CASE


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
            //DEDICATED BEHAVIOUR
            HandleDedicatedBehaviour();

            //TODO: ENABLE INSTANT-SPECIAL EFFECTS (ATMOSPHERIC STUFF & THAT KIND OF THINGS)


        }
        else if (myCow.IsCalm)
        {
            DisableDedicatedBehaviour();
        }
    }


    //ABSTRACT METHODOLOGY

    ///BEHAVIOUR
    protected abstract void HandleDedicatedBehaviour();

    //TODO: DISCARD
    protected virtual void DisableDedicatedBehaviour()
    {

    }

    //TODO: ALLOW IMPLEMENTATION OF OTHER ASPECTS


}
