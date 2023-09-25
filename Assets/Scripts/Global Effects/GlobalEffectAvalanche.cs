using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEffectAvalanche : MonoSingleton<GlobalEffectAvalanche>
{
    //DATA
    private float avalancheSpeedMultiplier = 100.0f;
    public float AvalancheSpeedMult { get { return avalancheSpeedMultiplier / 100.0f; } }
    public bool IsAvalanche { get { return AvalancheSpeedMult > 1.0f; } }



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
    public void ApplyAvalanche(float avalancheDuration, float speedBonusPercent)
    {
        avalancheSpeedMultiplier += speedBonusPercent;
        StartCoroutine(AvalancheRoutine(avalancheDuration));
    }



    //COROUTINES
    private IEnumerator AvalancheRoutine(float avalancheDuration)
    {
        //WAIT FOR TIME
        yield return new WaitForSeconds(avalancheDuration);

        //RE-SET SPEED
        avalancheSpeedMultiplier = 100.0f;
    }

}
