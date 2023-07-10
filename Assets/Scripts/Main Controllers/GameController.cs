using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    //ENUMS
    public enum EGameState
    {
        Start,
        Playing,
        Paused,
        Quitting,
        Exiting
    }

    //DATA
    private EGameState state = 0;

    public bool IsPaused { get { return this.state == EGameState.Paused; } }


    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        //SHOULD HELP DRIVING THE OTHER CONTROLLERS THROUGH THEIR INITIALIZATION SEQUENTIALLY.

        //ENFORCES START SEQUENCE
        SetState(EGameState.Playing);
    }



    //FUNCTIONALITIES
    //...
    public void SetState(EGameState targetState)
    {
        state = targetState;
        switch (state)
        {
            case EGameState.Start:
                //RESERVED FOR INITIALIZATION

                SetState(EGameState.Playing);
                break;

            case EGameState.Playing:
                UIController.Instance.HideAllMenuPanels();
                UnpauseGame();

                break;

            case EGameState.Paused:
                UIController.Instance.ShowPause();
                PauseGame();
                break;

            case EGameState.Quitting:
                QuitGame();
                break;

            case EGameState.Exiting:
                ExitGame();
                break;

        }
    }


    //PAUSING
    private static void PauseGame()
    {
        Time.timeScale = 0;
    }
    private static void UnpauseGame()
    {
        Time.timeScale = 1;
    }


    //QUIT GAME (ABANDON SESSION)
    private static void QuitGame()
    {
        //TODO: GO BACK TO MAIN MENU
        //NOW IT QUITS THE GAME
        ExitGame();
    }



    //EXIT GAME
    private static void ExitGame()
    {
        Application.Quit();
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

}
