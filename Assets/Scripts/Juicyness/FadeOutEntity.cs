using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutEntity : MonoBehaviour
{
    //DATA
    ///
    [SerializeField] private float fadeoutTimerMax = 1.0f;
    private float fadeoutTimer;

    ///GUI REFERENCES
    [SerializeField] private SpriteRenderer sr;

    //METHODS
    //...
    private void OnEnable()
    {
        fadeoutTimer = fadeoutTimerMax;
    }

    private void Update()
    {
        fadeoutTimer -= Time.deltaTime;
        float factor = fadeoutTimer / fadeoutTimerMax;

        //TODO: USE COLOR LERP
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, factor);
    }


    //FUNCTIONALITIES
    public static void SpawnFadeOutEntity(FadeOutEntity prefab, Vector3 coords, bool flipX = false)
    {
        FadeOutEntity fo = Instantiate(prefab, coords, Quaternion.identity);
        //TODO: SPRITE SHOULD BE FLIPPED IN THE SAME DIRECTION AS THE COW THAT SPAWNED IT
        fo.sr.flipX = flipX;
    }


}
