using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFearController : MonoBehaviour
{
    //DATA
    [SerializeField] private ParticleSystem terrorWord;
    [SerializeField] private ParticleSystem ghosts;

    //METHODS
    //...

    //
    void OnEnable()
    {
        if (!terrorWord.isPlaying) terrorWord.Play();
        if (!ghosts.isPlaying) ghosts.Play();
    }

    void FixedUpdate()
    {
        if(!terrorWord.isPlaying && GameController.Instance.FindPlayerAnywhere().IsTerrified)
            terrorWord.Play();
    }

    void OnDisable()
    {
        if (terrorWord.isPlaying) terrorWord.Stop();
        if (ghosts.isPlaying) ghosts.Stop();
    }
}
