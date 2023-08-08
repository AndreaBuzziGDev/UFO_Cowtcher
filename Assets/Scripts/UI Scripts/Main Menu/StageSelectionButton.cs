using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectionButton : MonoBehaviour
{
    //DATA
    ///
    [SerializeField] private SceneNavigationController.eStageSceneName intendedTargetScene;

    ///GUI REFERENCES
    [SerializeField] private StageSelectionController parentController;


    //METHODS
    public void SetIntendedScene() => parentController.SetTargetScene(intendedTargetScene);

}
