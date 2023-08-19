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
    public void UpdateInfos(Sprite targetSprite, Moossion referenceMoossion)
    {
        //UPDATE SPRITE
        MoossionTypeIcon.sprite = targetSprite;

        //UPDATE DESCRIPTION


        //UPDATE PROGRESS BAR


        //TODO: MARK MOOSSION AS COMPLETE IF APPLICABLE


    }


}
