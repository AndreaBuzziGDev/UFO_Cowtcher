using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    AudioSource[] musicSources;

    private void Awake()
    {
        musicSources = GetComponents<AudioSource>();
    }

    public void Play (AudioClip _clip)
    {
        for(int i = 0; i < musicSources.Length; i++)
        {
            if (!musicSources[i].isPlaying)
            {
                musicSources[i].clip = _clip;
                musicSources[i].Play();
                break;
            }
        }
    }
}
