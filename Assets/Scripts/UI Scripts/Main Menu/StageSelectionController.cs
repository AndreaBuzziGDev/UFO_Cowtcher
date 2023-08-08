using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectionController : MonoBehaviour
{
    //DATA
    
    ///STRUCTURAL DATA
    [SerializeField] private List<SceneNavigationController.eStageSceneName> SceneNamesList = new();

    private bool isSceneSet;
    private SceneNavigationController.eStageSceneName targetStageScene;


    ///GUI REFERENCES
    [SerializeField] private Image scenePreview;




    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        isSceneSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //FUNCTIONALITIES
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
            if (isSceneSet)
            {
                //scenePreview.sprite = 
            }
            else
            {
                //scenePreview.sprite =
            }
        }
    }



}
