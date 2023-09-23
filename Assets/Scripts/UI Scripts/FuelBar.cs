using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelBar : MonoBehaviour
{
    //DATA
    //FUEL BAR SHAKE DATA
    [SerializeField] private float shakeAmount;
    [SerializeField] private float shakeSpeed;
    [SerializeField] private float shakeTime;
    private float currentShakeTime;
    bool shake = false;

    //EMERGENCY FUEL GRADIENT DATA
    [SerializeField] [Range(0, 1)] private float maxAlphaValue = 0.4f;
    [SerializeField] [Range(1, 10)] private float gradientSpeed = 1.0f;


    //GUI REFERENCES
    [SerializeField] private Image fuelBarImg;
    [SerializeField] private Image fuelEmergencyGradient;


    //TECHNICAL
    Vector3 barPosition;



    //METHODS
    //...
    private void Awake()
    {
        barPosition = this.GetComponent<RectTransform>().transform.position;
        currentShakeTime = shakeTime;

        //REGISTER EVENT
        SASharkBite.SharkBite += HandleSharkBite;
    }

    private void FixedUpdate()
    {
        if (shake)
        {
            //TODO: USE COROUTINE?
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
        fuelBarImg.fillAmount = normalizedFuel;

        //HANDLE THE CHANGE OF COLOR IN THE FUEL BAR
        if (normalizedFuel >= 0.5f)
        {
            float halfMax = ufo.MaxFuelAmount / 2.0f;
            float awaitedValue = (halfMax - (ufo.MaxFuelAmount - ufo.FuelAmount)) / halfMax;

            fuelBarImg.color = Color.Lerp(Color.yellow, Color.white, awaitedValue);
        }
        else
        {
            fuelBarImg.color = Color.Lerp(Color.red, Color.yellow, (normalizedFuel/0.5f));
        }

        //HANDLE THE EMERGENCY STATE - RED SCREEN BORDERS
        if (ufo.isEmergencyFuel)
        {
            Color gradCol = fuelEmergencyGradient.color;
            fuelEmergencyGradient.color = new Color(
                gradCol.r, 
                gradCol.g, 
                gradCol.b, 
                Mathf.Abs(Mathf.Sin(Time.time * gradientSpeed)) * maxAlphaValue
                );
        }
        else
        {
            Color gradCol = fuelEmergencyGradient.color;
            fuelEmergencyGradient.color = new Color(gradCol.r, gradCol.g, gradCol.b, 0);
        }

    }



    //
    public void SetShaking() => shake = true;

    private void AnimateShake()
    {
        this.GetComponent<RectTransform>().transform.position = new Vector3(
            transform.position.x + Mathf.Sin(Time.unscaledTime * shakeSpeed) * shakeAmount, 
            transform.position.y, 
            transform.position.z);
    }





    //EVENT-HANDLING
    private void HandleSharkBite(object sender, SharkBiteEventArgs e)
    {
        List<SAAbstract> alterations = UFOStatusAlterationHelper.GetPlayerAlterations();


    }


}
