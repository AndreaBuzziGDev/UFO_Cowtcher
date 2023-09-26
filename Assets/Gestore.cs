using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gestore : MonoBehaviour
{
    [SerializeField] Sprite[] Planets;
    [SerializeField] Sprite[] Accessories;
    [SerializeField] Sprite[] AccessoriesRetro;
    [SerializeField] GameObject Planet;
    [SerializeField] GameObject Accessory;
    [SerializeField] GameObject AccessoryRetro;
    [SerializeField] GameObject LockPlanet;
    [SerializeField] GameObject Shadow;
    [SerializeField] private SceneNavigationController.eStageSceneName[] intendedTargetScene;
    [SerializeField] private StageSelectionController parentController;
    [SerializeField] private Button playButton;


    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetValues();
    }


    public void SetValues()
    {
        Planet.GetComponent<Image>().sprite = Planets[index];
        Accessory.GetComponent<Image>().sprite = Accessories[index];
        AccessoryRetro.GetComponent<Image>().sprite = AccessoriesRetro[index];
        parentController.SetTargetScene(intendedTargetScene[index]);
    }

    // Update is called once per frame
    public void NextPlanet() 
    {
        index++;
        if (index < intendedTargetScene.Length && index!=0)
        { 
       // Debug.Log(index);
            Planet.GetComponent<Image>().sprite = Planets[index];
            Accessory.GetComponent<Image>().sprite = Accessories[index];
            AccessoryRetro.GetComponent<Image>().sprite = AccessoriesRetro[index];
            parentController.SetTargetScene(intendedTargetScene[index]);
            
        }
        else
        {
       // Debug.Log(index);
            index = 0;
            Planet.GetComponent<Image>().sprite = Planets[index];
            Accessory.GetComponent<Image>().sprite = Accessories[index];
            AccessoryRetro.GetComponent<Image>().sprite = AccessoriesRetro[index];
            parentController.SetTargetScene(intendedTargetScene[index]);
        }

        //Controllo disponibilitÓ pianeta
        if (!SaveSystem.IsStageUnlocked("Stage " + (index + 1).ToString()))
        {
            Planet.GetComponent<Image>().color = Color.black;
            Accessory.GetComponent<Image>().color = Color.black;
            AccessoryRetro.GetComponent<Image>().color = Color.black;
            LockPlanet.SetActive(true);
            Shadow.SetActive(false);
        }
        else
        {
            Planet.GetComponent<Image>().color = Color.white;
            Accessory.GetComponent<Image>().color = Color.white;
            AccessoryRetro.GetComponent<Image>().color = Color.white;
            LockPlanet.SetActive(false);
            Shadow.SetActive(true);
        }
        playButton.interactable = SaveSystem.IsStageUnlocked("Stage " + (index + 1).ToString());

    }

    public void PreviousPlanet()
    {
        index--;
        if (index >= 0)
        {
            // Debug.Log(index);
            Planet.GetComponent<Image>().sprite = Planets[index];
            Accessory.GetComponent<Image>().sprite = Accessories[index];
            AccessoryRetro.GetComponent<Image>().sprite = AccessoriesRetro[index];
            parentController.SetTargetScene(intendedTargetScene[index]);
        }
        else
        {
            // Debug.Log(index);
            index = 3;
            Planet.GetComponent<Image>().sprite = Planets[index];
            Accessory.GetComponent<Image>().sprite = Accessories[index];
            AccessoryRetro.GetComponent<Image>().sprite = AccessoriesRetro[index];
            parentController.SetTargetScene(intendedTargetScene[index]);
        }

        //Controllo disponibilitÓ pianeta
        if (!SaveSystem.IsStageUnlocked("Stage " + (index + 1).ToString()))
        {
            Planet.GetComponent<Image>().color = Color.black;
            Accessory.GetComponent<Image>().color = Color.black;
            AccessoryRetro.GetComponent<Image>().color = Color.black;
            LockPlanet.SetActive(true);
            Shadow.SetActive(false);
        }
        else
        {
            Planet.GetComponent<Image>().color = Color.white;
            Accessory.GetComponent<Image>().color = Color.white;
            AccessoryRetro.GetComponent<Image>().color = Color.white;
            LockPlanet.SetActive(false);
            Shadow.SetActive(true);
        }
        playButton.interactable = SaveSystem.IsStageUnlocked("Stage " + (index + 1).ToString());

    }

}
