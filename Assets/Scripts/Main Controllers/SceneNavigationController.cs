using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigationController : MonoSingleton<SceneNavigationController>
{
    //ENUMS
    public enum eTechnicalSceneName
    {
        MainMenu,
        Opening,
        Credits
    }

    public enum eStageSceneName
    {
        UnsetScene,
        Stage1,
        Stage2,
        Stage3,
        Stage4
    }


    //DATA
    [SerializeField] private List<Scene> TechnicalScenes = new();
    [SerializeField] private List<StageDataSO> StageData = new();


    //
    private Dictionary<eTechnicalSceneName, Scene> TechnicalSceneDictionary = new();

    private Dictionary<eStageSceneName, Scene> StageSceneDictionary = new();
    private Dictionary<eStageSceneName, Sprite> SceneSpritesDictionary = new();



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        foreach (Scene s in TechnicalScenes)
        {
            TechnicalSceneDictionary.Add(s.name, s);
        }

        foreach (Scene s in StageScenes)
        {
            StageSceneDictionary.Add(s.name, s);
        }

        //SCENE SPRITES? (MIGHT NOT BE NECESSARY WITH MORE COMPLEX IMPLEMENTATION

    }

    // Update is called once per frame
    void Update()
    {
        
    }





    //FUNCTIONALITIES

    //SCENE HANDLING

    ///TECHNICAL SCENES
    public void LoadScene(eTechnicalSceneName targetScene)
    {
        string intendedScene = "";
        switch (targetScene)
        {
            case eTechnicalSceneName.MainMenu:
                intendedScene = "";//TODO: 
                break;
            case eTechnicalSceneName.Opening:
                intendedScene = "";//TODO: 
                break;
            case eTechnicalSceneName.Credits:
                intendedScene = "";//TODO: 
                break;
        }

        //TODO: THIS CAN BE EXPORTED AS A DEDICATED FUNCTIONALITY
        if (!string.IsNullOrEmpty(intendedScene)) SceneManager.LoadScene(intendedScene);
        else Debug.Log("Invalid Target Scene: " + targetScene);

    }


    ///STAGE SCENES
    public Sprite GetAssociatedSprite(eStageSceneName targetScene)
    {
        Sprite intendedSprite;

        switch (targetScene)
        {
            //TODO: USE A COMPLEX DATA STRUCTURE (SCRIPTABLEOBJECTS OR PREFABS) TO HANDLE THIS IN A BETTER WAY

            case eStageSceneName.Stage1:
                intendedSprite = SceneSprites[1];
                break;
            case eStageSceneName.Stage2:
                intendedSprite = SceneSprites[2];
                break;
            case eStageSceneName.Stage3:
                intendedSprite = SceneSprites[3];
                break;
            case eStageSceneName.Stage4:
                intendedSprite = SceneSprites[4];
                break;
            default:
                intendedSprite = SceneSprites[0];
                break;
        }

        return intendedSprite;
    }

    public void LoadScene(eStageSceneName targetScene)
    {
        string intendedScene;
        switch (targetScene)
        {
            case eStageSceneName.Stage1:
                intendedScene = "";//TODO: 
                break;
            case eStageSceneName.Stage2:
                intendedScene = "";//TODO: 
                break;
            case eStageSceneName.Stage3:
                intendedScene = "";//TODO: 
                break;
            case eStageSceneName.Stage4:
                intendedScene = "";//TODO: 
                break;
            default:
                intendedScene = "";
                break;
        }

        //TODO: THIS CAN BE EXPORTED AS A DEDICATED FUNCTIONALITY
        if (!string.IsNullOrEmpty(intendedScene)) SceneManager.LoadScene(intendedScene);
        else Debug.Log("Invalid Target Scene: " + targetScene);

    }

}
