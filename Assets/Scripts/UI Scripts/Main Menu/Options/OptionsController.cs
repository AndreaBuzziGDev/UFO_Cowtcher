using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    //DATA
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject selection;
    [SerializeField] private GameObject bottom;

    ///DEVELOPER OPTIONS
    [SerializeField] private OptionsDev developerOptions;
    [SerializeField] private OptionsCheat cheatOptions;


    //METHODS
    //...
    private void Start()
    {
        developerOptions.gameObject.SetActive(false);
        cheatOptions.gameObject.SetActive(false);
    }


    //FUNCTIONALITIES
    ///SELF
    public void ShowSelf()
    {
        title.SetActive(true);
        selection.SetActive(true);
        bottom.SetActive(true);
    }
    public void HideSelf()
    {
        title.SetActive(false);
        selection.SetActive(false);
        bottom.SetActive(false);
    }

    ///DEVELOPER OPTIONS
    public void ShowDevOptions()
    {
        HideSelf();
        developerOptions.gameObject.SetActive(true);
    }

    public void HideDevOptions()
    {
        ShowSelf();
        developerOptions.gameObject.SetActive(false);
    }

    ///CHEATS
    public void ShowCheats()
    {
        HideSelf();
        cheatOptions.gameObject.SetActive(true);
    }

    public void HideCheats()
    {
        ShowSelf();
        cheatOptions.gameObject.SetActive(false);
    }


}
