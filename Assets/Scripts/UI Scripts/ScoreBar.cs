using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO: MAKE THIS A MONOSINGLETON?
public class ScoreBar : MonoBehaviour
{
    //DATA
    ///SCORES
    private int scoreValue = 0;
    public int Score { get { return scoreValue; } }

    private int capturedCows = 0;
    public int CapturedCows { get { return capturedCows; } }


    ///TIMER - 1 SEC, 1 SCORE
    private float scoreTimer;

    ///TIME ELAPSED TIMER
    private float timeElapsed = 0;
    public float TimeElapsed { get { return timeElapsed; } }


    ///GUI REFERENCES
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;




    //METHODS
    //...
    void Awake()
    {
        //RESETTING SCORES
        scoreValue = 0;
        capturedCows = 0;
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

        timeElapsed += Time.deltaTime;
    }



    //ENABLE-DISABLE
    void OnEnable()
    {
        //REGISTER EVENTS
        Abductor.CowCapture += HandleCowCapture;
        SASharkBite.SharkBite += HandleSharkBite;

    }
    private void OnDisable()
    {
        Abductor.CowCapture -= HandleCowCapture;
        SASharkBite.SharkBite -= HandleSharkBite;
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



    //EVENT HANDLING

    public void HandleCowCapture(object sender, CowCaptureEventArgs e)
    {
        capturedCows++;
    }

    private void HandleSharkBite(object sender, SharkBiteEventArgs e)
    {
        if (UFOStatusAlterationHelper.HasPositiveAlterations())
            UFOStatusAlterationHelper.FlushPositiveAlterations();
        else
        {
            //INSTANTLY LOSE % CURRENT SCORE
            int scoreLoss = (int)(scoreValue * (e.CurrentScoreLoss / 100));
            scoreValue = scoreValue - scoreLoss;
            if (scoreValue < 0) 
                scoreValue = 0;
            scoreText.text = scoreValue.ToString();
        }


    }
}
