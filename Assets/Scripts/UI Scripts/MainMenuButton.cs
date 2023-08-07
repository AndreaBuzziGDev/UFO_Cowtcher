using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    //DATA
    [SerializeField] private MainMenuController.eMainMenuCanvas myTargetCanvas;

    //METHODS
    public void GoToCanvas()
    {
        MainMenuController.Instance.SetTargetCanvas(myTargetCanvas);
    }


}
