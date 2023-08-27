using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    //DATA
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;


    //METHODS
    //...

    void OnEnable()
    {
        if(scoreText != null)
        {
            scoreText.text = SaveSystem.LoadHighScore().ToString();
        }
    }

}
