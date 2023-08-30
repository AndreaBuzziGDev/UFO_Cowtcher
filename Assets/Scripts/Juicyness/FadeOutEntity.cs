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
    public static void SpawnFadeOutEntity(FadeOutEntity prefab, Vector3 coords, bool flipX = false, Transform parentItem = null)
    {
        FadeOutEntity fo;
        if (parentItem != null)
        {
            fo = Instantiate(prefab, coords, Quaternion.identity, parentItem);
        }
        else
        {
            fo = Instantiate(prefab, coords, Quaternion.identity, null);
        }

        fo.sr.flipX = flipX;
    }


}
