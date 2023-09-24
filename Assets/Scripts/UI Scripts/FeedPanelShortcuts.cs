using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedPanelShortcuts : MonoBehaviour
{
    //FUNCTIONALITIES
    public void MoossionShortcut()
    {
        GameController.Instance.SetState(GameController.EGameState.Paused);
        UIController.Instance.ShowMoossions();
    }

    public void CowdexShortcut()
    {
        GameController.Instance.SetState(GameController.EGameState.Paused);
        UIController.Instance.ShowCowdex();
    }

}
