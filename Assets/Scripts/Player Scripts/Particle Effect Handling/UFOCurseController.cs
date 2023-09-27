using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOCurseController : MonoBehaviour
{
    //DATA
    [SerializeField] private ParticleSystem cursedWord;
    [SerializeField] private ParticleSystem poisonFog;

    //METHODS
    //...

    //
    void OnEnable()
    {
        if (!cursedWord.isPlaying) cursedWord.Play();
        if (!poisonFog.isPlaying) poisonFog.Play();
    }

    void OnDisable()
    {
        if (cursedWord.isPlaying) cursedWord.Stop();
        if (poisonFog.isPlaying) poisonFog.Stop();
    }
}
