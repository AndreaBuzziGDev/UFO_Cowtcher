using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UFOAccessoriesBuffs : MonoBehaviour

{
    //DATA
    ///SPRITE RENDERERS
    [SerializeField] private SpriteRenderer speedBoostUFO;
    [SerializeField] private SpriteRenderer fastCatchUFO;
    [SerializeField] private SpriteRenderer fuelBoostUFO;
    [SerializeField] private SpriteRenderer radarUFO;
    [SerializeField] private SpriteRenderer captureRadiusUFO;

    ///HOLOGRAM PREFABS
    //POSITIVE EFFECTS
    [SerializeField] private FadeOutEntity prefab2xFuel;
    [SerializeField] private FadeOutEntity prefabRange;
    [SerializeField] private FadeOutEntity prefabFastCatch;
    [SerializeField] private FadeOutEntity prefabMoveSpeed;

    //NEGATIVE EFFECTS
    [SerializeField] private FadeOutEntity prefabInstantFuelLoss;



    //METHODS
    //...
    private void Start()
    {
        //REGISTER EVENT
        ItemPickup.ItemPickedUp += HandleItemPickup;
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

    private void OnDisable()
    {
        //UN-REGISTER EVENT
        ItemPickup.ItemPickedUp -= HandleItemPickup;
    }


    //FUNCTIONALITIES

    //HANDLING PICKUP OF ITEMS
    public void HandleItemPickup(object sender, SAPickupEventArgs e)
    {
        //SHOW CORRESPONDING BUFF

    }

}
