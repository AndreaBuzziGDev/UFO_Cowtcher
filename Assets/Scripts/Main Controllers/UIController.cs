using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoSingleton<UIController>
{
    //DATA
    //TODO: MIGHT BE SIMPLIFIED BY USING DEDICATED CLASSES
    private List<GameObject> AllMenuPanels = new();

    [SerializeField] private GameObject PauseGamePanel;
    [SerializeField] private GameOverPanel GameOverPanel;
    [SerializeField] private GameObject CowdexPanel;
    [SerializeField] private GameObject MoossionsPanel;

    ///GAMEPLAY INPUT CANVAS
    [SerializeField] private GameObject gameplayInputCanvas;
    public GameObject GameplayInputCanvas { get { return gameplayInputCanvas; } }

    ///FEED
    [SerializeField] private FeedPanelShortcuts feed;
    public FeedPanelShortcuts Feed { get { return feed; } }



    //IN GAME PANEL - FUNCTIONALITIES USED BY OTHER CLASSES, UIController ACTS AS UNIQUE PROVIDER
    [SerializeField] private InGamePanel igPanel;
    public InGamePanel IGPanel { get { return igPanel; } }






    //METHODS

    //...



    //FUNCTIONALITIES
    //INITIALIZATION
    public void Initialize()
    {
        //
        AllMenuPanels = new List<GameObject> { PauseGamePanel, GameOverPanel.gameObject, CowdexPanel, MoossionsPanel };
        HideAllMenuPanels();
        igPanel.HighScoreBar.ResetScore();

        //INITIALIZE COWDEX PAGES
        CowdexPanel.GetComponent<CowdexGUI>().Initialization();

        //HIDE JOYSTICK
        HideJoystick();

        //INITIALIZE MOOSSIONS VISUALLY


    }




    //GUI PANELS MANAGEMENT

    ///HIDE ALL
    public void HideAllMenuPanels()
    {
        Debug.Log("AllMenuPanels size: " + AllMenuPanels.Count);
        foreach (GameObject go in AllMenuPanels)
        {
            if (go != null) go.SetActive(false);
        }
    }

    ///INDIVIDUALS

    //IN-GAME PANEL
    public void ShowIGPanel() => igPanel.gameObject.SetActive(true);
    public void HigeIGPanel() => igPanel.gameObject.SetActive(false);

    //JOYSTICK
    public void ShowJoystick(Vector2 position)
    {
        Image joystick = null;

        Image[] joysticks = gameplayInputCanvas.GetComponentsInChildren<Image>(true);

        foreach (Image image in joysticks)
        {
            if (image.transform.parent == gameplayInputCanvas.transform)
            {
                joystick = image;
            }
            else
                image.enabled = true;
        }

        RectTransform joystickRect = joystick.GetComponent<RectTransform>();
        joystickRect.position = position;
        joystick.enabled = true;
    }

    public void HideJoystick()
    {
        Image[] joysticks = gameplayInputCanvas.GetComponentsInChildren<Image>(true);

        foreach (Image image in joysticks)
        {
            image.enabled = false;
        }
    }



    //INPUT CANVAS
    public void ShowInputCanvas() => gameplayInputCanvas.SetActive(true);
    public void HideInputCanvas() => gameplayInputCanvas.SetActive(false);

    //IN-GAME PANEL
    ///FEED
    public void ShowFeed() => igPanel.ShowFeed();
    public void HideFeed() => igPanel.HideFeed();

    public void ShowFeed() => feed.gameObject.SetActive(true);
    public void HideFeed() => feed.gameObject.SetActive(false);



    //PAUSE
    public void ShowPause() => PauseGamePanel.SetActive(true);
    public void Hidepause() => PauseGamePanel.SetActive(false);


    //GAMEOVER
    public void ShowGameOver() => GameOverPanel.gameObject.SetActive(true);
    public void HideGameOver() => GameOverPanel.gameObject.SetActive(false);


    //COWDEX
    public void ShowCowdex() => CowdexPanel.SetActive(true);
    public void HideCowdex() => CowdexPanel.SetActive(false);



    //MOOSSIONS
    public void ShowMoossions() 
    {
        MoossionsPanel.SetActive(true);
        HigeIGPanel();
    }
    public void HideMoossions()
    {
        MoossionsPanel.SetActive(false);
        ShowIGPanel();
    }

}
