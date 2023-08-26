using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoSingleton<MusicController>
{
    //DATA
    [SerializeField] private AudioSource[] Sources;

    private void Start()
    {
        Sources = GetComponents<AudioSource>();
    }

    public void PlayClip(AudioClip _clip)
    {
        for (int i = 0; i < Sources.Length; i++) 
        {
            if (!Sources[i].isPlaying) 
            {
                Sources[i].clip = _clip;
                Sources[i].Play();
                break;
            }
        }
    }
}
