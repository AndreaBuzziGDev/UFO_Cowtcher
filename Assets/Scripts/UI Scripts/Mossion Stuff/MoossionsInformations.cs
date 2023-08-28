using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoossionsInformations : MonoBehaviour
{
    //DATA

    ///GUI REFERENCES
    [SerializeField] private Image MoossionTypeIcon;
    [SerializeField] private Image MoossionTargetCowGUI;


    [SerializeField] private TMPro.TextMeshProUGUI MoossionDescription;
    [SerializeField] private Image MoossionProgressBar;


    //METHODS

    //FUNCTIONALITIES
    ///UPDATE THE CONTENT
    public void UpdateInfos(Moossion referenceMoossion, Sprite targetSprite)
    {
        //UPDATE SPRITE
        MoossionTypeIcon.sprite = targetSprite;
        //UPDATE TARGET COW SPRITE
        if(referenceMoossion is MoossCaptSpecific)
        {
            ///HANDLE PREFAB COWS
            Cow prefabCow = Cowdex.Instance.GetCow((referenceMoossion as MoossCaptSpecific).TargetUID);
            GameObject visualChild = prefabCow.gameObject.transform.Find("VisualChild").gameObject;

            ///UPDATE WITH MATCHING COW SPRITE
            MoossionTargetCowGUI.sprite = visualChild.GetComponent<SpriteRenderer>().sprite;

            ///MAKE IT FULLY OPAQUE
            Color newColor = MoossionTargetCowGUI.color;
            MoossionTargetCowGUI.color = new Color(newColor.r, newColor.g, newColor.b, 1);
        }
        else
        {
            ///MAKE IT FULLY TRANSPARENT
            Color newColor = MoossionTargetCowGUI.color;
            MoossionTargetCowGUI.color = new Color(newColor.r, newColor.g, newColor.b, 0);
        }


        //UPDATE DESCRIPTION
        MoossionDescription.text = referenceMoossion.GetDescription();

        //UPDATE PROGRESS BAR
        MoossionProgressBar.fillAmount = (float)referenceMoossion.CurrentQuantity / (float)referenceMoossion.TargetQuantity;


        //TODO: MARK MOOSSION AS COMPLETE IF APPLICABLE


    }


}
