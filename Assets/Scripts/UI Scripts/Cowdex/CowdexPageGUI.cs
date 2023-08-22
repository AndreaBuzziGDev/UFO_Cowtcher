using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CowdexPageGUI : MonoBehaviour
{
    //DATA
    ///GUI REFERENCES
    private CowdexGUI parentCowdexGUI;//TODO: HANDLING VIA MANUAL REFERENCE?

    ///FUNCTIONAL DATA
    private CowdexPage currentPage;
    public CowdexPage GetPage { get { return currentPage; } }




    ///GUI REFERENCES
    //SPRITE
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

    private void UpdateCowImage() => cowImage.sprite = currentPage.cowSprite;


    private void UpdateDetailSection()
    {
        cowName.text = currentPage.cowName;
        cowDescription.text = currentPage.cowDescription;
        cowBuff.text = currentPage.cowBuff;
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
