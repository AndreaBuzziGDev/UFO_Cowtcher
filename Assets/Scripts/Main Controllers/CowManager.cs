using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CowManager : MonoSingleton<CowManager>
{
    //DATA
    private List<Cow> allCows = new();


    ///EXPERIMENTAL GLOBAL DATA TO MAKE STRUCTURES WORK
    private float globalSpeedMultiplier = 100.0f;
    public float GlobalSpeedMultiplier { get { return globalSpeedMultiplier/100; } }

    private float globalSpeedTimer;



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        //RESET PARAMS
        globalSpeedMultiplier = 100;
        globalSpeedTimer = 0;

        //TODO: IMPLEMENT RESET allCows???


    }

    // Update is called once per frame
    void Update()
    {
        HandleGlobalSpeedLogic();

    }


    //FUNCTIONALITIES
    public List<Cow> getAllCows()
    {
        List<Cow> currentCows = FindObjectsOfType<Cow>().ToList();
        Debug.Log("Current Cows on Map: " + currentCows.Count);

        return currentCows;
    }




    //GLOBAL EFFECTS
    ///SPEED MULTIPLIER STUFF
    private void HandleGlobalSpeedLogic()
    {
        if (globalSpeedTimer > 0)
        {
            globalSpeedTimer -= Time.deltaTime;
        }
        else
        {
            globalSpeedTimer = 0.0f;
            globalSpeedMultiplier = 100;
        }
    }

    public void ApplyGlobalSpeedChange(float speedChangePercent, float duration)
    {
        globalSpeedMultiplier -= speedChangePercent;
        if (globalSpeedMultiplier < 0) globalSpeedMultiplier = 0;//NO NEGATIVE SPEED

        globalSpeedTimer = duration;
    }


}
