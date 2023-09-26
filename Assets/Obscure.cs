using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obscure : MonoBehaviour
{
    private float targetTime;
    [SerializeField] GameObject Panel;
    public Color c;

    private void Start()
    {
        targetTime = 0f;
        c= new Color(0,0,0);
        c.a = 0.4f;
        Panel.GetComponent<Image>().color = c;
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("TutorialAvailable")==1)
        {
            targetTime += Time.deltaTime;
            if(targetTime > 5f && c.a < 0.78f) 
            {
                c.a += ((Time.deltaTime) * 0.04f);
            }
            Panel.GetComponent<Image>().color = c;
        }

        
    }
}
