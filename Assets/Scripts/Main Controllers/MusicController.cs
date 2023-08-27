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
    [SerializeField] private AudioSource activeMusicSource;
    [SerializeField] private AudioSource moossionCompleteSource;//TODO: IMPLEMENT "PLAY MOOSSION MUSIC" WHEN MOOSSION IS COMPLETED



    //TODO: WHEN MAKING MUSIC PLAY BASED ON THE SCENE IT IS RUNNING IN, SWITCH TO AN "INITIALIZE" SOLUTION INSTEAD OF OnEnable
    private void OnEnable()
    {
        activeMusicSource = gameObject.AddComponent<AudioSource>();
        activeMusicSource.loop = true;

        moossionCompleteSource = gameObject.AddComponent<AudioSource>();
        activeMusicSource.loop = false;

        //MAKE THE INTENDED MUSIC PLAY
        //TODO: SELECT MUSIC CORRECTLY BASED ON THE ACTIVE SCENE
        PlayMusic(gameplayMusic, activeMusicSource);

    }

    private void PlayMusic(AudioClip music, AudioSource audioSource)
    {
        audioSource.clip = music;
        audioSource.Play();
    }

}
