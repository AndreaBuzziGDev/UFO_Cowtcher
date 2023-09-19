using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayInputCanvas : MonoBehaviour
{
    //DATA
    [SerializeField] private Image joystick;

    //TODO: MOVE FEED STUFF (REFERENCES AND METHODS) HERE?


    //METHODS
    //...
    public void ShowJoystick(Vector2 position)
    {
        RectTransform joystickRect = joystick.GetComponent<RectTransform>();
        joystickRect.position = position;
        joystick.enabled = true;
    }

    public void HideJoystick()
    {
        joystick.enabled = false;
    }



}
