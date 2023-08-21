using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFence : MonoBehaviour
{
    //DATA
    [SerializeField] FakeCow myCow;
    [SerializeField] float outerTurnDistance = 2.0f;//DISTANCE AT WHICH TURN IS 0 DEGREES
    [SerializeField] float innerTurnDistance = 1.0f;//DISTANCE AT WHICH TURN IS 180 DEGREES
    [SerializeField] private float maxRotation = 180f;

    //METHODS

    // Update is called once per frame
    void Update()
    {
        float distance = (this.transform.position - myCow.transform.position).magnitude;

        float turningFactor = 0;

        //IF WITHIN TURN DISTANCE
        if (distance < outerTurnDistance)
        {
            //DEBUGGING
            Debug.Log("Fence - distance: " + distance);
            Debug.Log("Fence - outerTurnDistance: " + outerTurnDistance);
            Debug.Log("Fence - innerTurnDistance: " + innerTurnDistance);

            //CLAMPING
            float clampedDistance = Mathf.Clamp(distance, innerTurnDistance, outerTurnDistance);
            Debug.Log("Fence - clampedDistance: " + clampedDistance);

            //THE CLOSER THE COW IS TO THE FENCE, THE STRONGER THE TURN
            float coefficient = ( (outerTurnDistance - innerTurnDistance) - (clampedDistance - innerTurnDistance)) / (outerTurnDistance - innerTurnDistance);
            Debug.Log("Fence - coefficient: " + coefficient);

            turningFactor = maxRotation * coefficient;
            Debug.Log("Fence - turningFactor: " + turningFactor);
        }

        //TURNING
        myCow.myDirectionRotation = turningFactor;

    }
}
