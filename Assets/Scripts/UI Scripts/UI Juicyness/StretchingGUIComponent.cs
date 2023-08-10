using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchingGUIComponent : MonoBehaviour
{
    //DATA

    ///SHAKE VARIABLES
    [Header("Stretching Settings")]
    //[SerializeField] private float stretchAmount;//UN-IMPLEMENTED VERTICAL STRETCH
    [SerializeField] private float horizontalStretch;//X Axis
    [SerializeField] private float horizontalStretchSpeed;



    //METHODS
    //...

    // Update is called once per frame
    void Update()
    {
        animateStretchingGUI();
    }



    //JUICYNESS
    private void animateStretchingGUI()
    {
        
        transform.position = new Vector3(
            transform.localScale.x + Mathf.Sin(Time.unscaledTime * horizontalStretchSpeed) * horizontalStretch,
            transform.localScale.y,
            transform.localScale.z
            );
        
    }

}
