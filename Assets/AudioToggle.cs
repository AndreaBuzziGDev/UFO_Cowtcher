using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioToggle : MonoBehaviour
{
    //DATA
    [SerializeField] private Button targetButton;
    [SerializeField] private bool isAudioActiveButton;

    //EVENT HANDLER
    public static EventHandler<EventArgs> toggleAudioEventArg;


    //METHODS
    //...

    private void OnEnable()
    {
        if (isAudioActiveButton)
        {
            if (PlayerPrefs.GetInt("Volume", 1) > 0)
            {
                this.gameObject.SetActive(PlayerPrefs.GetInt("Volume", 1) > 0);
                targetButton.gameObject.SetActive(!(PlayerPrefs.GetInt("Volume", 1) > 0));
            }
        }
    }

    //FUNCTIONALITIES
    public void ChangeButton()
    {
        if (this.enabled)
        {
            if (this.gameObject.name.Equals("AudioButton"))
            {
                PlayerPrefs.SetInt("Volume", 0);
            }
            else
            {
                PlayerPrefs.SetInt("Volume", 1);
            }
            targetButton.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
        Debug.Log(PlayerPrefs.GetInt("Volume"));

        OnAudioToggle(new EventArgs());
    }



    //EVENT STUFF
    private void OnAudioToggle(EventArgs e)
    {
        EventHandler<EventArgs> handler = toggleAudioEventArg;
        if (handler != null)
        {
            handler(this, e);
        }
    }

}
