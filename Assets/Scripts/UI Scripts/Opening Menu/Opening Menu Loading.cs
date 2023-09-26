using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningMenuLoading : MonoBehaviour
{
    [SerializeField] private float awaitForMainMenuTime = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoToMainMenu());
    }

    //COROUTINES
    private IEnumerator GoToMainMenu()
    {
        //WAIT FOR TIME
        yield return new WaitForSeconds(awaitForMainMenuTime);

        SceneNavigationController.Instance.LoadScene(SceneNavigationController.eTechnicalSceneName.MainMenu);
    }

}
