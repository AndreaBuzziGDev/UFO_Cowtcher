using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HintBirdTree : HintAbstract
{
    //DATA
    ///TARGET COW
    [SerializeField] CowSO.UniqueID targetCowUID;
    private Cow targetCow;

    ///FEATURE SETTINGS
    
    ///TIME SPENT FLYING IN THE DIRECTION OF THE COW
    [SerializeField] private float usefulFlightTimerMax = 1.0f;
    private float usefulFlightTimer;
    public bool IsStillFlyingUseful { get { return usefulFlightTimer > 0; } }

    ///TIME SPENT FLYING OVERALL (FLYING UPWARDS) BEFORE THE BIRDS ARE DISABLED.
    [SerializeField] private float flightTimerMax = 5.0f;
    private float flightTimer;
    public bool IsStillFlying { get { return flightTimer > 0; } }

    ///SPEED
    [SerializeField] private float horizontalSpeed = 5.0f;
    [SerializeField] private float upwardsSpeed = 5.0f;
    [SerializeField] private float targetDirectionSpread = 1.0f;


    ///FLIGHT
    private Vector3 startingPosition;
    private Vector3 flightDirection = Vector3.zero;





    ///TECHNICAL DATA
    Rigidbody rb;
    [SerializeField] private SpriteRenderer spriteRenderer;



    //METHODS

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //IF IT'S STILL WITHIN FIST TIMER
        if (IsStillFlyingUseful)
        {
            //TIMERS
            usefulFlightTimer -= Time.deltaTime;
            flightTimer -= Time.deltaTime;

            //MOVE ABOVE TOWARDS COW
            rb.velocity = (horizontalSpeed * flightDirection) + (upwardsSpeed/ upwardsSpeed * Vector3.up);

        }
        //IF IT'S STILL WITHIN GENERAL TIMER
        else if(IsStillFlying)
        {
            //TIMERS
            flightTimer -= Time.deltaTime;

            //FLY UPWARDS Intensely
            rb.velocity = (horizontalSpeed * flightDirection) + (upwardsSpeed * Vector3.up);

            //DISAPPEAR
            if (!IsStillFlying)
            {
                //Disable
                this.gameObject.SetActive(false);
            }

        }


        //FLIP HORIZONTALLY
        HorizontalFlip();

    }


    //HORIZONTAL FLIP
    private void HorizontalFlip()
    {
        if (spriteRenderer != null)
        {
            if (flightDirection.x >= 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
    }







    //IMPLEMENTING HintAbstract
    ///PLAY
    public override void Play()
    {
        findAndSetClosestCow();

        //SET TARGET DIRECTION
        if(targetCow != null)
        {
            flightDirection = GetTargetDirection();
        }
        else
        {
            flightDirection = UtilsRadius.RandomPositionOnCircleRadius(1).normalized;
        }

        //RESET TIMERS
        usefulFlightTimer = usefulFlightTimerMax;
        flightTimer = flightTimerMax;

    }

    ///RESET
    public override void ResetHint()
    {
        //SET INITIAL POSITION
        this.transform.position = startingPosition;

        //ZERO-TIMERS
        usefulFlightTimer = 0;
        flightTimer = 0;

        //REMOVE TARGET COW
        targetCow = null;

        //ZERO VELOCITY
        rb.velocity = Vector3.zero;

        //ENABLE
        this.gameObject.SetActive(true);
    }





    //FUNCTIONALITIES
    ///FINDS AND SETS THE CLOSEST MATCHING TYPE COW
    
    //TODO: IF THIS IS MOVED INTO InteractibleHint THEN IT IS AN OPTIMIZATION
    private void findAndSetClosestCow()
    {
        Vector3 myPosition = this.transform.position;

        //TODO: THIS CAN BE DRASTICALLY OPTIMIZED BY DEVELOPING A DEDICATED COW SEARCH BY UID FUNCTIONALITY SOMEWHERE ELSE

        foreach(Cow c in FindObjectsOfType<Cow>().ToList())
        {
            //CHECK ONLY ACTIVE COWS OF MATCHING TYPE
            if(c.CowTemplate.UID == targetCowUID && c.gameObject.activeSelf)
            {
                if(targetCow == null)
                {
                    targetCow = c;
                }
                else
                {
                    //CHECK IF THE NEXT COW IS CLOSER
                    Vector3 targetPos = targetCow.transform.position;
                    Vector3 newCowPos = c.transform.position;

                    //
                    float distanceTarget = (myPosition - targetPos).magnitude;
                    float distanceNew = (myPosition - newCowPos).magnitude;
                    if (distanceNew < distanceTarget) targetCow = c;
                }
            }
        }

        //FINDING COWS OF TYPE
        Debug.Log("HintBirdTree - targetCow: " + targetCow);

    }


    ///GET DIRECTION TO THE TARGETED COW
    public Vector3 GetTargetDirection()
    {
        if(targetCow != null)
        {
            Vector3 cowPos = targetCow.transform.position;
            Vector3 elevatedCowPosition = new Vector3(cowPos.x, this.transform.position.y, cowPos.z);
            elevatedCowPosition = elevatedCowPosition + UtilsRadius.RandomPositionOnCircleRadius(targetDirectionSpread);
            return (elevatedCowPosition - this.transform.position).normalized;
        }
        else
        {
            return flightDirection;
        }
    }



}
