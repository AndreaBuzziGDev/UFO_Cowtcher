using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    //DATA
    [SerializeField] FakeCow myCow;
    [SerializeField] float turnDistance = 1.0f;
    [SerializeField] private float maxRotation = 180f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (this.transform.position - myCow.transform.position).magnitude;
        Debug.Log("distance: " + distance);

        float turningFactor = 0;

        //IF WITHIN TURN DISTANCE
        if (distance < turnDistance)
        {
            //THE CLOSER THE COW IS TO THE FENCE, THE STRONGER THE TURN
            float coefficient = (turnDistance - distance) / turnDistance;
            Debug.Log("coefficient: " + coefficient);

            turningFactor = maxRotation * coefficient;
            Debug.Log("turningFactor: " + turningFactor);
        }

        //TURNING
        myCow.myDirectionRotation = turningFactor;

    }
}
