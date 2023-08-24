using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    //DATA

    //OPENING MUSIC
    [SerializeField] private AudioClip openingMusic;

    //GAMEPLAY MUSIC
    [SerializeField] private AudioClip gameplayMusic;

    //MOOSSIONS COMPLETION MUSIC
    [SerializeField] private AudioClip moossionsCompletionMusic;

    private void OnEnable()
    {
        MainMenuController.Instance.gameObject.SetActive(true);
    }

    public void PlayMusic()
    {
        
    }
}
