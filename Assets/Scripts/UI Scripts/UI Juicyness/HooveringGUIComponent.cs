using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HooveringGUIComponent : MonoBehaviour
{
    //DATA

    ///SHAKE VARIABLES
    [Header("Hoovering Settings")]
    [SerializeField] private float shakeAmount;
    [SerializeField] private float shakeSpeed;



    //METHODS
    //...

    // Update is called once per frame
    void Update()
    {
        AnimateHooveringUFO();
    }



    //JUICYNESS
    private void AnimateHooveringUFO()
    {
        //TODO: USE SMOOTHDAMP SOLUTION INSTEAD?

        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + Mathf.Sin(Time.fixedUnscaledTime * shakeSpeed) * shakeAmount,
            transform.position.z
            );

    }

}
