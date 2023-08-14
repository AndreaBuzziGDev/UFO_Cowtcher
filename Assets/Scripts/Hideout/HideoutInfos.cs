using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideoutInfos : MonoBehaviour
{
    //DATA
    ///UI REFERENCE
    [SerializeField] private SpriteRenderer cowLogo;
    [SerializeField] private TMPro.TextMeshPro hideoutCounter;




    ///JUICYNESS
    //UFO
    private UFO myUFO;

    //FADE DISTANCE
    [SerializeField] private float maxFadingXZDistance = 3;
    [SerializeField] private float minFadingXZDistance = 1;

    //CURRENT FADING





    //METHODS
    //...
    //START
    private void Start()
    {
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

    }

}
