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

    [SerializeField] private GameObject buffPanel;
    public GameObject BuffPanel { get { return buffPanel; } }


    //METHODS

    //FUNCTIONALITIES
    //...


}
