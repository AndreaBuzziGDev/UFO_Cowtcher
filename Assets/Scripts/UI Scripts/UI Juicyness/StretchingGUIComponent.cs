using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchingGUIComponent : MonoBehaviour
{
    //DATA
    ///REFERENCE VARIABLES
    private float originalScaleX;
    private float originalScaleY;
    private float originalScaleZ;


    ///SHAKE VARIABLES
    [Header("Stretching Settings")]
    //[SerializeField] private float stretchAmount;//UN-IMPLEMENTED VERTICAL STRETCH
    [SerializeField] [Range(1.0f, 100.0f)] private float horizontalStretchPercent;//X Axis
    [SerializeField] private float horizontalStretchSpeed;





    //METHODS
    //...
    private void Start()
    {
        originalScaleX = transform.localScale.x;
        originalScaleY = transform.localScale.y;
        originalScaleZ = transform.localScale.z;
    }

    void Update()
    {
        animateStretchingGUI();
    }



    //JUICYNESS
    private void animateStretchingGUI()
    {
        float horizontalStretchFactor = Mathf.Sin(Time.unscaledTime * horizontalStretchSpeed) * (horizontalStretchPercent / 100);

        transform.localScale = new Vector3(
            originalScaleX * (1 + horizontalStretchFactor),
            originalScaleY,
            originalScaleZ
            );
        
    }

}
