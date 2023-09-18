using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UFOAccessoriesBuffs : MonoBehaviour

{
    //DATA
    [SerializeField] private SpriteRenderer speedBoostUFO;
    [SerializeField] private SpriteRenderer fastCatchUFO;
    [SerializeField] private SpriteRenderer fuelBoostUFO;
    [SerializeField] private SpriteRenderer radarUFO;
    [SerializeField] private SpriteRenderer captureRadiusUFO;


    //METHODS
    //...
    private void Start()
    {
        //REGISTER EVENT

    }


    // Update is called once per frame
    void Update()
    {
        //BUFF SPEED BOOST
        speedBoostUFO.gameObject.SetActive(UFOStatusAlterationHelper.HasBuffMoveSpeed());

        //BUFF FAST CATCH
        fastCatchUFO.gameObject.SetActive(UFOStatusAlterationHelper.HasBuffCaptureSpeed());

        //BUFF FUEL BOOST
        fuelBoostUFO.gameObject.SetActive(UFOStatusAlterationHelper.HasBuffFuelGain());

        //BUFF RADAR
        radarUFO.gameObject.SetActive(UFOStatusAlterationHelper.HasBuffRadar());

        //BUFF CAPTURE RADIUS
        captureRadiusUFO.gameObject.SetActive(UFOStatusAlterationHelper.HasBuffCaptureRadius());

    }

    //FUNCTIONALITIES

    //REGISTER EVENT
    private void HandleBuff()
    {

    }

}
