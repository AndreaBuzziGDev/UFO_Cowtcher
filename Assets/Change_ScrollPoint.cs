using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Change_ScrollPoint : MonoBehaviour
{
   [SerializeField] private Sprite CheckSprite;
   [SerializeField] private Sprite NextPageSprite;
   [SerializeField] private Sprite[] ScrollPoints;
   [SerializeField] private GameObject ScrollPoint;
   [SerializeField] private Button BackButton;
   [SerializeField] private Button NextButton;
   [SerializeField] private Canvas Tutorial;
    
    public int index = 0;

    public void NextPageAction() {
        if (index == 0)
        {
            index++;
            BackButton.gameObject.SetActive(true);
            ScrollPoint.GetComponent<Image>().sprite = ScrollPoints[index];
            
        }

        else if (index == 1)
        {
            index++;
            ScrollPoint.GetComponent<Image>().sprite = ScrollPoints[index];
        }

        else if (index == 2)
        {
            index++;
            NextButton.GetComponent<Image>().sprite = CheckSprite;
            ScrollPoint.GetComponent<Image>().sprite = ScrollPoints[index];
        }

        else
        {
            Tutorial.gameObject.SetActive(false);
            index = 0;
            ScrollPoint.GetComponent<Image>().sprite = ScrollPoints[index];
            NextButton.GetComponent<Image>().sprite = NextPageSprite;
            BackButton.gameObject.SetActive(false);
            PlayerPrefs.SetInt("TutorialAvailable", 1);
            PlayerPrefs.Save();
        }
        
        
    }

    public void BackPageAction()
    {
        print(index);
        if (index == 1)
        {
            index--;
            BackButton.gameObject.SetActive(false);
            ScrollPoint.GetComponent<Image>().sprite = ScrollPoints[index];
        }

        else if (index == 2)
        {
            index--;
            ScrollPoint.GetComponent<Image>().sprite = ScrollPoints[index];
        }

        else if (index == 3)
        {
            index--;
            NextButton.GetComponent<Image>().sprite = NextPageSprite;
            ScrollPoint.GetComponent<Image>().sprite = ScrollPoints[index];
        }


    }
}
