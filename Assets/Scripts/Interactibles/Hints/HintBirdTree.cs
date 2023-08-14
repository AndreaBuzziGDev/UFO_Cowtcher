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
    
    ///
    [SerializeField] private float usefulFlightTimerMax = 5.0f;
    private float usefulFlightTimer;
    public bool IsStillFlyingUseful { get { return usefulFlightTimer > 0; } }

    ///
    [SerializeField] private float flightTimerMax = 15.0f;
    private float flightTimer;
    public bool IsStillFlying { get { return flightTimer > 0; } }

    ///
    [SerializeField] private float horizontalSpeed = 5.0f;
    [SerializeField] private float upwardsSpeed = 2.0f;


    ///FLIGHT
    private Vector3 flightDirection = Vector3.zero;





    ///TECHNICAL DATA
    Rigidbody rb;



    //METHODS

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStillFlyingUseful)
        {
            //TIMERS
            usefulFlightTimer -= Time.deltaTime;
            flightTimer -= Time.deltaTime;

            //MOVE ABOVE TOWARDS COW
            rb.velocity = horizontalSpeed * flightDirection;

        } 
        else if(IsStillFlying)
        {
            //TIMERS
            flightTimer -= Time.deltaTime;

            //FLY UPWARDS AND DISAPPEAR
            rb.velocity = (horizontalSpeed * flightDirection) + (upwardsSpeed * Vector3.up);

        }
        else
        {
            //Disable
            this.gameObject.SetActive(false);
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
            Vector3 cowPos = targetCow.transform.position;
            flightDirection = (new Vector3(cowPos.x, this.transform.position.y, cowPos.z)).normalized;
            Debug.Log("HintBirdTree - Cow Direction: " + flightDirection);
        }
        else
        {
            flightDirection = UtilsRadius.RandomPositionOnCircleRadius(1).normalized;
            Debug.Log("HintBirdTree - Random Direction: " + flightDirection);
        }

        //RESET TIMERS
        usefulFlightTimer = usefulFlightTimerMax;
        flightTimer = flightTimerMax;

    }

    ///RESET
    public override void Reset()
    {
        //SET INITIAL POSITION


        //REMOVE TARGET COW
        targetCow = null;

        //ENABLE
        this.gameObject.SetActive(true);
    }





    //FUNCTIONALITIES
    ///FINDS AND SETS THE CLOSEST MATCHING TYPE COW
    private void findAndSetClosestCow()
    {
        Vector3 myPosition = this.transform.position;

        //TODO: THIS CAN BE DRASTICALLY OPTIMIZED BY DEVELOPING A DEDICATED FUNCTIONALITY SOMEWHERE ELSE

        foreach(Cow c in FindObjectsOfType<Cow>().ToList())
        {
            //FINDING COWS OF TYPE
            Debug.Log("HintBirdTree - Finding Cows: " + targetCowUID);

            //CHECK ONLY ACTIVE COWS OF MATCHING TYPE
            if(c.CowTemplate.UID == targetCowUID && c.gameObject.activeSelf)
            {
                if(targetCow = null)
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
    }


}
