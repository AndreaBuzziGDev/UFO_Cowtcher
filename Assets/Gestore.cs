using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gestore : MonoBehaviour
{
    [SerializeField] Sprite[] Planets;
    [SerializeField] Sprite[] Accessories;
    [SerializeField] GameObject Planet;
    [SerializeField] GameObject Accessory;
    [SerializeField] private SceneNavigationController.eStageSceneName[] intendedTargetScene;
    [SerializeField] private StageSelectionController parentController;


    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        Planet.GetComponent<Image>().sprite = Planets[index];
        Accessory.GetComponent<Image>().sprite = Accessories[index];
        parentController.SetTargetScene(intendedTargetScene[index]);
    }

    // Update is called once per frame
    public void IndexUpdate() 
    {
        if (index < intendedTargetScene.Length)
        {
            Planet.GetComponent<Image>().sprite = Planets[index];
            Accessory.GetComponent<Image>().sprite = Accessories[index];
            parentController.SetTargetScene(intendedTargetScene[index]);
            index++;
        }
        else
        {
            index = 0;
        }
    }
    
}
