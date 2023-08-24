using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{

    //DATA
    [Tooltip("Beyond this distance from the Fence, the UFO is too far for the dodging to take place.")]
    [SerializeField] float outerTurnDistance = 3.0f;
    [Tooltip("This offset is used to give an handicap to the cow to determine wether the UFO is closer to the fence than the cow.")]
    [SerializeField] float cowBonusOffset = 1.0f;

    [Tooltip("During this time, the cow won't change the bordering fence it is referencing.")]
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
        CowCollider cowCollider = otherGO.GetComponent<CowCollider>();
        if (cowCollider != null)
        {
            CowMovement compCowMovement = cowCollider.GetMovement();
            if (compCowMovement != null)
            {
                compCowMovement.CheckClosestFence(this);
            }
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
        float distanceFenceUFO = (transform.position - vectorUFO).magnitude;

        bool isUFOWithinDistance = distanceFenceUFO < outerTurnDistance;
        if (isUFOWithinDistance)
        {
            float distanceFenceCow = (this.transform.position - approachingCowMovement.transform.position).magnitude;
            bool isCowWithinDistance = (distanceFenceCow + cowBonusOffset < outerTurnDistance);

            bool isUFOCloserThanCow = (distanceFenceCow + cowBonusOffset > distanceFenceUFO);

            return (isCowWithinDistance && !isUFOCloserThanCow);
            //return isCowWithinDistance;
        }
        else
        {
            return false;
        }
    }

}
