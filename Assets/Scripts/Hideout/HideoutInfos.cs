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
    [SerializeField] private float outerDistanceMaxFading = 3.5f;
    [SerializeField] private float innerDistanceMinFading = 2.5f;

    //FADE COLOR
    private Color cowLogoBaseColor;
    private Color textInfoBaseColor;




    //METHODS
    //...
    //START
    private void Start()
    {
        myUFO = GameController.Instance.FindUFOAnywhere();
        cowLogoBaseColor = cowLogo.color;
        textInfoBaseColor = hideoutCounter.color;
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
        //
        float distanceXZ = (GetPositionXZ() - myUFO.GetPositionXZ()).magnitude;

        //
        if (distanceXZ > outerDistanceMaxFading)
        {

            cowLogo.color = new Color(cowLogoBaseColor.r, cowLogoBaseColor.g, cowLogoBaseColor.b, 0);
            hideoutCounter.color = new Color(textInfoBaseColor.r, textInfoBaseColor.g, textInfoBaseColor.b, 0);
        }
        else
        {
            //
            float baseDistanceDiff = outerDistanceMaxFading - innerDistanceMinFading;

            //
            float ufoDistanceDiff = (distanceXZ < innerDistanceMinFading) ? innerDistanceMinFading : distanceXZ;
            
            //
            float differenceBetweenTwo = outerDistanceMaxFading - ufoDistanceDiff;

            //
            float opacity = 1 - ((baseDistanceDiff - differenceBetweenTwo)/ baseDistanceDiff);

            //
            cowLogo.color = new Color(cowLogoBaseColor.r, cowLogoBaseColor.g, cowLogoBaseColor.b, opacity);
            hideoutCounter.color = new Color(textInfoBaseColor.r, textInfoBaseColor.g, textInfoBaseColor.b, opacity);
        }

    }



    //UTILITIES
    public Vector3 GetPositionXZ()
    {
        return new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }


}
