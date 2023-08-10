using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    //DATA
    ///COW REFERENCE
     [SerializeField] private Cow myCow;

    ///MOVEMENT PATTERNS
    private AbstractMovementPattern movPatternCalm;
    private AbstractMovementAlert movPatternAlert;


    ///MOVEMENT DIRECTION (AFFECTED BY MOVEMENT PATTERNS)
    private Vector3 movementDirection = Vector3.forward;
    public Vector3 MovementDirection { get { return movementDirection; } }


    ///SPEED DATA
    private float speedCalm;
    private float speedAlert;
    private float speedBuffMultiplier;//EXPERIMENT TO SLOW DOWN COWS INDIVIDUALLY (NOT YET USED)


    ///TECHNICAL DATA FOR OTHER PURPOSES
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;


    ///JUICYNESS DATA
    [SerializeField] private float shakeAmount;
    [SerializeField] private float shakeSpeed;



    //METHODS
    //...
    private void Awake()
    {
        if (myCow.CowTemplate != null) CloneFromTemplate();

        //OTHER TECHNICAL AWAKE SETUP
        spriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Start()
    {

    }


    private void Update()
    {
        if (movementDirection.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        //IsGlobalTerrify
        if (CowManager.Instance.IsGlobalTerrify) AnimateTerror();
        else HandleMovement();
    }




    //ENABLEMENT/DISABLEMENT
    private void OnEnable()
    {
        this.movementDirection = Vector3.zero;
        /*
        this.currentState = State.Calm;

        //RESET TIMERS
        this.TimerAlertToCalm = 0.0f;
        this.TimerAlertToPanic = cowTemplate.TimerAlertToPanic;

        //SET BIRTH POINT
        spawnCoords = transform.position;
        */
    }

    private void OnDisable()
    {

    }





    //INITIALIZATION
    ///CLONE SCRIPTABLE COW
    private void CloneFromTemplate()
    {
        ///SPEED VALUES
        this.speedCalm = myCow.CowTemplate.SpeedCalm;
        this.speedAlert = myCow.CowTemplate.SpeedAlert;

        ///MOVEMENT PATTERNS
        this.movPatternCalm = myCow.CowTemplate.movPatternCalm.GetMovPattern();
        this.movPatternAlert = (AbstractMovementAlert)myCow.CowTemplate.movPatternAlert.GetMovPattern();

    }




    //FUNCTIONALITIES

    
    private void HandleMovement()
    {
        float mySpeed;
        if (myCow.IsCalm) mySpeed = speedCalm;
        else mySpeed = speedAlert;

        //TODO: A SIMPLE WAY TO GET THEM FAR AWAY FROM FENCES WOULD BE:
        //1: FIND CLOSEST FENCE


        //2: "ROTATE" THE SPEED/VELOCITY VECTOR (COULD BE movementDirection)


        //3: DO IT "MORE" THE CLOSER IT IS TO SAID FENCE


        //GLOBAL SPEED MULTIPLIER
        rb.velocity = mySpeed * CowManager.Instance.GlobalSpeedMultiplier * movementDirection;
    }
    









    //MOVEMENT PATTERNS
    ///CALM
    private void HandleCalmMovement()
    {
        if (movPatternCalm != null)
        {
            movementDirection = movPatternCalm.ManageMovement(this.myCow);
            movPatternCalm.UpdateTimers(Time.deltaTime);
        }
        else movementDirection = Vector3.zero;

    }

    ///ALERT
    private void HandleAlertMovement()
    {
        if (movPatternAlert != null)
        {
            movementDirection = movPatternAlert.ManageMovement(this.myCow);
            movPatternAlert.UpdateTimers(Time.deltaTime);
        }
        else movementDirection = Vector3.zero;
    }

    ///PANIC
    private void HandlePanicMovement()
    {
        if (movPatternAlert != null)
        {
            movementDirection = movPatternAlert.ManagePanic(this.myCow);
            movPatternAlert.UpdateTimers(Time.deltaTime);
        }
        else movementDirection = Vector3.zero;
        //Debug.Log("movementDirection (PANIC): " + movementDirection);
    }





    //JUICYNESS

    //TODO: THIS MIGHT NOT BE OK TO BE PUT HERE

    private void AnimateTerror()
    {
        transform.position = new Vector3(
            transform.position.x + Mathf.Sin(Time.unscaledTime * shakeSpeed) * shakeAmount,
            transform.position.y,
            transform.position.z + Mathf.Cos(Time.unscaledTime * shakeSpeed) * shakeAmount
            );
    }




}
