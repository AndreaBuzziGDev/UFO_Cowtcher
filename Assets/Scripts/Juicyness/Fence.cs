using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{

    //DATA
    [SerializeField] float outerTurnDistance = 3.0f;//DISTANCE AT WHICH TURN IS 0 DEGREES
    [SerializeField] float cowBonusOffset = 1.0f;//DISTANCE AT WHICH TURN IS 0 DEGREES

    [SerializeField] float unchangeTimer = 2.0f;
    private float actualTimer;
    public bool CanBeChanged { get { return (actualTimer <= 0); } }


    //TODO: DO SOME GIZMO/GUI STUFF FOR AIDING AND BETTER VISUALIZING THE MAP BOUNDARIES.

    //METHODS
    //...

    private void Update()
    {
        if (!CanBeChanged)
        {
            actualTimer -= Time.deltaTime;
        }
    }




    //COLLISION HANDLING
    void OnTriggerStay(Collider other)
    {
        GameObject otherGO = other.gameObject;
        CowMovement compCowMovement = otherGO.GetComponent<CowCollider>().GetMovement();

        if (compCowMovement != null)
        {
            compCowMovement.CheckClosestFence(this);
        }

    }



    //FUNCTIONALITIES
    public void ActivateFence()
    {
        actualTimer = unchangeTimer;
    }


    public bool GetTurningFactor(CowMovement approachingCowMovement)
    {
        //TODO: INTRODUCE A "MODULATOR" TO ALLOW SOME MARGIN TO DETERMINE WETHER THE UFO IS CLOSER THAN COW OR NOT
        Vector3 ufoPos = GameController.Instance.FindUFOAnywhere().transform.position;
        Vector3 vectorUFO = new Vector3(ufoPos.x, 0, ufoPos.z);
        float distanceUFO = (transform.position - vectorUFO).magnitude;

        bool isUFOWithinDistance = distanceUFO < outerTurnDistance;
        if (isUFOWithinDistance)
        {
            float distanceCow = (this.transform.position - approachingCowMovement.transform.position).magnitude;
            bool isCowWithinDistance = (distanceCow < outerTurnDistance);

            bool isUFOCloserThanCow = (distanceCow + cowBonusOffset > distanceUFO);

            return (isCowWithinDistance && !isUFOCloserThanCow);
            //return isCowWithinDistance;
        }
        else
        {
            return false;
        }
    }

}
