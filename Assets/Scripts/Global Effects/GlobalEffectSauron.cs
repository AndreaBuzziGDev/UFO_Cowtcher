using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEffectSauron : MonoSingleton<GlobalEffectSauron>
{
    //DATA
    private float sauronMult = 100.0f;
    public float SauronMult { get { return sauronMult / 100.0f; } }

    public bool IsRingPowerActive { get { return SauronMult < 1; } }



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
    public void ApplyRingPower(float ringPowerDuration, float speedMalus)
    {
        sauronMult -= speedMalus;
        StartCoroutine(RingPowerRoutine(ringPowerDuration));
    }




    //COROUTINES
    private IEnumerator RingPowerRoutine(float ringPowerDuration)
    {
        //WAIT FOR TIME
        yield return new WaitForSeconds(ringPowerDuration);

        //RE-SET SPEED
        sauronMult = 100.0f;
    }

}
