using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
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


    //UNPAUSE
    public void Restart() => GameController.Instance.RestartScene();

    //QUIT
    public void Quit()
    {
        //
        QuitSubPanel.gameObject.SetActive(true);
    }
}
