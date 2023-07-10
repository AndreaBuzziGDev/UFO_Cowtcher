using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//NB: MANAGED AS NON-MONOBEHAVIOUR.
public class GameControllerHelper
{
    //DATA


    //METHODS
    public void HandleEscInput()
    {
        //BEHAVIOUR: PLAYING A LEVEL
        if (GameController.Instance.IsPaused)
        {
            GameController.Instance.SetState(GameController.EGameState.Playing);
        }
        else
        {
            GameController.Instance.SetState(GameController.EGameState.Paused);
        }


    }


}
