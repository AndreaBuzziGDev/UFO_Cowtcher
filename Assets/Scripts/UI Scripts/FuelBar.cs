using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelBar : MonoBehaviour
{
    public Image FuelBarImg;

    public void UpdateFuelBar(UFO ufo)
    {
        float normalizedFuel = (float) ufo.ScoreAmount / (float) ufo.FuelAmount;
        FuelBarImg.fillAmount = normalizedFuel;
    }    
   
}
