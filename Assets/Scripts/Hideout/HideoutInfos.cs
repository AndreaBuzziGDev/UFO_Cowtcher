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


    ///JUICYNESS - FADING
    //UFO
    private UFO myUFO;

    //PARTIAL FADING AT 100% OF COW LOGO
    [SerializeField] [Range(1, 100f)] private float cowLogoPartialFading = 80f;

    //FADE DISTANCE
    [SerializeField] private float outerDistanceMaxFading = 3.5f;
    [SerializeField] private float innerDistanceMinFading = 2.5f;

    //HOSTING TIMER
    [SerializeField] private float hostingShowUpTimer = 2.5f;
    private bool isHostCowOpaque;

    //FADE COLOR
    private Color cowLogoBaseColor;
    private Color textInfoBaseColor;

    //IS HOSTING?
    private bool isHosting;




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
    //TODO: THIS EVENTUALLY CAN BE IMPROVED WITH AN EVENT SYSTEM, BUT IT MIGHT IMPLY SOME REWORKS AND SEVERAL TESTS
    public void UpdateCounter(int currentCount, int maxCapacity)
    {
        hideoutCounter.text = currentCount + "/" + maxCapacity;
        isHosting = currentCount > 0;
    }



    //JUICYNESS
    //INSTANT-OPACITY WHEN NEW HOSTING STARTED
    public void HandleHost() => StartCoroutine(HostCowOpacity());

    //FADING WHEN UFO IS FAR
    private void HandleFading()
    {
        //
        float distanceXZ = (GetPositionXZ() - myUFO.GetPositionXZ()).magnitude;

        //
        if (!isHostCowOpaque)
        {
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
                float opacity = 1 - ((baseDistanceDiff - differenceBetweenTwo) / baseDistanceDiff);

                //
                cowLogo.color = new Color(cowLogoBaseColor.r, cowLogoBaseColor.g, cowLogoBaseColor.b, opacity * (cowLogoPartialFading / 100));
                hideoutCounter.color = new Color(textInfoBaseColor.r, textInfoBaseColor.g, textInfoBaseColor.b, opacity);
            }
        }
    }



    //UTILITIES
    public Vector3 GetPositionXZ()
    {
        return new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }


    //COROUTINES
    private IEnumerator HostCowOpacity()
    {
        Debug.Log("Started Coroutine");
        isHostCowOpaque = true;

        //STARTS AT MAX OPACITY
        cowLogo.color = new Color(cowLogoBaseColor.r, cowLogoBaseColor.g, cowLogoBaseColor.b, 1);
        hideoutCounter.color = new Color(textInfoBaseColor.r, textInfoBaseColor.g, textInfoBaseColor.b, 1);

        //WAITS
        yield return new WaitForSeconds(hostingShowUpTimer);

        Debug.Log("Ended Coroutine");
        isHostCowOpaque = false;
    }

}
