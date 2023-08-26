using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    //DATA

    //OPENING GAME MUSIC
    [SerializeField] AudioClip openingGameMusic;

    //GAMEPLAY MUSIC
    [SerializeField] AudioClip gameplayMusic;

    //MOOSSIONS COMPLETION MUSIC
    [SerializeField] AudioClip moossionsCompletionMusic;

    private AudioSource musicSource1;
    private AudioSource musicSource2;
    private AudioSource activeMusicSource;
    private AudioSource secondaryMusicSource;

    private void Awake()
    {
        musicSource1 = gameObject.AddComponent<AudioSource>();
        musicSource1.loop = true;
        musicSource1.volume = 0f;
        musicSource2 = gameObject.AddComponent<AudioSource>();
        musicSource2.loop = true;
        musicSource2.volume = 0f;

        activeMusicSource = musicSource1;
        secondaryMusicSource = musicSource2;
    }

    private void OnEnable()
    {

    }

    private void PlayMusic(AudioClip music, AudioSource audioSource, float volume)
    {
        audioSource.clip = music;
        audioSource.volume = volume;
        audioSource.Play();
    }

}
