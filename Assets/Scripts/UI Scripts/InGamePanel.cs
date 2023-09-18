using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanel : MonoBehaviour
{
    //DATA
    [SerializeField] private FuelBar playerFuelBar;
    public FuelBar PlayerFuelBar { get { return playerFuelBar; } }

    [SerializeField] private ScoreBar highScoreBar;
    public ScoreBar HighScoreBar { get { return highScoreBar; } }

    ///GUI EFFECT PANELS
    [SerializeField] private BuffPanel buffPanel;
    [SerializeField] private BuffPanel debuffPanel;
    [SerializeField] private BuffPanel ritualPanel;

    public BuffPanel BuffPanel { get { return buffPanel; } }
    public BuffPanel DebuffPanel { get { return debuffPanel; } }
    public BuffPanel RitualPanel { get { return ritualPanel; } }


    ///FEED
    [SerializeField] private FeedPanelShortcuts feed;
    public FeedPanelShortcuts Feed { get { return feed; } }



    //METHODS

    //FUNCTIONALITIES

    public void ShowFeed() => feed.gameObject.SetActive(true);
    public void HideFeed() => feed.gameObject.SetActive(false);


}
