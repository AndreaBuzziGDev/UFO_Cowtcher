using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    //DATA
    [SerializeField] private Canvas MainMenuCanvas;



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //FUNCTIONALITIES

    ///INITIALIZATION
    public void Initialize()
    {
        MainMenuCanvas.gameObject.SetActive(true);

        //SET EVERY OTHER CANVAS INACTIVE


    }




}
