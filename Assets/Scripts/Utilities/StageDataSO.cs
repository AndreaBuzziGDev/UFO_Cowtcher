using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Stage Data", menuName = "Scene Data/Stage")]
public class StageDataSO : ScriptableObject
{
    //ASSOCIATED SCENE
    [SerializeField] private string associatedSceneName;
    public string AssociatedSceneName { get { return associatedSceneName; } }


    //ASSOCIATED PREVIEW SPRITE
    [SerializeField] private Sprite associatedSprite;
    public Sprite AssociatedSprite { get { return associatedSprite; } }


    //ENUM IDENTIFIER
    [SerializeField] private SceneNavigationController.eStageSceneName stageID;
    public SceneNavigationController.eStageSceneName StageID { get { return stageID; } }

    //ASSOCIATED LEVEL EXPERIENCE CAPS
    [SerializeField] private List<int> associatedLevelExperienceCaps = new();
    public List<int> AssociatedLevelExperienceCaps { get { return associatedLevelExperienceCaps; } }



}
