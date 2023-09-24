using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFreezingController : MonoBehaviour
{
    //DATA
    [SerializeField] private ParticleSystem glow;
    [SerializeField] private ParticleSystem persistent;
    [SerializeField] private SpriteRenderer iceBlockSprite;
    [SerializeField] private ParticleSystem frozenWord;


    //METHODS
    //...

    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("UFOFreezingController");
        if (!glow.isPlaying) glow.Play();
        if (!persistent.isPlaying) persistent.Play();
        iceBlockSprite.gameObject.SetActive(true);
        if (!frozenWord.isPlaying) frozenWord.Play();
    }

    void OnDisable()
    {
        glow.Stop();
        persistent.Stop();
        iceBlockSprite.gameObject.SetActive(false);
        frozenWord.Stop();
    }

}
