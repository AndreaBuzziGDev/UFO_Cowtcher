using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFearController : MonoBehaviour
{
    //DATA
    /*
    [SerializeField] private ParticleSystem cursedWord;
    [SerializeField] private ParticleSystem poisonFog;
    */

    //METHODS
    //...

    //
    void OnEnable()
    {
        Debug.Log("UFOFearController");
        /*
        if (!smallBurstLoop1.isPlaying) smallBurstLoop1.Play();
        if (!smallBurstLoop2.isPlaying) smallBurstLoop2.Play();
        if (!glow.isPlaying) glow.Play();
        if (!rain.isPlaying) rain.Play();
        if (!stunWord.isPlaying) stunWord.Play();
        */
    }

    void OnDisable()
    {
        /*
        smallBurstLoop1.Stop();
        smallBurstLoop2.Stop();
        glow.Stop();
        rain.Stop();
        stunWord.Stop();
        */
    }
}
