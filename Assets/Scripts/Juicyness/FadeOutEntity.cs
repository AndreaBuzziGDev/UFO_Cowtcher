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
    [SerializeField] private SpriteRenderer hologramSpriteRenderer;
    [SerializeField] private TMPro.TextMeshPro hologramText;

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

        if(hologramSpriteRenderer != null)
        {
            hologramSpriteRenderer.color = new Color(hologramSpriteRenderer.color.r, hologramSpriteRenderer.color.g, hologramSpriteRenderer.color.b, factor);
        }

        if (hologramText != null)
        {
            hologramText.color = new Color(hologramText.color.r, hologramText.color.g, hologramText.color.b, factor);
        }
    }


    //FUNCTIONALITIES
    public static void SpawnFadeOutEntity(FadeOutEntity prefab, Vector3 coords, bool flipX = false, Transform parentItem = null)
    {
        //TODO: THIS IS NOT WORKING CORRECTLY
        FadeOutEntity fo;
        if (parentItem != null)
        {
            fo = Instantiate(prefab, coords, Quaternion.identity, parentItem);
        }
        else
        {
            fo = Instantiate(prefab, coords, Quaternion.identity, null);
        }

        fo.hologramSpriteRenderer.flipX = flipX;
    }


}
