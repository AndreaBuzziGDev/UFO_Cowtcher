using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    //DATA
    ///COW REFERENCE
    [SerializeField] private Cow myCow;
    public Cow CowScript { get { return myCow; } }


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


    //JUICYNESS DATA
    ///TERROR
    [SerializeField] private float shakeAmount;
    [SerializeField] private float shakeSpeed;

    ///FENCE DODGING
    [SerializeField] private float fenceDetectionRadius;
    private Fence closestFence;




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

        //HANDLE MOVEMENT BASED ON COW AI STATE
        switch (myCow.MovState)
        {
            case Cow.MovementState.Calm:
                HandleCalmMovement();
                break;

            //FIND CLOSEST FENCE
            //TODO: HANDLE MOVEMENT PATTERN EVOLUTION TO DETERMINE IF COW SHOULD ATTEMPT DODGING THE FENCE BASED ON PATTERN INSTEAD OF COW CODE

            case Cow.MovementState.Alert:
                FindClosestFence();
                HandleAlertMovement();
                break;
            case Cow.MovementState.Panic:
                FindClosestFence();
                HandlePanicMovement();
                break;
        }

        //TODO: COULD THIS BE IMPROVED FURTHER?

        //IF TERROR: SHAKE
        if (myCow.MovState == Cow.MovementState.Terror) AnimateTerror();
        //ELSE: MOVE
        else HandleMovement();
    }




    //ENABLEMENT/DISABLEMENT
    private void OnEnable()
    {
        this.movementDirection = Vector3.zero;
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
            movementDirection = movPatternCalm.ManageMovement(this);
            movPatternCalm.UpdateTimers(Time.deltaTime);
        }
        else movementDirection = Vector3.zero;

    }

    ///ALERT
    private void HandleAlertMovement()
    {
        if (movPatternAlert != null)
        {
            movementDirection = movPatternAlert.ManageMovement(this);
            movPatternAlert.UpdateTimers(Time.deltaTime);
        }
        else movementDirection = Vector3.zero;
    }

    ///PANIC
    private void HandlePanicMovement()
    {
        if (movPatternAlert != null)
        {
            movementDirection = movPatternAlert.ManagePanic(this);
            movPatternAlert.UpdateTimers(Time.deltaTime);
        }
        else movementDirection = Vector3.zero;
        //Debug.Log("movementDirection (PANIC): " + movementDirection);
    }





    //JUICYNESS

    ///TERROR
    private void AnimateTerror()
    {
        transform.position = new Vector3(
            transform.position.x + Mathf.Sin(Time.unscaledTime * shakeSpeed) * shakeAmount,
            transform.position.y,
            transform.position.z + Mathf.Cos(Time.unscaledTime * shakeSpeed) * shakeAmount
            );
    }

    ///FENCE DODGING
    public void CheckFence(Fence newFence)
    {
        //TODO: IMPLEMENT LOGIC

    }



}
