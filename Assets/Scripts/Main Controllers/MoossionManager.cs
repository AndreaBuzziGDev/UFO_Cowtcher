using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoossionManager : MonoSingleton<MoossionManager>
{
    //DATA

    ///PROGRESSION COUNTER
    [SerializeField] private int completedMoossionCount = 0;
    public int CompletedMoossionCount { get { return completedMoossionCount; } }

    ///SCORE DATA
    [SerializeField] private int baseScoreCaptureGeneric = 10;
    [SerializeField] private int baseScoreCaptureSpecific = 20;
    [SerializeField] private int baseScoreCaptureBuff = 15;
    [SerializeField] private int baseScoreCaptureTurret = 5;

    ///TYPE DIVERSIFICATION DATA
    [SerializeField] private int counterMaxCaptureCollective = 2;
    [SerializeField] private int counterMaxCaptureBuff = 1;
    [SerializeField] private int counterMaxCaptureTurret = 1;

    private int counterCaptureCollective = 0;
    private int counterCaptureBuff = 0;
    private int counterCaptureTurret = 0;


    ///DIFFICULTY OF MOOSSION ADVANCEMENT DATA
    [SerializeField] private int moossionDifficultyThreshold = 3;



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

    ///List of Moossions
    private List<Moossion> activeMoossions = new();





    //METHODS
    //...

    // Update is called once per frame
    void Update()
    {
        //CHANGE MOOSSIONS THAT HAVE BEEN COMPLETED
        for(int i=0; i<activeMoossions.Count; i++)
        {
            Moossion moo = activeMoossions[i];
            if (moo.IsComplete)
            {
                //COMPLETE MOOSSION
                CompleteMoossion(moo);


                //TODO: INFORM THE FEED THAT THE MOOSSIONS HAVE BEEN UPDATED
                //1) Completed
                //2) New enabled


                //ASSIGN NEW MOOSSION
                activeMoossions[i] = CreateRandomMoossion();

                //TODO: INFORM THE GUI THAT THE MOOSSIONS HAVE BEEN UPDATED



            }
        }
    }



    //INITIALIZATION
    public void Initialization()
    {
        //IN THIS VERSION, SYSTEM STARTS WITH A DEFAULT SETUP OF MOOSSIONS
        moossionOne = FactoryMoossion(Moossion.Type.CaptureGeneric);

        moossionTwo = FactoryMoossion(Moossion.Type.CaptureSpecific);

        moossionThree = FactoryMoossion(Moossion.Type.CaptureBuff);

        //LISTING MOOSSIONS
        activeMoossions = new List<Moossion> { moossionOne, moossionTwo, moossionThree };

        foreach(Moossion moo in activeMoossions)
        {
            Debug.Log("MoossionManager - Initial Active moossion: " + moo.Name);
        }

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

        //DECREASE COUNTER OF THAT TYPE
        HandleCount(targetMoossion.MoossionType, false);

        //INCREASING COUNTER COMPLETED
        completedMoossionCount++;

        //DEBUG
        Debug.Log("MoossionManager - Completed Moossion: " + targetMoossion.Name);
    }

    public Moossion CreateRandomMoossion()
    {
        Moossion.Type chosenType = RandomlyChooseType();

        Moossion result = FactoryMoossion(chosenType);

        //INCREASE COUNTER OF THAT TYPE
        HandleCount(result.MoossionType, true);

        Debug.Log("MoossionManager - Created new Moossion: " + result.Name);

        return result;
    }



    //UTILITIES
    public Moossion.Type RandomlyChooseType()
    {
        Moossion.Type chosenType;
        while (true)
        {
            int randomInt = UnityEngine.Random.Range(0, (Enum.GetNames(typeof(Moossion.Type)).Length - 1));
            Debug.Log("MoossionManager - randomlyChooseType - randomInt: " + randomInt);

            switch (randomInt)
            {
                case 0:
                    chosenType = Moossion.Type.CaptureGeneric;
                    break;
                case 1:
                    chosenType = Moossion.Type.CaptureSpecific;
                    break;
                case 2:
                    chosenType = Moossion.Type.CaptureBuff;
                    break;
                case 3:
                    chosenType = Moossion.Type.CaptureTurret;
                    break;
                default:
                    chosenType = Moossion.Type.CaptureGeneric;
                    break;
            }

            if (IsWithinCount(chosenType)) break;
        }

        return chosenType;
    }

    public bool IsWithinCount(Moossion.Type checkedType)
    {
        switch (checkedType)
        {
            //
            case Moossion.Type.CaptureGeneric:
            case Moossion.Type.CaptureSpecific:
                Debug.Log("MoossionManager - Count for " + checkedType + " is: " + counterCaptureCollective);
                return counterCaptureCollective < counterMaxCaptureCollective;
            //
            case Moossion.Type.CaptureBuff:
                Debug.Log("MoossionManager - Count for " + checkedType + " is: " + counterCaptureBuff);
                return counterCaptureBuff < counterMaxCaptureBuff;
            //
            case Moossion.Type.CaptureTurret:
                Debug.Log("MoossionManager - Count for " + checkedType + " is: " + counterCaptureTurret);
                return counterCaptureTurret < counterMaxCaptureTurret;
            //
            default:
                Debug.Log("MoossionManager - Unsupported Type: " + checkedType);
                return true;
        }
    }

    public void HandleCount(Moossion.Type handledType, bool direction)
    {
        switch (handledType)
        {
            //
            case Moossion.Type.CaptureGeneric:
            case Moossion.Type.CaptureSpecific:
                if (direction) counterCaptureCollective++;
                else counterCaptureCollective--;
                break;
            //
            case Moossion.Type.CaptureBuff:
                if (direction) counterCaptureBuff++;
                else counterCaptureBuff--;
                break;
            //
            case Moossion.Type.CaptureTurret:
                if (direction) counterCaptureTurret++;
                else counterCaptureTurret--;
                break;
            //
            default:
                Debug.Log("MoossionManager - HandleCount - Invalid Type: " + handledType);
                break;
        }
    }



    //MOOSSION FACTORY
    public Moossion FactoryMoossion(Moossion.Type chosenType)
    {
        switch (chosenType)
        {
            //
            case Moossion.Type.CaptureGeneric:
                //TODO: RANDOMIZE QUANTITY
                return new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 1);
            case Moossion.Type.CaptureSpecific:
                //TODO: RANDOMIZE QUANTITY
                //TODO: RANDOMIZE TARGET COW
                return new MoossCaptSpecific(Moossion.Type.CaptureSpecific, 1, CowSO.UniqueID.C000Jamal);
            //
            case Moossion.Type.CaptureBuff:
                //TODO: RANDOMIZE QUANTITY
                //TODO: RANDOMIZE TARGET BUFF
                //TODO: MOVE THE SOUGHT BUFF AWAY, USE ANOTHER CLASS' VALUE (RELATED TO BUFFS)
                return new MoossCaptBuff(Moossion.Type.CaptureBuff, 1, MoossCaptBuff.SoughtBuff.FuelGainBoost);
            //
            case Moossion.Type.CaptureTurret:
                //TODO: RANDOMIZE QUANTITY
                //TODO: RANDOMIZE TARGET TURRET
                //TODO: MOVE THE SOUGHT TURRET AWAY, USE ANOTHER CLASS' VALUE (RELATED TO TURRETS)
                return new MoossCaptTurret(Moossion.Type.CaptureTurret, 1, MoossCaptTurret.SoughtTurret.SlowingTurret);
            //
            default:
                Debug.Log("MoossionManager - FactoryMoossion - Invalid Type: " + chosenType + " - Using default generic capture 1");
                return new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 1);
        }
    }




}
