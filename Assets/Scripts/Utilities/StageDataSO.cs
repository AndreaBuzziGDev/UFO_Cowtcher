using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Stage Data", menuName = "Stage Data")]
public class StageDataSO : ScriptableObject
{
    //ASSOCIATED SCENE
    [SerializeField] private Scene associatedScene;
    public Scene AssociatedScene { get { return associatedScene; } }

    //ASSOCIATED PREVIEW SPRITE
    [SerializeField] private Sprite associatedSprite;
    public Sprite AssociatedSprite { get { return associatedSprite; } }


    //ENUM IDENTIFIER
    [SerializeField] private SceneNavigationController.eStageSceneName stageID;
    public SceneNavigationController.eStageSceneName StageID { get { return stageID; } }


}
