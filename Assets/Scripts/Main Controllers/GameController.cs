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
        Paused
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

                //TODO: TRANSITION TO STATE "PLAYING" AT THE END OF START STATE
                break;

            case EGameState.Playing:
                UnpauseGame();


                break;

            case EGameState.Paused:

                PauseGame();
                break;

        }
    }


    //PAUSING
    public static void PauseGame()
    {
        Time.timeScale = 0;
    }
    public static void UnpauseGame()
    {
        Time.timeScale = 1;
    }

}
