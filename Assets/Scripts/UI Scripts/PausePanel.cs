using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    //DATA

    ///GUI REFERENCES
    [SerializeField] private QuitSubPanel QuitSubPanel;
    [SerializeField] private GameObject PauseTitle;
    [SerializeField] private GameObject Buttons;



    //METHODS
    private void Start()
    {
        QuitSubPanel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        PauseTitle.gameObject.SetActive(true);
        Buttons.gameObject.SetActive(true);
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
        PauseTitle.gameObject.SetActive(false);
        Buttons.gameObject.SetActive(false);
        QuitSubPanel.gameObject.SetActive(true);
    }

}
