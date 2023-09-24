using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMalfunctionController : MonoBehaviour
{
    //DATA
    [SerializeField] private ParticleSystem smallBurstLoop1;
    [SerializeField] private ParticleSystem smallBurstLoop2;
    [SerializeField] private ParticleSystem glow;
    [SerializeField] private ParticleSystem rain;
    [SerializeField] private ParticleSystem stunWord;


    //METHODS
    //...

    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("UFOMalfunctionController");
        smallBurstLoop1.Play();
        smallBurstLoop2.Play();
        glow.Play();
        rain.Play();
        stunWord.Play();
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
        smallBurstLoop1.Stop();
        smallBurstLoop2.Stop();
        glow.Stop();
        rain.Stop();
        stunWord.Stop();
    }

}
