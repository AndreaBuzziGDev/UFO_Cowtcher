using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitSubPanel : MonoBehaviour
{
    //DATA


    //METHODS
    public void GoToMainMenu() => SceneNavigationController.Instance.LoadScene(SceneNavigationController.eTechnicalSceneName.MainMenu);

    //QUIT
    public void QuitGame() => GameController.Instance.SetState(GameController.EGameState.Quitting);

}
