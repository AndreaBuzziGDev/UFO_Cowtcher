using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureFeedItem : MonoBehaviour
{
    //DATA
    [SerializeField] private float persistenceTimerMax = 3.0f;
    private float persistenceTimer;

    ///GUI REFERENCES
    [SerializeField] private TMPro.TextMeshProUGUI feedItemText;

    ///GUI ANIMATION STUFF
    //TODO: THIS COULD BE IMPROVED BY PROGRAMMATICALLY LOOKING FOR THE SIZE OF THE SCREEN
    [SerializeField] private Vector3 slidingOffset = new Vector3(500, 0, 0);
    private Vector3 startingPos = Vector3.zero;

    [SerializeField] private float slideInTimerMax = 1.0f;
    private float slideInTimer;

    ///DEBUG
    [SerializeField] private bool isDebug;



    //METHODS
    //...
    void Start()
    {
        //REGISTER EVENT
        Abductor.CowCapture += HandleCowCapture;

        //DEFAULT POSITION
        startingPos = this.transform.position;

        //TEXT ON START = EMPTY
        feedItemText.text = "TEST CAPTURE FEED";//TODO: SET EMPTY

        //HANDLE DEBUG OR DISABLE ON GUI
        if (isDebug)
        {
            persistenceTimer = persistenceTimerMax;
            slideInTimer = slideInTimerMax;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }


    private void FixedUpdate()
    {
        //HANDLE SLIDE-IN
        HandleSlideIn();

        //HANDLE PERSISTENCE ON SCREEN
        HandlePersistence();
    }


    private void OnDestroy()
    {
        //UN-REGISTER EVENT
        Abductor.CowCapture -= HandleCowCapture;
    }


    //FUNCTIONALITIES

    ///SLIDE-IN
    private void HandleSlideIn()
    {
        this.transform.position = Vector3.Lerp(startingPos, startingPos + slidingOffset, EaseInQuad(slideInTimer / slideInTimerMax));//TODO: EASING
        if (slideInTimer > 0) slideInTimer -= Time.fixedDeltaTime;
        else slideInTimer = 0;
    }

    ///PERSISTENCE ON SCREEN
    private void HandlePersistence() 
    {
        if (persistenceTimer > 0) persistenceTimer -= Time.fixedDeltaTime;
        else this.gameObject.SetActive(false);
    }






    //EVENT-HANDLING
    private void HandleCowCapture(object sender, CowCaptureEventArgs e)
    {
        //SHOW MOOSSION FEED ITEM AND ITS CONTENT
        if (e.IsNewlyCaptured)
        {
            persistenceTimer = persistenceTimerMax;
            feedItemText.text = "Captured new Cow: " + e.CapturedCow.CowTemplate.CowName;
            this.gameObject.SetActive(true);
        }

        //EXECUTE GUI ANIMATION
        slideInTimer = slideInTimerMax;
    }


    //EASING
    public static float EaseInQuad(float t) => t * t;

}
