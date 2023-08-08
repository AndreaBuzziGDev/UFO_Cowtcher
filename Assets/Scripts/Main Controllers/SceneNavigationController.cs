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
    [SerializeField] private List<TechnicalSceneDataSO> TechnicalScenes = new();
    [SerializeField] private List<StageDataSO> StageData = new();


    //
    private Dictionary<eTechnicalSceneName, TechnicalSceneDataSO> TechnicalSceneDictionary = new();

    private Dictionary<eStageSceneName, StageDataSO> StageSceneDictionary = new();

    private Dictionary<eStageSceneName, Sprite> SceneSpritesDictionary = new();



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        foreach (TechnicalSceneDataSO s in TechnicalScenes)
        {
            TechnicalSceneDictionary.Add(s.TechnicalSceneID, s);
        }

        foreach (StageDataSO s in StageData)
        {
            StageSceneDictionary.Add(s.StageID, s);
            SceneSpritesDictionary.Add(s.StageID, s.AssociatedSprite);

        }
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
        //TODO: THIS CAN BE ENORMOUSLY SIMPLIFIED.
        string intendedScene = "";
        switch (targetScene)
        {
            case eTechnicalSceneName.MainMenu:
                intendedScene = TechnicalSceneDictionary[eTechnicalSceneName.MainMenu].AssociatedSceneName;
                break;
            case eTechnicalSceneName.Opening:
                intendedScene = TechnicalSceneDictionary[eTechnicalSceneName.Opening].AssociatedSceneName;
                break;
            case eTechnicalSceneName.Credits:
                intendedScene = TechnicalSceneDictionary[eTechnicalSceneName.Credits].AssociatedSceneName;
                break;
        }

        //TODO: THIS CAN BE EXPORTED AS A DEDICATED FUNCTIONALITY
        if (!string.IsNullOrEmpty(intendedScene)) SceneManager.LoadScene(intendedScene);
        else Debug.Log("Invalid Target Scene: " + targetScene);

    }


    ///STAGE SCENES
    public Sprite GetAssociatedSprite(eStageSceneName targetScene)
    {
        //TODO: THIS CAN BE ENORMOUSLY SIMPLIFIED.
        Sprite intendedSprite;
        switch (targetScene)
        {
            case eStageSceneName.Stage1:
                intendedSprite = StageSceneDictionary[eStageSceneName.Stage1].AssociatedSprite;
                break;
            case eStageSceneName.Stage2:
                intendedSprite = StageSceneDictionary[eStageSceneName.Stage2].AssociatedSprite;
                break;
            case eStageSceneName.Stage3:
                intendedSprite = StageSceneDictionary[eStageSceneName.Stage3].AssociatedSprite;
                break;
            case eStageSceneName.Stage4:
                intendedSprite = StageSceneDictionary[eStageSceneName.Stage4].AssociatedSprite;
                break;
            default:
                intendedSprite = StageSceneDictionary[eStageSceneName.UnsetScene].AssociatedSprite;
                break;
        }

        return intendedSprite;
    }

    public void LoadScene(eStageSceneName targetScene)
    {
        //TODO: THIS CAN BE ENORMOUSLY SIMPLIFIED.
        string intendedScene;
        switch (targetScene)
        {
            case eStageSceneName.Stage1:
                intendedScene = StageSceneDictionary[eStageSceneName.Stage1].AssociatedSceneName;
                break;
            case eStageSceneName.Stage2:
                intendedScene = StageSceneDictionary[eStageSceneName.Stage2].AssociatedSceneName;
                break;
            case eStageSceneName.Stage3:
                intendedScene = StageSceneDictionary[eStageSceneName.Stage3].AssociatedSceneName;
                break;
            case eStageSceneName.Stage4:
                intendedScene = StageSceneDictionary[eStageSceneName.Stage4].AssociatedSceneName;
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
