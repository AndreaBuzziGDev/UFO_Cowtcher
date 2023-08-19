using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossionManagerV2 : MonoSingleton<MoossionManagerV2>
{
    //DATA
    [SerializeField] List<Moossion> moossionPool = new();

    [SerializeField] List<Moossion> moossionUnlock = new();//TODO: CHANGE TYPE WITH DEDICATED TYPE

    ///PROGRESSION COUNTER
    [SerializeField] private int completedMoossionCount = 0;
    public int CompletedMoossionCount { get { return completedMoossionCount; } }


    ///SCORE DATA
    [SerializeField] private int baseScoreCaptureGeneric = 10;
    [SerializeField] private int baseScoreCaptureSpecific = 20;
    [SerializeField] private int baseScoreCaptureBuff = 15;
    [SerializeField] private int baseScoreCaptureTurret = 5;


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
                //COMPLETE MOOSSION
                CompleteMoossion(moo);


                //TODO: INFORM THE FEED THAT THE MOOSSIONS HAVE BEEN UPDATED


                //TODO: INFORM THE GUI THAT THE MOOSSIONS HAVE BEEN UPDATED



            }
        }
    }

    //INITIALIZATION
    public void Initialization()
    {

        //TODO: ENFORCE THE PRESENCE OF UP TO 1 TARGET CAPTURE MOOSSION IF THE CONDITIONS ALLOW IT

        //TODO: COPY FROM EXISTING CODE
        MoossionPoolGeneric.BakeMoossionPool();
        moossionPool = MoossionPoolGeneric.MoossionPool;

    }




    //FUNCTIONALITIES
    public void CompleteMoossion(Moossion targetMoossion)
    {
        int score = 0;

        switch (targetMoossion)
        {
            case MoossCaptGeneric:
                score = targetMoossion.TargetQuantity * baseScoreCaptureGeneric;
                break;
            case MoossCaptSpecific:
                score = targetMoossion.TargetQuantity * baseScoreCaptureSpecific;
                break;
            case MoossCaptBuff:
                score = targetMoossion.TargetQuantity * baseScoreCaptureBuff;
                break;
            case MoossCaptTurret:
                score = targetMoossion.TargetQuantity * baseScoreCaptureTurret;
                break;
        }


        //ADD SCORE TO THE SCOREBOARD
        UIController.Instance.IGPanel.HighScoreBar.AddScore(score);

        //INCREASING COUNTER COMPLETED
        //TODO: IMPLEMENT
        //completedMoossionCount++;

        //DEBUG
        Debug.Log("MoossionManager - Completed Moossion: " + targetMoossion.Name);
    }


    public Moossion PickRandomMoossion()
    {
        if (moossionPool.Count > 0)
        {
            int randomIndex = Random.Range(0, moossionPool.Count - 1);
            return moossionPool[randomIndex];
        } else
        {
            return null;
        }
    }


    //TODO: FUNCTIONALITY TO PICK THE LOWEST-INDEX UNLOCKMOOSSION




    //UTILITIES



}
