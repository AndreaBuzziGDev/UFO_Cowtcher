using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayInputCanvas : MonoBehaviour
{
    //DATA
    [SerializeField] Image myJoystickBackground;
    [SerializeField] Image myJoystick;

    //SOUNDS
    [SerializeField] AudioSource notificationSound;



    //METHODS
    //...
    public void ShowJoystick(Vector2 position)
    {
        myJoystickBackground.enabled = true;
        myJoystickBackground.GetComponent<RectTransform>().position = position;
        myJoystick.enabled = true;
    }

    public void HideJoystick()
    {
        myJoystickBackground.enabled = false;
        myJoystick.enabled = false;
    }

    public void PauseGame() => GameController.Instance.helper.HandleEscInput();


    public void PlayNotificationSound()
    {
        if (!notificationSound.isPlaying)
            notificationSound.Play();
    }

}
