using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayInputCanvas : MonoBehaviour
{
    //DATA
    [SerializeField] Image myJoystickBackground;
    [SerializeField] Image myJoystick;

    //TODO: MOVE FEED STUFF (REFERENCES AND METHODS) HERE?


    //METHODS
    //...
    public void ShowJoystick(Vector2 position)
    {
        /*
        Image joystick = null;

        Image[] joysticks = GetComponentsInChildren<Image>(true);

        foreach (Image image in joysticks)
        {
            if (image.transform.parent == transform)
                joystick = image;
            else
                image.enabled = true;
        }

        RectTransform joystickRect = joystick.GetComponent<RectTransform>();
        joystickRect.position = position;
        joystick.enabled = true;
        */
        myJoystickBackground.enabled = true;
        myJoystickBackground.GetComponent<RectTransform>().position = position;
        myJoystick.enabled = true;
    }

    public void HideJoystick()
    {
        /**/
        Image[] joysticks = GetComponentsInChildren<Image>(true);

        foreach (Image image in joysticks)
        {
            image.enabled = false;
        }
    }



}
