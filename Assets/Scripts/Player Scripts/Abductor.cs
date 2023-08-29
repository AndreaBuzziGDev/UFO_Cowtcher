using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;

public class Abductor : MonoBehaviour
{
    //DATA
    [SerializeField] private UFO UFO;
    [SerializeField] private float captureTimer;
    [SerializeField] private float timeBeforeReduction;
    [SerializeField] private float maxRadius;
    [SerializeField] private float excessCaptureRadius = 0.4f;
    [SerializeField] private float bonusCaptureRadius = 0f;//PERCENT

    private int circleSteps = 35;
    [SerializeField] private GameObject outerCircle;
    [SerializeField] private GameObject innerCircle;
    [SerializeField] private LayerMask interactionPhysicsLayer;
    private int cowLayer;
    private int interactionLayer;



    private LineRenderer outerCircleRenderer;
    private LineRenderer innerCircleRenderer;
    private float minRadius = 0f;
    private float currentCaptureTimer = 0f;
    private float captureDelta = 0f;
    private float timeBeforeReductionProgress = 0f;
    private float captureSpeedBoost = 0f;//PERCENT

    ///COWS IN RANGE
    private List<GameObject> cowsInRange = new List<GameObject>();//TODO: POSSIBLE REFACTOR SO THAT THIS HOLDS Cow(s)


    //OTHER DATA
    private FollowCamera playerCamera;


    //EVENTS
    public static event EventHandler<CowCaptureEventArgs> CowCapture;



    //METHODS
    private void Awake()
    {
        outerCircleRenderer = outerCircle.GetComponent<LineRenderer>();
        innerCircleRenderer = innerCircle.GetComponent<LineRenderer>();

        playerCamera = Camera.main.GetComponent<FollowCamera>();

        ///LAYER INITIALIZATION
        cowLayer = LayerMask.NameToLayer("CowPhysicsLayer");
        interactionLayer = LayerMask.NameToLayer("ObjectInteractionPhysicsLayer");

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        currentCaptureTimer = Mathf.Clamp(currentCaptureTimer, 0, captureTimer);

        DrawCircle(circleSteps, maxRadius + CalcCaptureRadiusBonus(), outerCircleRenderer);
        if (cowsInRange.Count > 0)
        {
            //HANDLE ZOOM
            playerCamera.SetIsZooming(true);

            //HANDLE CAPTURE AND CIRCLE
            innerCircle.SetActive(true);

            //UPDATED 29/08/2023 - CAPTURE SPEED BOOST
            currentCaptureTimer += Time.deltaTime + (Time.deltaTime * (captureSpeedBoost / 100.0f));
            captureDelta = currentCaptureTimer / captureTimer;
            DrawCircle(circleSteps, Mathf.Lerp(minRadius, maxRadius + CalcCaptureRadiusBonus(), captureDelta), innerCircleRenderer);

            timeBeforeReductionProgress = 0f;

            if (currentCaptureTimer >= captureTimer)
            {
                CatchCows();
            }
        }
        else
        {
            timeBeforeReductionProgress += Time.deltaTime;

            if (timeBeforeReductionProgress >= timeBeforeReduction)
            {
                //HANDLE DE-ZOOM
                playerCamera.SetIsZooming(false);

                currentCaptureTimer -= Time.deltaTime;
                captureDelta = currentCaptureTimer / captureTimer;
                DrawCircle(circleSteps, Mathf.Lerp(minRadius, maxRadius + CalcCaptureRadiusBonus(), captureDelta), innerCircleRenderer);
            }
            else
            {
                DrawCircle(circleSteps, Mathf.Lerp(minRadius, maxRadius + CalcCaptureRadiusBonus(), captureDelta), innerCircleRenderer);
            }
        }
    }

    private void FixedUpdate()
    {
        //CowDetectionLegacy();
        CowDetectionEnhanced();
    }



    //FUNCTIONALITIES
    private void DrawCircle(int steps, float radius, LineRenderer circleRenderer)
    {
        circleRenderer.positionCount = steps;

        for (int currentStep = 0; currentStep < steps; currentStep++)
        {
            float circumferenceProgress = (float)currentStep / (steps - 1);

            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float zScaled = Mathf.Sin(currentRadian);

            float x = (xScaled * radius) + transform.position.x;
            float z = (zScaled * radius) + transform.position.z;

            Vector3 currentPosition = new Vector3(x, 0.1f, z);

            circleRenderer.SetPosition(currentStep, currentPosition);
        }
    }

