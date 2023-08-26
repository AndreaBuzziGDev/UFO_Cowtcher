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

    // Update is called once per frame
    void Update()
    {
        //HANDLE COMPLETION FOR MOOSSIONS THAT HAVE BEEN COMPLETED
        for (int i = 0; i < activeMoossions.Count; i++)
        {
            Moossion moo = activeMoossions[i];
            if (moo.IsComplete)
            {
                //TODO: INFORM THE FEED THAT THE MOOSSIONS HAVE BEEN UPDATED


                //TODO: INFORM THE GUI THAT THE MOOSSIONS HAVE BEEN UPDATED



            }
        }
    }

    //INITIALIZATION
    public void Initialization()
    {
        MoossionPoolGeneric.BakeMoossionPool();
        moossionPool = MoossionPoolGeneric.MoossionPool;

        moossionOne = PickRandomMoossion();
        Debug.Log("MoossionManager has picked Moossion 1: " + moossionOne.GetDescription());

        moossionTwo = PickRandomMoossion();
        Debug.Log("MoossionManager has picked Moossion 2: " + moossionTwo.GetDescription());

        moossionThree = PickRandomMoossion();
        Debug.Log("MoossionManager has picked Moossion 3: " + moossionThree.GetDescription());
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



    //UTILITIES



}
