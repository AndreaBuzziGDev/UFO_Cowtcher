using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoossionFeedItem : MonoBehaviour
{
    //DATA

    ///GUI REFERENCES
    [SerializeField] private TMPro.TextMeshProUGUI feedItemText;
    private CanvasGroup canvasGroup;

    ///GUI - PERSISTENCE
    [SerializeField] private float persistenceTimerMax = 3.0f;
    [SerializeField] private float persistenceFadeoutThreshold = 1f;
    private float persistenceTimer;

    ///GUI - ANIMATION 
    //TODO: THIS CODE IS COPIED FROM CaptureFeedItem - IF TIME IS AVAILABLE, USE INHERITANCE TO PROPERLY FACTOR CODE
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
        Moossion.MoossionComplete += HandleMoossionCompletion;

        //DEFAULT POSITION
        startingPos = this.transform.position;

        //GUI INITIALIZE
        canvasGroup = GetComponent<CanvasGroup>();

        //HANDLE DEBUG OR DISABLE ON GUI
        if (isDebug)
        {
            feedItemText.text = "TEST MOOSSION FEED";
            persistenceTimer = persistenceTimerMax;
            slideInTimer = slideInTimerMax;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //HANDLE SLIDE-IN
        HandleSlideIn();

        //HANDLE PERSISTENCE ON SCREEN
        HandlePersistence();
    }


    private void OnDestroy()
    {
        //UN-REGISTER EVENT
        Moossion.MoossionComplete -= HandleMoossionCompletion;
    }


    //FUNCTIONALITIES

    ///SLIDE-IN
    private void HandleSlideIn()
    {
        this.transform.position = Vector3.Lerp(startingPos, startingPos + slidingOffset, EaseInQuad(slideInTimer / slideInTimerMax));
        if (slideInTimer > 0) slideInTimer -= Time.fixedDeltaTime;
        else slideInTimer = 0;
    }

    ///PERSISTENCE ON SCREEN
    private void HandlePersistence()
    {
        if (persistenceTimer > 0)
        {
            persistenceTimer -= Time.fixedDeltaTime;
            if(persistenceTimer <= persistenceFadeoutThreshold)
            {
                this.canvasGroup.alpha = Mathf.Lerp(0, 1, persistenceTimer / persistenceFadeoutThreshold);
            }
        }
        else this.gameObject.SetActive(false);
    }






    //EVENT-HANDLING
    private void HandleMoossionCompletion(object sender, MoossionCompleteEventArgs e)
    {
        //SHOW FEED ITEM AND ITS CONTENT
        persistenceTimer = persistenceTimerMax;
        slideInTimer = slideInTimerMax;
        this.canvasGroup.alpha = 1;
        this.transform.position = startingPos + slidingOffset;

        feedItemText.text = "Moossion #" + e.MoossionIndex + " complete!";
        this.gameObject.SetActive(true);
    }


    //EASING
    public static float EaseInQuad(float t) => t * t;

}
