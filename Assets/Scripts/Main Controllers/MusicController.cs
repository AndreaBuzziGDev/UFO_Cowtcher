using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicController : MonoSingleton<MusicController>
{
    //DATA

    //OPENING GAME MUSIC
    [SerializeField] AudioClip openingGameMusic;

    //GAMEPLAY MUSIC
    [SerializeField] AudioClip gameplayMusic;

    //MOOSSIONS COMPLETION MUSIC OR ENDING GAME MUSIC
    [SerializeField] AudioClip moossionsCompletionMusic;


    //AUDIO SOURCES
    private AudioSource activeMusicSource;
    private AudioSource secondaryMusicSource;



    //TODO: WHEN MAKING MUSIC PLAY BASED ON THE SCENE IT IS RUNNING IN, SWITCH TO AN "INITIALIZE" SOLUTION INSTEAD OF OnEnable
    private void OnEnable()
    {
        activeMusicSource = gameObject.AddComponent<AudioSource>();
        activeMusicSource.loop = true;

        secondaryMusicSource = gameObject.AddComponent<AudioSource>();
        activeMusicSource.loop = false;

        //MAKE THE INTENDED MUSIC PLAY
        //TODO: SELECT MUSIC CORRECTLY BASED ON THE ACTIVE SCENE
        PlayMusic(gameplayMusic, activeMusicSource, 1);

    }

    private void PlayMusic(AudioClip music, AudioSource audioSource, float volume)
    {
        audioSource.clip = music;
        audioSource.volume = volume;
        audioSource.Play();
    }

}
