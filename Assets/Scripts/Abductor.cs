using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Abductor : MonoBehaviour
{
    //DATA
    [SerializeField] private UFO UFO;
    [SerializeField] private float captureTimer;
    [SerializeField] private float timeBeforeReduction;
    [SerializeField] private float maxRadius;
    [SerializeField] private float excessCaptureRadius = 0.4f;
    [SerializeField] private float cooldownTimer;//TODO: IMPLEMENT/USE

    private int circleSteps = 35;
    [SerializeField] private GameObject outerCircle;
    [SerializeField] private GameObject innerCircle;
    [SerializeField] private LayerMask interactionPhysicsLayer;
    private int cowLayer;
    private int pickupLayer;



    private LineRenderer outerCircleRenderer;
    private LineRenderer innerCircleRenderer;
    private float minRadius = 0f;
    private float currentCaptureTimer = 0f;
    private float captureDelta = 0f;
    private float timeBeforeReductionProgress = 0f;
    private List<GameObject> cowsInRange = new List<GameObject>();//TODO: POSSIBLE REFACTOR SO THAT THIS HOLDS Cow(s)


    //OTHER DATA
    private FollowCamera playerCamera;



    //METHODS
    private void Awake()
    {
        outerCircleRenderer = outerCircle.GetComponent<LineRenderer>();
        innerCircleRenderer = innerCircle.GetComponent<LineRenderer>();

        playerCamera = Camera.main.GetComponent<FollowCamera>();

        ///LAYER INITIALIZATION
        cowLayer = LayerMask.NameToLayer("CowPhysicsLayer");
        pickupLayer = LayerMask.NameToLayer("ObjectInteractionPhysicsLayer");

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        currentCaptureTimer = Mathf.Clamp(currentCaptureTimer, 0, captureTimer);

        DrawCircle(circleSteps, maxRadius, outerCircleRenderer);
        if (cowsInRange.Count > 0)
        {
            //HANDLE ZOOM
            playerCamera.SetIsZooming(true);

            //HANDLE CAPTURE AND CIRCLE
            innerCircle.SetActive(true);
            currentCaptureTimer += Time.deltaTime;
            captureDelta = currentCaptureTimer / captureTimer;
            DrawCircle(circleSteps, Mathf.Lerp(minRadius, maxRadius, captureDelta), innerCircleRenderer);

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
                DrawCircle(circleSteps, Mathf.Lerp(minRadius, maxRadius, captureDelta), innerCircleRenderer);
            }
            else
            {
                DrawCircle(circleSteps, Mathf.Lerp(minRadius, maxRadius, captureDelta), innerCircleRenderer);
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
            //PASS THE COW ATTRIBUTES TO THE RIGHT SCRIPTS
            Cow cow = inRangeCow.GetComponent<Cow>();

            //CAPTURE - FUEL RECOVERY
            UFO.ChangeFuel(cow.FuelRecoveryAmount);
            UFO.ChangeScore(cow.Score);

            //WARN SPAWNMANAGER THAT A GIVEN COW HAS BEEN CAUGHT
            SpawnManager.Instance.HandleCowCapture(cow);

            //TODO: MAYBE A CHECKBOX SOMEWHERE IN ONE OF THE MAIN CONTROLLERS CAN ENABLE THE POSSIBILITY TO GO BACK TO THE PREVIOUS BUFF APPLICATION MODE.
            if (cow.CowTemplate.PickupItemToBeSpawned != null)
            {
                //COMMENTED IN FEATURES ASTEROID: NOW PICKUPS DELIVED THE DESIRED BUFF
                //GameController.Instance.FindPlayerAnywhere().AddStatusAlteration(cow.Alteration);

                //TODO: RESTORE SCARECOW (AND FURTHER "MALICIOUS" COWS) FUNCTIONALITY (DEBUFF DELIVERY)



                //FEATURES ASTEROID: COW DOESN'T GIVE BUFF/DEBUFF ON PICKUP, IT SPAWNS A METEOR SHOWER
                //TODO: THIS CODE PORTION CAN BE SAFELY REFACTORED AND MOVED INSIDE THE Spawn METHOD OF ItemPickup.
                GameObject prefabPickupItem = Instantiate(cow.CowTemplate.PickupItemToBeSpawned.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
                prefabPickupItem.SetActive(false);

                prefabPickupItem.GetComponent<ItemPickup>().Spawn();

            }

            //TODO: IMPROVE CREATION AND DESTRUCTION OF COWS VIA OBJECT POOLING
            //cow.gameObject.SetActive(false);
            Destroy(cow.gameObject);//FIXED COWS SO THAT THEY ARE DESTROYED
        }
        
        currentCaptureTimer = 0.0f;
        DrawCircle(circleSteps, Mathf.Lerp(minRadius, maxRadius, captureDelta), innerCircleRenderer);
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
        RaycastHit[] collidersHit = Physics.SphereCastAll(transform.position, (maxRadius+excessCaptureRadius), Vector3.down, transform.position.y, interactionPhysicsLayer);

        Vector3 planeProjectedUFOPosition = new Vector3(transform.position.x, 0, transform.position.z);

        /// CONTROL TO DISTINGUISH COWS OR OBJECTS TO INTERACT WITH
        foreach (RaycastHit collider in collidersHit)
        {
            if(collider.transform.gameObject.layer == cowLayer)
            {
                Cow myCowObject = collider.transform.gameObject.GetComponent<Cow>();
                if ((myCowObject.transform.position - planeProjectedUFOPosition).magnitude <= (maxRadius + excessCaptureRadius))
                {
                    cowsInRange.Add(collider.transform.gameObject);
                }
            }
            else if (collider.transform.gameObject.layer == pickupLayer)
            {
                //GET COMPONENT ItemPickup FROM COLLIDED OBJECT
                ItemPickup myItemPickup = collider.transform.gameObject.GetComponent<ItemPickup>();

                //DELIVER BUFF TO THE PLAYER UFO
                GameController.Instance.FindPlayerAnywhere().AddStatusAlteration(myItemPickup.GetStatusAlteration());

                //DESTROY PICKED UP ITEM
                Destroy(myItemPickup.gameObject);

            }
        }
    }




}