    private void CatchCows()
    {
        foreach(GameObject inRangeCow in cowsInRange)
        {
            //TODO: USE EVENT SYSTEM ON ALL INTERESTED TARGETS (UFO, SpawnManager)

            //PASS THE COW ATTRIBUTES TO THE RIGHT SCRIPTS
            Cow cow = inRangeCow.GetComponent<Cow>();

            //CAPTURE - FUEL RECOVERY
            UFO.ChangeFuelCapture(cow.CowTemplate);
            UFO.ChangeScore(cow.Score);

            //WARN SPAWNMANAGER THAT A GIVEN COW HAS BEEN CAUGHT
            SpawnManager.Instance.HandleCowCapture(cow);

            //SEND AN EVENT TO MOOSSIONS SO THAT THEY ARE NOTIFIED THAT A COW HAS BEEN CAPTURED
            CowCaptureEventArgs myEventArg = new CowCaptureEventArgs(cow);
            OnCowCapture(myEventArg);


            //INSTANTLY DEPLOYED ITEM
            if (cow.CowTemplate.InstantlyDeployedItemPickup != null)
            {
                //TODO: THIS COULD EASILY BE A "Cow" METHOD.
                GameObject prefabPickupItem = Instantiate(cow.CowTemplate.InstantlyDeployedItemPickup.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
                prefabPickupItem.SetActive(false);
                prefabPickupItem.GetComponent<ItemPickup>().Spawn(cow.transform.position);
            }

            //HOLOGRAM
            GameObject visualChild = cow.GetVisualChild();
            FadeOutEntity.SpawnFadeOutEntity(cow.FadeOutHologram, visualChild.transform.position);



            //TODO: IMPROVE CREATION AND DESTRUCTION OF COWS VIA OBJECT POOLING
            Destroy(cow.gameObject);
        }
        
        currentCaptureTimer = 0.0f;
        DrawCircle(circleSteps, Mathf.Lerp(minRadius, maxRadius + CalcCaptureRadiusBonus(), captureDelta), innerCircleRenderer);
    }


    ///COW DETECTION
    public void CowDetectionLegacy()
    {
        cowsInRange.Clear();
        RaycastHit[] collidersHit = Physics.SphereCastAll(transform.position, maxRadius, Vector3.down, transform.position.y, interactionPhysicsLayer);

        foreach (RaycastHit cow in collidersHit)
        {
            if (cow.collider != null)
            {
                cowsInRange.Add(cow.transform.gameObject);
            }
        }
    }

    /// THIS CONTROLS THE DISTANCE BETWEEN THE UFO AND THE COWS
    public void CowDetectionEnhanced()
    {
        cowsInRange.Clear();
        RaycastHit[] collidersHit = Physics.SphereCastAll(transform.position, (maxRadius+ CalcCaptureRadiusBonus() + excessCaptureRadius), Vector3.down, transform.position.y, interactionPhysicsLayer);

        Vector3 planeProjectedUFOPosition = new Vector3(transform.position.x, 0, transform.position.z);

        /// CONTROL TO DISTINGUISH COWS OR OBJECTS TO INTERACT WITH
        foreach (RaycastHit collider in collidersHit)
        {
            if(collider.transform.gameObject.layer == cowLayer)
            {
                //INTERACT WITH Cow

                Cow myCowObject = collider.transform.gameObject.GetComponent<Cow>();
                if ((myCowObject.transform.position - planeProjectedUFOPosition).magnitude <= (maxRadius + CalcCaptureRadiusBonus() + excessCaptureRadius))
                {
                    cowsInRange.Add(collider.transform.gameObject);
                }
            }
            else if (collider.transform.gameObject.layer == interactionLayer)
            {
                //INTERACT WITH MonoInteractible

                MonoInteractible interactible = collider.transform.gameObject.GetComponent<MonoInteractible>();

                if(interactible != null) interactible.Interact(this.gameObject);

            }
        }
    }



    //FUNCTIONALITIES - ITEM PICKUP BOOSTs
    ///BUFF - CAPTURE SPEED
    public void SetCaptureSpeedBoost(float speedBoost)
    {
        captureSpeedBoost = speedBoost;
    }

    ///BUFF - CAPTURE RADIUS
    public void SetCaptureRadiusBoost(float radiusBoost)
    {
        bonusCaptureRadius = radiusBoost;
    }
    
    //TODO: THIS SHOULD PROBABLY RETURN NOT JUST THE BONUS, BUT THE INCREASED RADIUS ITSELF (SIMPLIFYING CODE)
    public float CalcCaptureRadiusBonus() => maxRadius * (bonusCaptureRadius / 100);




    //EVENT-FIRING METHOD
    private void OnCowCapture(CowCaptureEventArgs myEventArg)
    {
        // make a copy to be more thread-safe
        EventHandler<CowCaptureEventArgs> handler = CowCapture;

        if (handler != null)
        {
            // invoke the subscribed event-handler(s)
            handler(this, myEventArg);
        }
    }


}
