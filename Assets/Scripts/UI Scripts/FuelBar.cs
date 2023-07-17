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
        if (normalizedFuel >= 0.5f)
        {
            float halfMax = ufo.MaxFuelAmount / 2.0f;
            float awaitedValue = (halfMax - (ufo.MaxFuelAmount - ufo.FuelAmount)) / halfMax;

            FuelBarImg.color = Color.Lerp(Color.yellow, Color.white, awaitedValue);
        }
        else
        {
            FuelBarImg.color = Color.Lerp(Color.red, Color.yellow, (normalizedFuel/0.5f));
        }
    }    
   
}
