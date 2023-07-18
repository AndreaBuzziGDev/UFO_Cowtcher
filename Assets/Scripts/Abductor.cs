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
    [SerializeField] private float cooldownTimer;//TODO: IMPLEMENT/USE

    private int circleSteps = 35;
    [SerializeField] private GameObject outerCircle;
    [SerializeField] private GameObject innerCircle;
    [SerializeField] private LayerMask cowPhysicsLayer;

    private LineRenderer outerCircleRenderer;
    private LineRenderer innerCircleRenderer;
    private float minRadius = 0f;
    private float currentCaptureTimer = 0f;
    private float captureDelta = 0f;
    private float timeBeforeReductionProgress = 0f;
    private List<GameObject> cowsInRange = new List<GameObject>();//TODO: POSSIBLE REFACTOR SO THAT THIS HOLDS Cow(s)

    //METHODS
    private void Awake()
    {
        outerCircleRenderer = outerCircle.GetComponent<LineRenderer>();
        innerCircleRenderer = innerCircle.GetComponent<LineRenderer>();
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
            cow.gameObject.SetActive(false);

            UFO.ChangeFuel(cow.FuelRecoveryAmount);
            UFO.ChangeScore(cow.Score);

            //TODO: WARN SPAWNMANAGER THAT A GIVEN COW HAS BEEN CAUGHT
            SpawnManager.Instance.MarkForRespawn(cow.UID);

            GameController.Instance.FindPlayerAnywhere().AddStatusAlteration(cow.Alteration);
            //cowsInRange.Remove(inRangeCow);
        }
        
        currentCaptureTimer = 0.0f;
        DrawCircle(circleSteps, Mathf.Lerp(minRadius, maxRadius, captureDelta), innerCircleRenderer);
    }


    ///COW DETECTION
    public void CowDetectionLegacy()
    {
        cowsInRange.Clear();
        RaycastHit[] collidersHit = Physics.SphereCastAll(transform.position, maxRadius, Vector3.down, transform.position.y, cowPhysicsLayer);

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
        RaycastHit[] collidersHit = Physics.SphereCastAll(transform.position, maxRadius, Vector3.down, transform.position.y, cowPhysicsLayer);

        Vector3 planeProjectedUFOPosition = new Vector3(transform.position.x, 0, transform.position.z);

        foreach (RaycastHit cow in collidersHit)
        {
            Cow myCowObject = cow.transform.gameObject.GetComponent<Cow>();
            if ((myCowObject.transform.position - planeProjectedUFOPosition).magnitude <= maxRadius)
            {
                cowsInRange.Add(cow.transform.gameObject);
            }
        }
    }




}
