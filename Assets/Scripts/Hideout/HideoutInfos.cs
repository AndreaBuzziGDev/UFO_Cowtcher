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
    //FADE IN


    //FADE OUT


    //FADE OUT TIMER


    //FADE DISTANCE





    //METHODS
    //...
    //START
    //TODO: FIND UFO

    //UPDATE
    //


    //FUNCTIONALITIES
    public void UpdateCounter(int currentCount, int maxCapacity) => hideoutCounter.text = currentCount + "/" + maxCapacity;



    //JUICYNESS
    //FADING WHEN UFO IS FAR



}
