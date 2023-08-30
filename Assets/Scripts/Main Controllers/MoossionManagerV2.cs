using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossionManagerV2 : MonoSingleton<MoossionManagerV2>
{
    //DATA
    [SerializeField] List<Moossion> moossionPool = new();
    ///PROGRESSION COUNTER
    [SerializeField] private int completedMoossionCount = 0;
    public int CompletedMoossionCount { get { return completedMoossionCount; } }


    ///SCORE DATA
    [SerializeField] private float completionMultiplierOne = 1.25f;
    [SerializeField] private float completionMultiplierTwo = 1.5f;
    [SerializeField] private float completionMultiplierThree = 2.0f;


    ///TYPE DIVERSIFICATION DATA
    //NONE IN THIS VERSION



    ///STRUCTURAL DATA (ACTIVE MOOSSIONS)

    ///1
    private Moossion moossionOne;
    public Moossion MoossionOne { get { return moossionOne; } }

    ///2
    private Moossion moossionTwo;
    public Moossion MoossionTwo { get { return moossionTwo; } }

    ///3
    private Moossion moossionThree;
    public Moossion MoossionThree { get { return moossionThree; } }

    ///List of Moossions
    private List<Moossion> activeMoossions = new();



    //METHODS
    //...

    //INITIALIZATION
    public void Initialization()
    {
        //REGISTERING COW CAPTURE EVENT
        Abductor.CowCapture += HandleCowCapture;

        //GENERATING RANDOM MOOSSIONS
        moossionOne = MoossionPoolGeneric.PickRandomMoossion();
        Debug.Log("MoossionManager has picked Moossion 1: " + moossionOne.GetDescription());

        moossionTwo = MoossionPoolGeneric.PickRandomMoossion();
        Debug.Log("MoossionManager has picked Moossion 2: " + moossionTwo.GetDescription());

        moossionThree = MoossionPoolGeneric.PickRandomMoossion();
        Debug.Log("MoossionManager has picked Moossion 3: " + moossionThree.GetDescription());

        activeMoossions = new List<Moossion> { moossionOne, moossionTwo, moossionThree };
    }

    private void OnDisable()
    {
        Debug.Log("MoossionManager - Unregistering");
        Abductor.CowCapture -= HandleCowCapture;
    }




    //FUNCTIONALITIES
    public Moossion PickRandomMoossion()
    {
        if (moossionPool.Count > 0)
        {
            int randomIndex = Random.Range(0, moossionPool.Count - 1);
            return moossionPool[randomIndex];
        }
        else
        {
            return null;
        }
    }

    public float GetFinalScoreMultiplier()
    {
        int successCounter = 0;
        if (moossionOne.IsComplete) successCounter++;
        if (moossionTwo.IsComplete) successCounter++;
        if (moossionThree.IsComplete) successCounter++;

        switch (successCounter)
        {
            case 1:
                return completionMultiplierOne;
            case 2:
                return completionMultiplierTwo;
            case 3:
                return completionMultiplierThree;
            default:
                return 1.00f;

        }
    }



    //HANDLING CAPTURE OF COWS

    public void HandleCowCapture(object sender, CowCaptureEventArgs e)
    {
        moossionOne.HandleProgressLogic(e.CapturedCow);
        moossionTwo.HandleProgressLogic(e.CapturedCow);
        moossionThree.HandleProgressLogic(e.CapturedCow);
    }

}
