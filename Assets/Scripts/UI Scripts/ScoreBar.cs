using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    //DATA
    private int scoreValue = 0;
    public int Score { get { return scoreValue; } }

    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    private float scoreTimer;


    //METHODS
    //...
    void Awake()
    {
        scoreValue = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scoreValue.ToString();
        scoreTimer = 1;
    }

    private void Update()
    {
        //TODO:
        //EVERY SECOND: UPDATE SCORE BY 1
        if(scoreTimer > 0)
        {
            scoreTimer -= Time.deltaTime;

        }
        else
        {
            AddScore(1);
            scoreTimer = 1;
        }
    }




    //FUNCTIONALITIES
    public void ResetScore()
    {
        scoreValue = 0;
        scoreText.text = scoreValue.ToString();
    }


    //TODO: NICE TO HAVE FEATURE THAT ALLOWS TO KNOW THE "SOURCE" OF A SCORE INCREASE

    public void AddScore(int delta)
    {
        scoreValue += delta;
        scoreText.text = scoreValue.ToString();

        //SAVE HIGHSCORE
        SaveSystem.SaveHighScore(scoreValue);
    }

}
