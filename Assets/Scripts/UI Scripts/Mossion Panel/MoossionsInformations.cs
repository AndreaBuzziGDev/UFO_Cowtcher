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

    //TODO: DEVELOP GUI UPDATE FUNCTIONALITIES

    //PLACEHOLDER FUNCTIONALITY
    private void Start()
    {
        MoossionDescription.text = "Desc Replaced by Code.";
        MoossionProgressBar.fillAmount = 0.5f;
    }


    //
    public void UpdateInfos()
    {
        //TODO: DEVELOP


        //TODO: CHANGE METHOD SIGNATURE



    }


}
