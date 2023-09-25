using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEffectSauron : MonoSingleton<GlobalEffectSauron>
{
    //DATA
    private float sauronMult = 100.0f;
    public float SauronMult { get { return sauronMult / 100.0f; } }

    private bool isRingPower;
    public bool IsRingPower { get { return isRingPower; } }



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //FUNCTIONALITIES
    //TODO: EFFECT TO APPLY RING POWER




    //COROUTINES
    //TODO: COROUTINE TO HANDLE EFFECT


}
