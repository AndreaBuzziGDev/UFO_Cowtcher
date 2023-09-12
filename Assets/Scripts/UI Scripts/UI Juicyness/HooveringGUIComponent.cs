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

    private Vector3 basePosition;


    //METHODS
    //...
    private void Awake()
    {
        basePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHooveringUFO();
    }

    //TODO: FIX: THIS MUST FLUCTUATE AROUND THE STARTING POINT! RECORD INITIAL POSITION.

    //JUICYNESS
    private void AnimateHooveringUFO()
    {
        //TODO: USE SMOOTHDAMP SOLUTION INSTEAD?

        transform.position = new Vector3(
            basePosition.x,
            basePosition.y + Mathf.Sin(Time.unscaledTime * shakeSpeed) * shakeAmount,
            basePosition.z
            );

    }

}
