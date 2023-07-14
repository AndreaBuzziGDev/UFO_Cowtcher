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
    [SerializeField] private int circleSteps;
    [SerializeField] private GameObject outerCircle;
    [SerializeField] private GameObject innerCircle;
    [SerializeField] private LayerMask cowPhysicsLayer;

    private LineRenderer outerCircleRenderer;
    private LineRenderer innerCircleRenderer;
    private float minRadius = 0f;
    private float currentCaptureTimer = 0f;
    private float captureDelta = 0f;
    private float timeBeforeReductionProgress = 0f;
    private List<GameObject> cowsInRange = new List<GameObject>();

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
        for (int i = cowsInRange.Count - 1; i >= 0; i--)
        {
            cowsInRange[i].SetActive(false);

            //PASS THE COW ATTRIBUTES TO THE RIGHT SCRIPTS
            Cow cow = cowsInRange[i].GetComponent<Cow>();
            float cowFuelRecoveryAmount = cow.FuelRecoveryAmount;
            float cowIncreaseScoreAmount = cow.Score;

            UFO.ChangeFuel(cowFuelRecoveryAmount);
            UFO.ChangeScore(cowIncreaseScoreAmount);

            cowsInRange.Remove(cowsInRange[i]);
        }
        
        currentCaptureTimer = 0.0f;
    }
}
