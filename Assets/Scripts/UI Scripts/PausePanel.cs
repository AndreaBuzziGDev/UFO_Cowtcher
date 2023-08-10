using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    //DATA

    ///GUI REFERENCES
    [SerializeField] private QuitSubPanel QuitSubPanel;



    //METHODS
    private void Start()
    {
        QuitSubPanel.gameObject.SetActive(false);
    }


    private void OnDisable()
    {
        QuitSubPanel.gameObject.SetActive(false);
    }


    //OPEN COWDEX
    public void OpenCowdex() => Resume();//TODO: CHANGE

    //UNPAUSE
    public void Resume() => GameController.Instance.SetState(GameController.EGameState.Playing);

    //RESTART
    public void Restart() => GameController.Instance.RestartScene();

    //QUIT
    public void Quit()
    {
        //
        QuitSubPanel.gameObject.SetActive(true);
    }

}
