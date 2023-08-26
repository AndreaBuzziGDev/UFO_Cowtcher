using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoSingleton<MusicController>
{
    //DATA

    //OPENING GAME MUSIC
    [SerializeField] AudioClip openingGameMusic;

    //GAMEPLAY MUSIC
    [SerializeField] AudioClip gameplayMusic;

    //MOOSSIONS COMPLETION MUSIC
    [SerializeField] AudioClip moossionsCompletionMusic;

    private void Start()
    {

    }

    public void PlayClip(AudioClip _clip)
    {

    }
}
