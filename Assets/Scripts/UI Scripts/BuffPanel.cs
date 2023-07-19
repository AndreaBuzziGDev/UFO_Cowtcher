using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffPanel : MonoBehaviour
{
    public bool fadeToTransparent = false;

    [SerializeField] private float TimeToFadeToTransparent = 0f;

    [SerializeField] private Image FastCatch;
    [SerializeField] private Image FuelBoost;
    [SerializeField] private Image FuelLoss;
    [SerializeField] private Image SpeedBoost;

    private Image imageToFade;
    private Color panelColor;
    private float currentFadeTimer;

    private void Awake()
    {
        imageToFade = GetComponent<Image>();
        panelColor = imageToFade.color;
        currentFadeTimer = TimeToFadeToTransparent;

        if (FastCatch != null) FastCatch.enabled = false;
        if (FuelBoost != null) FuelBoost.enabled = false;
        if (FuelLoss != null) FuelLoss.enabled = false;
        if (SpeedBoost != null) SpeedBoost.enabled = false;
    }

    private void Update()
    {
        if (fadeToTransparent)
        {
            FadeImageToTransparent();
        }
    }

    private void FadeImageToTransparent()
    {
        currentFadeTimer -= Time.deltaTime;
        Color startPanelColor = new Color(panelColor.r, panelColor.g, panelColor.b, 127);

        //imageToFade.color = Color.Lerp(panelColor, startPanelColor, Mathf.Abs((100 * (TimeToFadeToTransparent - currentFadeTimer)) / TimeToFadeToTransparent));
        imageToFade.color = new Color(startPanelColor.r, startPanelColor.g, startPanelColor.b, currentFadeTimer);

        if (currentFadeTimer <= 0f)
        {
            fadeToTransparent = false;
            currentFadeTimer = TimeToFadeToTransparent;
        }
    }

    //FAST CATCH
    public void ActivateFastCatch()
    {
        if (FastCatch != null)
        {
            FastCatch.enabled = true;
        }
    }

    //FUEL BOOST
    public void ActivateFuelBoost()
    {
        if (FuelBoost != null)
        {
            FuelBoost.enabled = true;
        }
    }

    //FUEL LOSS
    public void ActivateFuelLoss()
    {
        if (FuelLoss != null)
        {
            FuelLoss.enabled = true;
        }
    }

    //SPEED BOOST
    public void ActivateSpeedBoost()
    {
        if (SpeedBoost != null)
        {
            SpeedBoost.enabled = true;
        }
    }




    //FAST CATCH
    public void DeactivateFastCatch()
    {
        if (FastCatch != null)
        {
            FastCatch.enabled = false;
        }
    }

    //FUEL BOOST
    public void DeactivateFuelBoost()
    {
        if (FuelBoost != null)
        {
            FuelBoost.enabled = false;
        }
    }

    //FUEL LOSS
    public void DeactivateFuelLoss()
    {
        if (FuelLoss != null)
        {
            FuelLoss.enabled = false;
        }
    }

    //SPEED BOOST
    public void DeactivateSpeedBoost()
    {
        if (SpeedBoost != null)
        {
            SpeedBoost.enabled = false;
        }
    }
}
