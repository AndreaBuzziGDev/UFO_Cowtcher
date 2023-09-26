using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningMenuLoading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoToMainMenu())
    }

    //COROUTINES
    private IEnumerator GoToMainMenu()
    {
        //WAIT FOR TIME
        yield return new WaitForSeconds(3);

        SceneNavigationController.Instance.LoadScene(SceneNavigationController.eTechnicalSceneName.MainMenu);
    }

}
