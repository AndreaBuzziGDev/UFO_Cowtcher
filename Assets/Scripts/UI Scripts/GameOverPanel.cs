using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    //DATA

    ///GUI REFERENCES
    [SerializeField] private QuitSubPanel QuitSubPanel;
    [SerializeField] private HooveringGUIComponent HooveringGameOverTitle;



    //METHODS
    private void Start()
    {
        QuitSubPanel.gameObject.SetActive(false);
    }


    private void OnDisable()
    {
        QuitSubPanel.gameObject.SetActive(false);
    }


    //FUNCTIONALITIES

    //BUTTONS
    ///RESTART
    public void Restart() => GameController.Instance.RestartScene();

    ///QUIT
    public void Quit()
    {
        //
        this.gameObject.SetActive(false);
        HooveringGameOverTitle.gameObject.SetActive(false);
        QuitSubPanel.gameObject.SetActive(true);
    }


    //END-GAME REPORT
    public void DoEndgameReport()
    {
        //SAVE HIGH SCORE

        //SAVE LEVEL INFO

        //CALCULATE EXPERIENCE

        //SAVE LEVEL EXPERIENCE


    }


}
