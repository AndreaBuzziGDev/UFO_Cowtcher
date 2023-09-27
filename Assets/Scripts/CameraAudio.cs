using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraAudio : MonoBehaviour
{
    //DATA
    [SerializeField] private AudioListener myAudioListener;
    [SerializeField] private bool audioStateForceDisable;

    //METHODS
    //...

    // Start is called before the first frame update
    void Awake()
    {
        AudioToggle.toggleAudioEventArg += HandleAudioChanges;
        RefreshAudioState();
    }

    //FUNCTIONALITIES
    public void RefreshAudioState()
    {
        int audioEnablePref = PlayerPrefs.GetInt("Volume", 1);

        if (audioStateForceDisable)
            myAudioListener.enabled = false;
        else
            myAudioListener.enabled = (audioEnablePref > 0);
    }

    private void OnDisable()
    {
        AudioToggle.toggleAudioEventArg -= HandleAudioChanges;
    }



    //EVENT HANDLING
    public void HandleAudioChanges(object sender, EventArgs e)
    {
        myAudioListener.enabled = (PlayerPrefs.GetInt("Volume", 1)) > 0;
    }


}
