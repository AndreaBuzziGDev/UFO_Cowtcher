using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    //DATA

    ///GUI REFERENCES
    [SerializeField] private QuitSubPanel QuitSubPanel;

    [SerializeField] private HooveringGUIComponent heading;
    [SerializeField] private EndGameSummary summary;
    [SerializeField] private GameObject gameOverButtons;




    //METHODS
    private void Start()
    {
        QuitSubPanel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        QuitSubPanel.gameObject.SetActive(false);

        //UNLOCK REWARDS
        ProgressionSystem.UnlockAllAvailableRewards();

        //ENDGAME REPORT
        DoEndgame();
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
        //DEACTIVATING SELF
        heading.gameObject.SetActive(false);
        summary.gameObject.SetActive(false);
        gameOverButtons.gameObject.SetActive(false);

        //ACTIVATING QUIT SUB-PANEL
        QuitSubPanel.gameObject.SetActive(true);
    }


    //END-GAME REPORT
    public void DoEndgame()
    {
        //
        if(UIController.Instance != null)
        {
            summary.DoEndGameSummary();
        }
    }


}
