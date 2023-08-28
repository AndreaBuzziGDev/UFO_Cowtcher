using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossionFeedItem : MonoBehaviour
{
    //DATA
    [SerializeField] private float persistenceTimerMax = 3.0f;
    private float persistenceTimer;

    [SerializeField] [Range(1, 3)] private int moossionIndex = 1;



    //METHODS
    //...
    void Start()
    {
        //REGISTER EVENT
        Moossion.MoossionComplete += HandleMoossionCompletion;

        //TEXT ON START = EMPTY


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


    //UTILITIES
    private string getNotificationContent() => "Moossion #" + moossionIndex + " complete!";




    //EVENT-HANDLING
    private void HandleMoossionCompletion(object sender, MoossionCompleteEventArgs e)
    {
        if(e.MoossionIndex == moossionIndex)
        {
            this.gameObject.SetActive(true);
            persistenceTimer = persistenceTimerMax;
        }
    }



}
