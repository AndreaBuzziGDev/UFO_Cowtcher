using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Technical Scene", menuName = "Scene Data/Technical")]
public class TechnicalSceneDataSO : ScriptableObject
{
    //ASSOCIATED SCENE
    [SerializeField] private Scene associatedScene;
    public Scene AssociatedScene { get { return associatedScene; } }


    //ENUM IDENTIFIER
    [SerializeField] private SceneNavigationController.eTechnicalSceneName technicalSceneID;
    public SceneNavigationController.eTechnicalSceneName TechnicalSceneID { get { return technicalSceneID; } }

}
