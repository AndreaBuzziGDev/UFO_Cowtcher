using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //MAKE THE INTENDED MUSIC PLAY
        PlayBackgroundMusicCorrectlyBasedOnScene();
    }


    //FUNCTIONALITIES
    private void PlayBackgroundMusicCorrectlyBasedOnScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        switch (currentSceneName)
        {
            case "Stage 1":
            case "Stage 2":
            case "Stage 3":
            case "Stage 4":
                PlayMusic(gameplayMusic, activeMusicSource);
                break;
            case "Main Menu":
                PlayMusic(openingGameMusic, activeMusicSource);
                break;
            default:
                PlayMusic(gameplayMusic, activeMusicSource);
                break;
        }

    }




    //UTILITIES
    private void PlayMusic(AudioClip music, AudioSource audioSource)
    {
        audioSource.clip = music;
        audioSource.Play();
    }

}
