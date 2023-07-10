using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    //METHODS

    //OPEN COWDEX
    public void OpenCowdex() => Resume();//TODO: CHANGE

    //UNPAUSE
    public void Resume() => GameController.Instance.SetState(GameController.EGameState.Playing);

    //QUIT
    public void Quit() => GameController.Instance.SetState(GameController.EGameState.Quitting);

}
