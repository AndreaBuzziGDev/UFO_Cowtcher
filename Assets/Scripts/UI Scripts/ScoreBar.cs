using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    //DATA
    private int scoreValue = 0;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;


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
    }



}
