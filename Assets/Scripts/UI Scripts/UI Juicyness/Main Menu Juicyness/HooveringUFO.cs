using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HooveringUFO : MonoBehaviour
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

        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + Mathf.Sin(Time.unscaledTime * shakeSpeed) * shakeAmount,
            transform.position.z
            );

    }

}
