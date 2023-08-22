using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CowdexPageGUI : MonoBehaviour
{
    //DATA
    ///FUNCTIONAL DATA
    private CowdexPage currentPage;




    ///GUI REFERENCES
    //COWDEX GUI
    private CowdexGUI parentCowdexGUI;//TODO: HANDLING VIA MANUAL REFERENCE?

    //DEFAULT UNKNOWN COW SPRITE
    [SerializeField] private Sprite unknownCowSprite;


    //COW IMAGE
    [SerializeField] private Image cowImage;

    //DETAIL AREA
    [SerializeField] private TMPro.TextMeshProUGUI cowName;
    [SerializeField] private TMPro.TextMeshProUGUI cowDescription;
    [SerializeField] private TMPro.TextMeshProUGUI cowBuff;

    //GENERAL BUTTON
    [SerializeField] private Button generalButton;

    //BUTTONS
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;





    //METHODS
    ///INITIALIZATION
    public void Initialization(CowdexGUI parentReference)
    {
        parentCowdexGUI = parentReference;
    }


    ///PAGE-RELATED STUFF
    public void SetPage(CowdexPage cp)
    {
        if (cp != null)
        {
            currentPage = cp;
            HandlePageUpdate();
        }
    }

    //
    private void HandlePageUpdate()
    {
        //UPDATE IMAGE
        UpdateCowImage();

        //UPDATE DETAIL SECTION
        UpdateDetailSection();

        //UPDATE BUTTON STATES
        UpdateButtonStates();

    }

    private void UpdateCowImage()
    {
        if (1 <= (int)currentPage.Indexed.KnowledgeState) cowImage.sprite = currentPage.cowSprite;
        else cowImage.sprite = unknownCowSprite;
    }


    private void UpdateDetailSection()
    {
        if (2 <= (int)currentPage.Indexed.KnowledgeState)
        {
            cowName.text = currentPage.cowName;
            cowDescription.text = currentPage.cowDescription;
            cowBuff.text = currentPage.cowBuff;
        }
        else
        {
            //DEBUG VERSION
            cowName.text = currentPage.cowName;
            //cowName.text = "???";
            cowDescription.text = "???";
            cowBuff.text = "???";
        }
    }

    private void UpdateButtonStates()
    {
        //ENABLEMENT PREVIOUS
        if (parentCowdexGUI.PageIndex <= 0) previousButton.interactable = false;
        else previousButton.interactable = true;

        //ENABLEMENT NEXT
        if (parentCowdexGUI.PageIndex >= (parentCowdexGUI.NumberOfPages - 1)) nextButton.interactable = false;
        else nextButton.interactable = true;

    }


}
