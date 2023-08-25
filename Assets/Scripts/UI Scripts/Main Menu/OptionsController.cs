using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    //DATA
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

    }
    public void HideSelf()
    {

    }

    ///DEVELOPER OPTIONS
    public void ShowDevOptions()
    {
        HideSelf();

    }

    public void HideDevOptions()
    {
        ShowSelf();
    }

}
