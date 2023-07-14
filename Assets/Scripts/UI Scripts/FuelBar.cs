using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelBar : MonoBehaviour
{
    public Image FuelBarImg;


    //METHODS
    public void UpdateFuelBar(UFO ufo)
    {
        float normalizedFuel = (float) ufo.FuelAmount / (float) ufo.MaxFuelAmount;
        FuelBarImg.fillAmount = normalizedFuel;
    }    
   
}
