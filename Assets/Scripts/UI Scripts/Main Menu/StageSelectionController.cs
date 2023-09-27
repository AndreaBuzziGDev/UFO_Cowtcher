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

    [SerializeField] private Button buttonStage1;
    [SerializeField] private Button buttonStage2;
    [SerializeField] private Button buttonStage3;
    [SerializeField] private Button buttonStage4;


    [SerializeField] private Button playButton;
    [SerializeField] private StageExpBar experienceBar;


    ///SOUNDS
    [SerializeField] private AudioSource playGameSound;



    //METHODS
    //...

    // Start is called before the first frame update
    void OnEnable()
    {
        //UNSET SCENE
        UnsetTargetScene();

        //UNLOCK REWARDS
        ProgressionSystem.UnlockAllAvailableRewards();

        //DEFAULT-ENABLE STAGE 1
        SaveSystem.SetStageUnlocked("Stage 1", true);

        //ENABLE STAGE BUTTONS
        buttonStage1.interactable = SaveSystem.IsStageUnlocked("Stage 1");
        buttonStage2.interactable = SaveSystem.IsStageUnlocked("Stage 2");
        buttonStage3.interactable = SaveSystem.IsStageUnlocked("Stage 3");
        buttonStage4.interactable = SaveSystem.IsStageUnlocked("Stage 4");

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
            if (isSceneSet)
            {
                //SET INTENDED PREVIEW SCENE
                scenePreview.sprite = SceneNavigationController.Instance.GetAssociatedSprite(targetStageScene);

                //UPDATE EXPERIENCE BAR
                experienceBar.UpdateExpBar(targetStageScene);

            }
            else
            {
                if (SceneNavigationController.Instance != null)
                {
                    //SET UNSETSCENE AS PREVIEW
                    scenePreview.sprite = SceneNavigationController.Instance.GetAssociatedSprite(SceneNavigationController.eStageSceneName.UnsetScene);

                    //UPDATE EXPERIENCE BAR
                    experienceBar.UpdateExpBar(SceneNavigationController.eStageSceneName.UnsetScene);
                }
            }
        }
    }


    ///TARGET REACHING
    public void LoadSelectedScene()
    {
        if (isSceneSet)
        {
            playGameSound.Play();
            StartCoroutine(LoadSceneRoutine());
        }
    }

    //COROUTINE
    private IEnumerator LoadSceneRoutine()
    {
        //WAIT FOR TIME
        yield return new WaitForSeconds(0.15f);

        //LOAD STAGE
        SceneNavigationController.Instance.LoadScene(targetStageScene);
    }

}
