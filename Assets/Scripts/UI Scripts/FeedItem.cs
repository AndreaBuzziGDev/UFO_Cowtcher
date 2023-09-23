using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedItem : MonoBehaviour
{
    //ENUMS
    public enum Type
    {
        Moossion,
        Capture
    }

    //DATA
    //
    [SerializeField] private Type type = 0;

    ///GUI REFERENCES
    private CanvasGroup canvasGroup;

    ///GUI - PERSISTENCE
    [SerializeField] private float persistenceTimerMax = 3.0f;
    [SerializeField] private float persistenceFadeoutThreshold = 1f;
    private float persistenceTimer;

    ///GUI - ANIMATION
    //TODO: THIS COULD BE IMPROVED BY PROGRAMMATICALLY LOOKING FOR THE SIZE OF THE SCREEN
    private Vector3 slidingOffset = new Vector3(500, 0, 0);
    private Vector3 startingPos = Vector3.zero;

    [SerializeField] private float slideInTimerMax = 1.0f;
    [SerializeField] private float slideOutTimerMax = 1.0f;
    private float slideInTimer;
    private float slideOutTimer;

    bool hasSlidIn;
    bool hasPersisted;
    bool hasSlidOut;


    ///DEBUG
    [SerializeField] private bool isDebug;


    ///SPRITE ANIMATION
    [SerializeField] private UISpriteAnimation spriteToAnimate;




    //METHODS
    //...
    void Start()
    {
        //REGISTER EVENT
        if(type == Type.Moossion)
            Moossion.MoossionComplete += HandleMoossionCompletion;
        else if(type == Type.Capture)
            Abductor.CowCapture += HandleCowCapture;

        //DEFAULT POSITION
        startingPos = this.transform.position;

        //GUI INITIALIZE
        canvasGroup = GetComponent<CanvasGroup>();
        slidingOffset = new Vector3(GetComponent<RectTransform>().rect.width, 0, 0);

        //HANDLE DEBUG OR DISABLE ON GUI
        if (isDebug)
        {
            //feedItemText.text = "TEST CAPTURE FEED";
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
        if(!hasSlidIn)
            HandleSlideIn();

        //HANDLE PERSISTENCE ON SCREEN
        if (!hasPersisted)
            HandlePersistence();

        //HANDLE SLIDE-OUT
        if (hasPersisted && hasSlidIn)
            HandleSlideOut();

        if (hasSlidOut)
            this.gameObject.SetActive(false);

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
        this.transform.position = Vector3.Lerp(startingPos, startingPos + slidingOffset, EaseInQuad(slideInTimer / slideInTimerMax));
        if (slideInTimer > 0) slideInTimer -= Time.fixedDeltaTime;
        else
        {
            slideInTimer = 0;
            hasSlidIn = true;
            spriteToAnimate.Func_PlayUIAnim();
        }

    }

    ///PERSISTENCE ON SCREEN
    private void HandlePersistence()
    {
        if (persistenceTimer > 0)
        {
            persistenceTimer -= Time.fixedDeltaTime;
            /*
            if (persistenceTimer <= persistenceFadeoutThreshold)
            {
                this.canvasGroup.alpha = Mathf.Lerp(0, 1, persistenceTimer / persistenceFadeoutThreshold);
            }
            */
        }
        else
        {
            persistenceTimer = 0;
            spriteToAnimate.Func_PlayUIAnim();
        }
    }

    private void HandleSlideOut()
    {
        this.transform.position = Vector3.Lerp(startingPos, startingPos + slidingOffset, EaseInQuad(slideInTimer / slideInTimerMax));
        if (slideOutTimer > 0) slideOutTimer -= Time.fixedDeltaTime;
        else
        {
            slideOutTimer = 0;
            hasSlidOut = true;
        }
    }






    //EVENT-HANDLING
    private void HandleMoossionCompletion(object sender, MoossionCompleteEventArgs e)
    {
        startSlideAnimation();
    }

    private void HandleCowCapture(object sender, CowCaptureEventArgs e)
    {
        if (e.IsNewlyCaptured)
            startSlideAnimation();
    }

    private void startSlideAnimation()
    {

        //SHOW FEED ITEM AND ITS CONTENT
        persistenceTimer = persistenceTimerMax;
        slideInTimer = slideInTimerMax;
        slideOutTimer = slideOutTimerMax;

        hasSlidIn = false;
        hasPersisted = false;
        hasSlidOut = false;

        this.canvasGroup.alpha = 1;
        this.transform.position = startingPos + slidingOffset;

        this.gameObject.SetActive(true);

        //EXECUTE GUI ANIMATION
        slideInTimer = slideInTimerMax;
    }



    //EASING
    public static float EaseInQuad(float t) => t * t;

}
