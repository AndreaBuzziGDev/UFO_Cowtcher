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

    [SerializeField] private BuffPanel buffPanel;
    [SerializeField] private BuffPanel debuffPanel;
    [SerializeField] private BuffPanel ritualPanel;

    public BuffPanel BuffPanel { get { return buffPanel; } }
    public BuffPanel DebuffPanel { get { return debuffPanel; } }
    public BuffPanel RitualPanel { get { return ritualPanel; } }


    //METHODS

    //FUNCTIONALITIES
    //...


}
