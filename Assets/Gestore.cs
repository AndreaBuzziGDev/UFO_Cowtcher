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
    [SerializeField] private SceneNavigationController.eStageSceneName[] intendedTargetScene;
    [SerializeField] private StageSelectionController parentController;


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
    }

}
