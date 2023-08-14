using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideoutInfos : MonoBehaviour
{
    //DATA
    ///RENDERER
    Renderer rend;

    ///UI REFERENCE
    [SerializeField] private SpriteRenderer cowLogo;
    [SerializeField] private TMPro.TextMeshPro hideoutCounter;




    ///JUICYNESS
    //UFO
    private UFO myUFO;

    //FADE DISTANCE
    [SerializeField] private float maxFadingXZDistance = 3;
    [SerializeField] private float minFadingXZDistance = 1;

    //FADING TRANSPARENCE
    [SerializeField] private float opacity = 0.1f;





    //METHODS
    //...
    //START
    private void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        myUFO = GameController.Instance.FindUFOAnywhere();
    }

    //UPDATE
    private void Update()
    {
        HandleFading();
    }


    //FUNCTIONALITIES
    public void UpdateCounter(int currentCount, int maxCapacity) => hideoutCounter.text = currentCount + "/" + maxCapacity;



    //JUICYNESS
    //FADING WHEN UFO IS FAR
    private void HandleFading()
    {
        rend.material.color = new Color(255, 255, 255, opacity);
    }

}
