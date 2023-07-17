using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    //UNPAUSE
    public void Restart() => GameController.Instance.RestartScene();

    //QUIT
    public void Quit() => GameController.Instance.SetState(GameController.EGameState.Quitting);
}
