using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOParticleEffects : MonoBehaviour
{
    //DATA
    [SerializeField] private UFOMalfunctionController malfunction;
    [SerializeField] private UFOFreezingController freezing;


    //METHODS
    //...

    private void OnEnable()
    {
        malfunction.gameObject.SetActive(false);
        freezing.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (UFOStatusAlterationHelper.HasStun() && !malfunction.isActiveAndEnabled)
            malfunction.gameObject.SetActive(true);//TODO: ALTERNATIVE IMPLEMENTATION?

        if (UFOStatusAlterationHelper.HasFreeze() && !freezing.isActiveAndEnabled)
            freezing.gameObject.SetActive(true);//TODO: ALTERNATIVE IMPLEMENTATION?

    }



}
