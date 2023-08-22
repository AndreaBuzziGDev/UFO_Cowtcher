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

    // Update is called once per frame
    void Update()
    {
        //BUFF SPEED BOOST
        if (UFOStatusAlterationHelper.HasBuffMoveSpeed() == true)
        {
            speedBoostUFO.gameObject.SetActive(true);
        }
        else
            speedBoostUFO.gameObject.SetActive(false);

        //BUFF FAST CATCH
        if (UFOStatusAlterationHelper.HasBuffCaptureSpeed() == true)
        {
            fastCatchUFO.gameObject.SetActive(true);
        }
        else
            fastCatchUFO.gameObject.SetActive(false);

        //BUFF FUEL BOOST
        if (UFOStatusAlterationHelper.HasBuffFuelGain() == true)
        {
            fuelBoostUFO.gameObject.SetActive(true);
        }
        else
            fuelBoostUFO.gameObject.SetActive(false); 
    }
}
