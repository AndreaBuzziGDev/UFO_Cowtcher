using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    //DATA
    //[SerializeField] private GameObject title;
    [SerializeField] private GameObject selection;
    [SerializeField] private GameObject bottom;

    ///DEVELOPER OPTIONS
    [SerializeField] private GameObject developerOptions;


    //METHODS
    //...
    private void Start()
    {
        developerOptions.gameObject.SetActive(false);
    }


    //FUNCTIONALITIES
    ///SELF
    public void ShowSelf()
    {
        selection.SetActive(true);
        bottom.SetActive(true);
    }
    public void HideSelf()
    {
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

}
