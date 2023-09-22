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
    private AbstractMovementPattern CurrentMovPattern 
    { 
        get 
        { 
            if (myCow.IsCalm) return movPatternCalm;
            else return movPatternAlert;
        } 
    }


    ///MOVEMENT DIRECTION (AFFECTED BY MOVEMENT PATTERNS)
    private Vector3 movementDirection = Vector3.forward;
    public Vector3 MovementDirection { get { return movementDirection; } }



    ///SPEED DATA
    private float speedCalm;
    private float speedAlert;


    ///TECHNICAL DATA FOR OTHER PURPOSES
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;
    public bool IsFlipped { get { return spriteRenderer.flipX; } }


    //JUICYNESS DATA
    ///TERROR
    [SerializeField] private float shakeAmount;
    [SerializeField] private float shakeSpeed;

    ///FENCE DODGING
    [SerializeField] private float fenceDetectionRadius;
    [SerializeField] private Fence closestFence;
    private Vector3 previousFenceNormal;

    ///TURNING SPEED
    [SerializeField] float turningSpeedMult = 2.5f;


    //COWS THAT IGNORE MOVEMENT ALGORITHM DETAILS:
    HashSet<CowSO.UniqueID> cowsThatIgnoreFenceDodge = new HashSet<CowSO.UniqueID> {
        CowSO.UniqueID.R010_Cownguin,
        CowSO.UniqueID.R003_Scarecow,
        CowSO.UniqueID.R007_Sharkow,
        CowSO.UniqueID.R011_Cowflake,
        CowSO.UniqueID.R015_Kowtos
    };

    HashSet<CowSO.UniqueID> cowsThatIgnoreSmoothing = new HashSet<CowSO.UniqueID> {
        CowSO.UniqueID.R000_Kowbra,
        CowSO.UniqueID.R004_Hippocowmp,
        CowSO.UniqueID.R012_Linkow,
        CowSO.UniqueID.R010_Cownguin,
        CowSO.UniqueID.R003_Scarecow,
        CowSO.UniqueID.R007_Sharkow,
        CowSO.UniqueID.R011_Cowflake,
        CowSO.UniqueID.R015_Kowtos
    };




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
        //HANDLE VISUAL FLIPPING
        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        //HANDLE VISUAL JUMP
        if (CurrentMovPattern.Jumps)
        {
            spriteRenderer.transform.position = new Vector3(
               transform.position.x,
               Mathf.Abs(Mathf.Sin(Time.time * 5 * CurrentMovPattern.JumpSpeed)) * CurrentMovPattern.JumpHeight,
               transform.position.z
           );
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

            //TODO: THERE SHOULD BE A POSSIBILITY TO GO TOWARDS THE FENCE IF THE UFO IS NOT NEAR ENOUGH

            case Cow.MovementState.Alert:
                //TODO: TURN IF TOO CLOSE TO FENCE
                HandleAlertMovement();
                break;
            case Cow.MovementState.Panic:
                //TODO: TURN IF TOO CLOSE TO FENCE
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

        //VARIANT - RUN TOWARDS THE CENTER OF THE SPAWNING GRID
        Vector3 intendedDirection = movementDirection;


        //SOME COWS IGNORE THE FENCE DODGING
        if (IsReflectingAgainstFence() && !cowsThatIgnoreFenceDodge.Contains(myCow.CowTemplate.UID))
        {
            Vector3 mapCenterDirection = SpawningGrid.Instance.Center() - this.transform.position;
            intendedDirection = (new Vector3(mapCenterDirection.x, 0, mapCenterDirection.z)).normalized;//TOWARDS CENTER OF SPAWNING GRID

            //GLOBAL SPEED MULTIPLIER
            rb.velocity = mySpeed * CowManager.Instance.GlobalSpeedMultiplier * intendedDirection;
        }

        //SOME COWS NEED MOVEMENT SMOOTHING FOR WHEN FLEEING THE UFO
        else if (CowHelper.IsUFOWithinRadius(myCow) && !cowsThatIgnoreSmoothing.Contains(myCow.CowTemplate.UID))
        {
            if (rb.velocity == Vector3.zero)
                rb.velocity = (this.transform.position - GameController.Instance.FindUFOAnywhere().GetPositionXZ()).normalized;

            rb.velocity = mySpeed * CowManager.Instance.GlobalSpeedMultiplier * 
                Vector3.Lerp(
                    rb.velocity.normalized,
                    intendedDirection, 
                    Time.fixedDeltaTime * turningSpeedMult
                );
        }

        //DEFAULT
        else
            rb.velocity = mySpeed * CowManager.Instance.GlobalSpeedMultiplier * intendedDirection;

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

    ///FENCE DETECTION
    //TODO: THIS MOST LIKELY WON'T BE NEEDED ANYTYME SOON
    public void CheckClosestFence(Fence newFence)
    {
        if(closestFence != null)
        {
            if(closestFence != newFence && closestFence.CanBeChanged)
            {
                float closestFenceDistance = (this.transform.position - closestFence.transform.position).magnitude;

                float newFenceDistance = (this.transform.position - newFence.transform.position).magnitude;

                if (newFenceDistance < closestFenceDistance)
                {
                    previousFenceNormal = closestFence.transform.forward;

                    closestFence = newFence;
                    closestFence.ActivateFence();
                }
            }
        }
        else
        {
            closestFence = newFence;
            closestFence.ActivateFence();
        }

    }

    ///FENCE DODGING
    public bool IsReflectingAgainstFence()
    {
        if(closestFence != null)
        {
            return CowHelper.IsUFOWithinRadius(this.CowScript) && closestFence.GetTurningFactor(this);
        }
        else
        {
            return false;
        }
    }


}
