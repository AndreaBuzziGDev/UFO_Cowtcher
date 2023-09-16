using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureFeedItem : MonoBehaviour
{
    //DATA
    [SerializeField] private float persistenceTimerMax = 5.0f;
    private float persistenceTimer;

    ///GUI REFERENCES
    [SerializeField] private TMPro.TextMeshProUGUI feedItemText;




    //METHODS
    //...
    void Start()
    {
        //REGISTER EVENT
        Abductor.CowCapture += HandleCowCapture;

        //TEXT ON START = EMPTY
        feedItemText.text = "";

        //DISABLE ON GUI
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (persistenceTimer > 0)
        {
            persistenceTimer -= Time.deltaTime;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }


    private void OnDestroy()
    {
        //UN-REGISTER EVENT
        Abductor.CowCapture -= HandleCowCapture;
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

        //TODO: EXECUTE GUI ANIMATION
    }

}
