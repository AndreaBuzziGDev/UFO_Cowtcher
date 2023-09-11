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
        Stage4,
        Tutorial
    }


    //DATA
    [SerializeField] private List<TechnicalSceneDataSO> TechnicalScenes = new();
    [SerializeField] private List<StageDataSO> StageData = new();


    //DICTIONARIES
    ///TECHNICAL SCENES
    private Dictionary<eTechnicalSceneName, TechnicalSceneDataSO> TechnicalSceneDictionary = new();

    ///STAGES
    private Dictionary<eStageSceneName, StageDataSO> StageSceneDictionary = new();
    private Dictionary<eStageSceneName, Sprite> SceneSpritesDictionary = new();
    private Dictionary<string, StageDataSO> StageStringNamesDictionary = new();

    //HAS LOADED
    private bool hasLoaded = false;
    public bool HasLoaded { get { return hasLoaded; } }


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
            StageStringNamesDictionary.Add(s.AssociatedSceneName, s);

        }
        hasLoaded = true;
    }



    //FUNCTIONALITIES

    //SCENE HANDLING

    ///TECHNICAL SCENES
    public void LoadScene(eTechnicalSceneName targetScene)
    {
        //TODO: THIS CAN BE ENORMOUSLY SIMPLIFIED.
        string intendedScene = TechnicalSceneDictionary[eTechnicalSceneName.MainMenu].AssociatedSceneName;

        //TODO: THIS CAN BE EXPORTED AS A DEDICATED FUNCTIONALITY
        if (!string.IsNullOrEmpty(intendedScene)) SceneManager.LoadScene(intendedScene);
        else Debug.Log("Invalid Target Scene: " + targetScene);

    }


    ///STAGE SCENES
    public Sprite GetAssociatedSprite(eStageSceneName targetScene)
    {
        if(StageSceneDictionary.Count > 0)
        {
            switch (targetScene)
            {
                case eStageSceneName.Stage1:
                case eStageSceneName.Stage2:
                case eStageSceneName.Stage3:
                case eStageSceneName.Stage4:
                case eStageSceneName.Tutorial:
                    return StageSceneDictionary[targetScene].AssociatedSprite;
                default:
                    return StageSceneDictionary[eStageSceneName.UnsetScene].AssociatedSprite;
            }
        }
        else
        {
            return null;
        }
    }

    public string GetAssociatedName(eStageSceneName targetScene)
    {
        if (StageSceneDictionary.Count > 0)
        {
            switch (targetScene)
            {
                case eStageSceneName.Stage1:
                case eStageSceneName.Stage2:
                case eStageSceneName.Stage3:
                case eStageSceneName.Stage4:
                case eStageSceneName.Tutorial:
                    return StageSceneDictionary[targetScene].AssociatedSceneName;
                default:
                    return StageSceneDictionary[eStageSceneName.UnsetScene].AssociatedSceneName;
            }
        }
        else
        {
            return null;
        }
    }

    public int GetAssociatedLevelExperienceCap(eStageSceneName targetScene, int levelIndex)
    {
        int actualIndex = levelIndex - 1;
        switch (targetScene)
        {
            case eStageSceneName.Stage1:
            case eStageSceneName.Stage2:
            case eStageSceneName.Stage3:
            case eStageSceneName.Stage4:
                Debug.Log("SceneNavigationController - targetScene: " + targetScene + " - actualIndex: " + actualIndex);
                return StageSceneDictionary[targetScene].AssociatedLevelExperienceCaps[actualIndex];
            default:
                return 0;
        }
    }

    public void LoadScene(eStageSceneName targetScene)
    {
        //TODO: THIS CAN BE ENORMOUSLY SIMPLIFIED.
        string intendedScene;
        switch (targetScene)
        {
            case eStageSceneName.Stage1:
            case eStageSceneName.Stage2:
            case eStageSceneName.Stage3:
            case eStageSceneName.Stage4:
            case eStageSceneName.Tutorial:
                intendedScene = StageSceneDictionary[targetScene].AssociatedSceneName;
                break;
            default:
                intendedScene = "";
                break;
        }

        //TODO: THIS CAN BE EXPORTED AS A DEDICATED FUNCTIONALITY
        if (!string.IsNullOrEmpty(intendedScene)) SceneManager.LoadScene(intendedScene);
        else Debug.Log("Invalid Target Scene: " + targetScene);

    }


    public StageDataSO GetCurrentSceneData()
    {
        return StageStringNamesDictionary[SceneManager.GetActiveScene().name];
    }

}
