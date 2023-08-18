using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossionManager : MonoSingleton<MoossionManager>
{
    //DATA

    ///PROGRESSION COUNTER
    [SerializeField] private int completedMoossionCount;

    ///SCORE DATA
    [SerializeField] private int baseScoreCaptureGeneric = 10;
    [SerializeField] private int baseScoreCaptureSpecific = 20;
    [SerializeField] private int baseScoreCaptureBuff = 15;
    [SerializeField] private int baseScoreCaptureTurret = 5;


    ///STRUCTURAL DATA (DICTIONARIES)
    //private Dictionary<>


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







    //METHODS
    //...

    // Update is called once per frame
    void Update()
    {
        
    }



    //INITIALIZATION
    public void Initialization()
    {
        //TODO: IMPLEMENT

        //1 - CREATE A LIST OF MOOSSIONS


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


    }




}
