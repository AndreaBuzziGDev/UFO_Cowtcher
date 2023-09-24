using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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




    //EVENT HANDLING
    //TODO: COMPLETE AFTER MERGE WITH UI MODIFICATIONS HAS BEEN DONE

}
