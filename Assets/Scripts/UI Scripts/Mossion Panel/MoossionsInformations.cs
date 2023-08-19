using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoossionsInformations : MonoBehaviour
{
    //DATA

    ///GUI REFERENCES
    [SerializeField] private Image MoossionTypeIcon;
    [SerializeField] private TMPro.TextMeshProUGUI MoossionDescription;
    [SerializeField] private Image MoossionProgressBar;


    //METHODS

    //FUNCTIONALITIES
    ///UPDATE THE CONTENT
    public void UpdateInfos(Moossion referenceMoossion, Sprite targetSprite)
    {
        //UPDATE SPRITE
        MoossionTypeIcon.sprite = targetSprite;

        //UPDATE DESCRIPTION
        MoossionDescription.text = referenceMoossion.GetDescription();

        //UPDATE PROGRESS BAR
        MoossionProgressBar.fillAmount = referenceMoossion.CurrentQuantity / referenceMoossion.TargetQuantity;


        //TODO: MARK MOOSSION AS COMPLETE IF APPLICABLE


    }


}
