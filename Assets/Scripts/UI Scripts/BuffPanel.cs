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
        panelColor = new Color(255, 0, 0, 0);

        //FastCatch.enabled = false;
        //FuelBoost.enabled = false;
        //FuelLoss.enabled = false;
        //SpeedBoost.enabled = false;
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


    public void ActivateFastCatch()
    {
        if (FastCatch != null)
        {
            FastCatch.enabled = true;
        }
    }

    public void ActivateFuelBoost()
    {
        if (FuelBoost != null)
        {
            FuelBoost.enabled = true;
        }
    }

    public void ActivateFuelLoss()
    {
        if (FuelLoss != null)
        {
            FuelLoss.enabled = true;
        }
    }

    public void ActivateSpeedBoost()
    {
        if (SpeedBoost != null)
        {
            SpeedBoost.enabled = true;
        }
    }

    public void DeactivateFastCatch()
    {
        if (FastCatch != null)
        {
            FastCatch.enabled = false;
        }
    }

    public void DeactivateFuelBoost()
    {
        if (FuelBoost != null)
        {
            FuelBoost.enabled = false;
        }
    }

    public void DeactivateFuelLoss()
    {
        if (FuelLoss != null)
        {
            FuelLoss.enabled = false;
        }
    }

    public void DeactivateSpeedBoost()
    {
        if (SpeedBoost != null)
        {
            SpeedBoost.enabled = false;
        }
    }
}
