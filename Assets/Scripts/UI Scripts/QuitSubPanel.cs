using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitSubPanel : MonoBehaviour
{
    //DATA


    ///GUI REFERENCES
    [SerializeField] private GameObject QuitTitleText;




    //METHODS
    //...

    private void Update()
    {


    }


    //FUNCTIONALITIES

    ///MAIN MENU
    public void GoToMainMenu() => SceneNavigationController.Instance.LoadScene(SceneNavigationController.eTechnicalSceneName.MainMenu);

    ///QUIT
    public void QuitGame() => GameController.Instance.SetState(GameController.EGameState.Quitting);

}
