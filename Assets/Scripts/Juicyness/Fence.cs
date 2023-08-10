using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{

    //DATA
    [SerializeField] float outerTurnDistance = 2.0f;//DISTANCE AT WHICH TURN IS 0 DEGREES
    [SerializeField] float innerTurnDistance = 0.5f;//DISTANCE AT WHICH TURN IS 180 DEGREES
    [SerializeField] private float maxRotation = 180f;

    //METHODS
    //...

    //TODO: DO SOME GIZMO/GUI STUFF FOR AIDING AND BETTER VISUALIZING THE MAP BOUNDARIES.


    //COLLISION HANDLING
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Fence");

        GameObject otherGO = collision.gameObject;
        CowMovement compCowMovement = otherGO.GetComponent<CowMovement>();
        if (compCowMovement != null)
        {
            compCowMovement.CheckFence(this);
        }

    }




    //FUNCTIONALITIES
    public float GetTurningFactor(CowMovement approachingCowMovement)
    {
        float distance = (this.transform.position - approachingCowMovement.transform.position).magnitude;

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
            float coefficient = ((outerTurnDistance - innerTurnDistance) - (clampedDistance - innerTurnDistance)) / (outerTurnDistance - innerTurnDistance);
            Debug.Log("Fence - coefficient: " + coefficient);

            turningFactor = maxRotation * coefficient;
            Debug.Log("Fence - turningFactor: " + turningFactor);
        }

        //TODO: HANDLE HERE IF UFO IS LEFT OR RIGHT? OR LET THE COW MOVEMENT HANDLE IT?

        //TURNING
        return turningFactor;
    }

}
