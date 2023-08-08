using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Technical Scene", menuName = "Scene Data/Technical")]
public class TechnicalSceneDataSO : ScriptableObject
{
    //ASSOCIATED SCENE
    [SerializeField] private string associatedSceneName;
    public string AssociatedSceneName { get { return associatedSceneName; } }


    //ENUM IDENTIFIER
    [SerializeField] private SceneNavigationController.eTechnicalSceneName technicalSceneID;
    public SceneNavigationController.eTechnicalSceneName TechnicalSceneID { get { return technicalSceneID; } }

}
