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

    // Start is called before the first frame update
    void Start()
    {
        if(scoreText != null)
        {
            scoreText.text = SaveSystem.LoadHighScore().ToString();
        }
    }
}
