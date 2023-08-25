using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EndGameSummary : MonoBehaviour
{
    //DATA

    ///GUI REFERENCES
    [SerializeField] private TMPro.TextMeshProUGUI highscoreValue;

    [SerializeField] private TMPro.TextMeshProUGUI capturesValue;
    [SerializeField] private TMPro.TextMeshProUGUI timeElapsedValue;

    [SerializeField] private TMPro.TextMeshProUGUI moossionOne;
    [SerializeField] private TMPro.TextMeshProUGUI moossionTwo;
    [SerializeField] private TMPro.TextMeshProUGUI moossionThree;


    [SerializeField] private TMPro.TextMeshProUGUI multiplierValue;
    [SerializeField] private TMPro.TextMeshProUGUI actualExpValue;

    [SerializeField] private StageExpBar expBar;


    //METHODS
    //...

    //FUNCTIONALITIES
    public void DoEndGameSummary()
    {
        Debug.Log("EndGameSummary - DoEndGameSummary");

        //HIGHSCORE
        int highScore = UIController.Instance.IGPanel.HighScoreBar.Score;
        highscoreValue.text = highScore.ToString();

        ///SAVING HIGHSCORE
        SaveSystem.SaveHighScore(highScore);


        //CAPTURES
        ///TODO: DEVELOP CAPTURE RECORDING SYSTEM
        capturesValue.text = "???";

        //TIME ELAPSED
        float elapsedTime = Time.time;
        int intElapsedTime = (int)elapsedTime;
        timeElapsedValue.text = intElapsedTime.ToString();

        //MOOSSIONS
        moossionOne.text = "FAILED";
        moossionTwo.text = "FAILED";
        moossionThree.text = "FAILED";

        if (MoossionManagerV2.Instance.MoossionOne.IsComplete) moossionOne.text = "COMPLETE";
        if (MoossionManagerV2.Instance.MoossionTwo.IsComplete) moossionTwo.text = "COMPLETE";
        if (MoossionManagerV2.Instance.MoossionThree.IsComplete) moossionThree.text = "COMPLETE";


        //FINAL EXP
        ///SCORE MULTIPLIER
        float finalMult = MoossionManagerV2.Instance.GetFinalScoreMultiplier();
        multiplierValue.text = "X " + finalMult.ToString() + " = ";

        ///ACTUAL EXP
        float actualExp = finalMult * highScore;
        actualExpValue.text = actualExp.ToString();


        //TELL XP BAR TO UPDATE
        try
        {
            SceneNavigationController.eStageSceneName currentScene = SceneNavigationController.Instance.GetCurrentSceneData().StageID;

            ///UPDATE EXPERIENCE SYSTEM
            expBar.UpdateExpSystem(currentScene, (int)actualExp);

            ///GUI UPDATE
            expBar.UpdateExpBar(currentScene);
        }
        catch (Exception e)
        {
            Debug.LogError("No experience system allowed in a non-stage scene. If this is a developer scene, default.");
            Debug.LogError("Exception in EndgameSummary:" + e);
        }
        

    }



}
