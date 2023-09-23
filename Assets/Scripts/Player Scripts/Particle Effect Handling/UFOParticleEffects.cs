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


    void FixedUpdate()
    {
        //STUN
        //malfunction.gameObject.SetActive(UFOStatusAlterationHelper.HasStun());//TODO: ALTERNATIVE IMPLEMENTATION?
        malfunction.gameObject.SetActive(true);

        //FREEZE
        //freezing.gameObject.SetActive(UFOStatusAlterationHelper.HasFreeze());//TODO: ALTERNATIVE IMPLEMENTATION?
        freezing.gameObject.SetActive(true);

        //TODO: SLOWDOWN/CURSED?

    }



}
