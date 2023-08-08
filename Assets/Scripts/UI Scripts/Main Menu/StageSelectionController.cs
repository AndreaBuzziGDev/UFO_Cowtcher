using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectionController : MonoBehaviour
{
    //DATA
    
    ///STRUCTURAL DATA
    private bool isSceneSet;
    private SceneNavigationController.eStageSceneName targetStageScene;

    ///GUI REFERENCES
    [SerializeField] private Image scenePreview;
    [SerializeField] private Button playButton;



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        isSceneSet = false;
    }

    private void Update()
    {
        //DISABLE PLAY BUTTON IF INVALID
        playButton.interactable = isSceneSet;

    }



    //FUNCTIONALITIES

    ///TARGET SETTING
    public void UnsetTargetScene()
    {
        isSceneSet = false;
        SetTargetSceneGUI();
    }

    public void SetTargetScene(SceneNavigationController.eStageSceneName targetScene)
    {
        isSceneSet = true;
        targetStageScene = targetScene;

        SetTargetSceneGUI();
    }

    public void SetTargetSceneGUI()
    {
        if (scenePreview != null)
        {
            Sprite intendedSprite;

            if (isSceneSet) intendedSprite = SceneNavigationController.Instance.GetAssociatedSprite(targetStageScene);
            else intendedSprite = SceneNavigationController.Instance.GetAssociatedSprite(SceneNavigationController.eStageSceneName.UnsetScene);

            scenePreview.sprite = intendedSprite;
        }
    }


    ///TARGET REACHING
    public void LoadSelectedScene()
    {
        if (isSceneSet) SceneNavigationController.Instance.LoadScene(targetStageScene);
    }


}
