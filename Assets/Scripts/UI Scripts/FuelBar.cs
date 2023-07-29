using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelBar : MonoBehaviour
{
    public Image FuelBarImg;

    bool shake = false;
    [SerializeField] private float shakeAmount;
    [SerializeField] private float shakeSpeed;
    private float currentShakeTime;
    [SerializeField] private float shakeTime;

    Vector3 barPosition;



    //METHODS
    //...
    private void Awake()
    {
        currentShakeTime = shakeTime;
    }

    private void Update()
    {
        if (shake)
        {
            currentShakeTime -= Time.deltaTime;
            AnimateShake();
        }

        if (currentShakeTime <= 0)
        {
            currentShakeTime = shakeTime;
            shake = false;
            this.GetComponent<RectTransform>().transform.position = barPosition;
        }
    }


    //FUNCTIONALITIES
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



    //
    public void SetShaking()
    {
        shake = true;
    }

    private void AnimateShake()
    {
        barPosition = this.GetComponent<RectTransform>().transform.position;
        this.GetComponent<RectTransform>().transform.position = new Vector3(transform.position.x + Mathf.Sin(Time.unscaledTime * shakeSpeed) * shakeAmount, transform.position.y, transform.position.z);
    }

}
