using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningFading : MonoBehaviour
{
    //DATA
    [SerializeField] private Image myLogo;
    private Color fullColor;
    private Color transparentColor;

    [SerializeField] private float fullLogoEasingTimeMax = 2.0f;

    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        fullColor = myLogo.color;
        transparentColor = new Color(fullColor.r, fullColor.g, fullColor.b, 0);
    }

    private void Update()
    {
        myLogo.color = Color.Lerp(transparentColor, fullColor, EaseInQuad(Time.time/fullLogoEasingTimeMax));
    }

    //EASING
    public static float EaseInQuad(float t) => t * t;

}
