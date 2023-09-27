using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOParticleEffects : MonoBehaviour
{
    //DATA
    [SerializeField] private UFOMalfunctionController malfunction;
    [SerializeField] private UFOFreezingController freezing;
    [SerializeField] private UFOFearController terror;
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
        malfunction.gameObject.SetActive(UFOStatusAlterationHelper.HasStun());

        //FREEZE
        freezing.gameObject.SetActive(UFOStatusAlterationHelper.HasFreeze());

        //FEAR
        terror.gameObject.SetActive(GlobalEffectTulcu.Instance.IsTerrorActive);

        //CURSE
        curse.gameObject.SetActive(GlobalEffectDutch.Instance.IsCurseActive);

    }



}
