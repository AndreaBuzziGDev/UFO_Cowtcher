using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoSingleton<UIController>
{
    //NB: THERE MIGHT BE AN "EXPLOSION" OF UI COMPONENTS BASED ON NECESSITY.
    //THIS CLASS IS MEANT TO HANDLE BASIC UI. IF NECESSARY, SWITCH TO SOMETHING THAT ACTS LIKE A "TOP-LEVEL" MANAGER
    //WHILE SOME OTHER SUB-COMPONENTS HANDLE THE DETAILS OF THE CODE.

    //DATA
    //TODO: MIGHT BE SIMPLIFIED BY USING DEDICATED CLASSES
    [SerializeField] private List<GameObject> AllMenuPanels;

    [SerializeField] private GameObject PauseGamePanel;
    [SerializeField] private GameObject CowdexPanel;


    //METHODS

    //FUNCTIONALITIES


    //GUI PANELS MANAGEMENT

    ///HIDE ALL
    public void HideAllMenuPanels()
    {
        foreach (GameObject go in AllMenuPanels)
        {
            if (go != null) go.SetActive(false);
        }
    }

    ///INDIVIDUALS
    //PAUSE
    public void ShowPause() => PauseGamePanel.SetActive(true);
    public void Hidepause() => PauseGamePanel.SetActive(false);

    //COWDEX
    public void ShowCowdex() => CowdexPanel.SetActive(true);
    public void HideCowdex() => CowdexPanel.SetActive(false);



}
