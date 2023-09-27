using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOParticleEffects : MonoBehaviour
{
    //DATA
    [SerializeField] private UFOMalfunctionController malfunction;
    [SerializeField] private UFOFreezingController freezing;
    [SerializeField] private UFOCurseController curse;

    //METHODS
    //...

    private void OnEnable()
    {
        malfunction.gameObject.SetActive(false);
        freezing.gameObject.SetActive(false);
        curse.gameObject.SetActive(false);
    }


    void FixedUpdate()
    {
        //STUN
        malfunction.gameObject.SetActive(UFOStatusAlterationHelper.HasStun());//TODO: ALTERNATIVE IMPLEMENTATION?

        //FREEZE
        freezing.gameObject.SetActive(UFOStatusAlterationHelper.HasFreeze());//TODO: ALTERNATIVE IMPLEMENTATION?

        //FEAR


        //CURSE
        curse.gameObject.SetActive(GlobalEffectDutch.Instance.IsCurseActive);//TODO: ALTERNATIVE IMPLEMENTATION?

    }



}
