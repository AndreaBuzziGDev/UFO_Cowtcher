using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoSingleton<MainMenuController>
{
    //ENUMS
    public enum eMainMenuCanvas
    {
        Main,
        StageSelect,
        Garage,
        Cowdex,
        Options,
        Quit
    }


    //DATA
    [SerializeField] private Canvas MainMenuCanvas;
    [SerializeField] private Canvas StageSelectCanvas;
    [SerializeField] private Canvas GarageCanvas;
    [SerializeField] private Canvas CowdexCanvas;//TODO: CONNECT IN THE GUI
    [SerializeField] private Canvas OptionsCanvas;

    private List<Canvas> allCanvas = new();

    ///LAST TARGET CANVAS
    private eMainMenuCanvas lastTargetCanvas = 0;



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }





    //FUNCTIONALITIES

    ///INITIALIZATION
    public void Initialization()
    {
        InitializeImportantPrefabs();
        InitializeGUI();
    }

    ///IMPORTANT PREFAB INITIALIZATION
    private void InitializeImportantPrefabs()
    {
        Cowdex.Instance.Initialization();
        CowdexCanvas.GetComponent<CowdexGUI>().Initialization();
    }


    ///GUI INITIALIZATION
    private void InitializeGUI()
    {
        BuildAllCanvas();
        SetTargetCanvas(lastTargetCanvas);
    }

    private void BuildAllCanvas()
    {
        allCanvas = new List<Canvas> { MainMenuCanvas, StageSelectCanvas, GarageCanvas, CowdexCanvas, OptionsCanvas };
    }

    private void DisableAllCanvas() 
    {
        foreach (Canvas c in allCanvas) c.gameObject.SetActive(false);
    }


    //HANDLING SPECIFIC CANVAS
    public void SetTargetCanvas(eMainMenuCanvas targetCanvas)
    {
        //EXIT GAME
        if (targetCanvas == eMainMenuCanvas.Quit) ExitGame();
        else DisableAllCanvas();

        //SWITCH
        switch (targetCanvas)
        {
            case eMainMenuCanvas.Main:
                //MAIN MENU
                MainMenuCanvas.gameObject.SetActive(true);
                break;
            case eMainMenuCanvas.StageSelect:
                //STAGE SELECT
                StageSelectCanvas.gameObject.SetActive(true);
                break;
            case eMainMenuCanvas.Garage:
                //GARAGE
                GarageCanvas.gameObject.SetActive(true);
                break;
            case eMainMenuCanvas.Cowdex:
                //COWDEX
                CowdexCanvas.gameObject.SetActive(true);
                break;
            case eMainMenuCanvas.Options:
                //OPTIONS
                OptionsCanvas.gameObject.SetActive(true);
                break;
            default:
                //DEFAULT -> MAIN MENU
                MainMenuCanvas.gameObject.SetActive(true);
                break;
        }

        lastTargetCanvas = targetCanvas;
    }




    //UTILITES

    ///CHECKS IF THIS IS THE ACTIVE CANVAS
    public bool isActiveCanvas(eMainMenuCanvas canvasChecked) => canvasChecked == lastTargetCanvas;


    ///EXIT GAME
    private static void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif
    }



}
