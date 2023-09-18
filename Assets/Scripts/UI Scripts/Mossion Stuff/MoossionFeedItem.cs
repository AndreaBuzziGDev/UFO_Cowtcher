using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoossionFeedItem : MonoBehaviour
{
    //DATA
    [SerializeField] private float persistenceTimerMax = 5.0f;
    private float persistenceTimer;

    ///GUI REFERENCES
    [SerializeField] private TMPro.TextMeshProUGUI feedItemText;

    //TODO: THIS CODE IS COPIED FROM CaptureFeedItem - IF TIME IS AVAILABLE, USE INHERITANCE TO PROPERLY FACTOR CODE
    ///GUI ANIMATION STUFF
    //TODO: THIS COULD BE IMPROVED BY PROGRAMMATICALLY LOOKING FOR THE SIZE OF THE SCREEN
    [SerializeField] private Vector3 slidingOffset = new Vector3(500, 0, 0);
    private Vector3 startingPos = Vector3.zero;

    [SerializeField] private float slideInTimerMax = 1.0f;
    private float slideInTimer;



    //METHODS
    //...
    void Start()
    {
        //REGISTER EVENT
        Moossion.MoossionComplete += HandleMoossionCompletion;

        //DEFAULT POSITION
        startingPos = this.transform.position;

        //TEXT ON START = EMPTY
        feedItemText.text = "TEST MOOSSION FEED";

        //DISABLE ON GUI
        //TODO: UN-COMMENT
        //this.gameObject.SetActive(false);

        //TODO: REMOVE
        persistenceTimer = persistenceTimerMax;
        slideInTimer = slideInTimerMax;
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
    private void HandleMoossionCompletion(object sender, MoossionCompleteEventArgs e)
    {
        //SHOW MOOSSION FEED ITEM AND ITS CONTENT
        persistenceTimer = persistenceTimerMax;
        feedItemText.text = "Moossion #" + e.MoossionIndex + " complete!";
        this.gameObject.SetActive(true);
    }


    //EASING
    public static float EaseInQuad(float t) => t * t;

}
