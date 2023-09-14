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




    //METHODS
    //...
    void Start()
    {
        //REGISTER EVENT
        Moossion.MoossionComplete += HandleMoossionCompletion;

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
        Moossion.MoossionComplete -= HandleMoossionCompletion;
    }


    

    //EVENT-HANDLING
    private void HandleMoossionCompletion(object sender, MoossionCompleteEventArgs e)
    {
        //SHOW MOOSSION FEED ITEM AND ITS CONTENT
        persistenceTimer = persistenceTimerMax;
        feedItemText.text = "Moossion #" + e.MoossionIndex + " complete!";
        this.gameObject.SetActive(true);
    }

}
