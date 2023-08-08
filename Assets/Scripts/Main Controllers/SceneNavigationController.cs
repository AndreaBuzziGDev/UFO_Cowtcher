using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNavigationController : MonoSingleton<SceneNavigationController>
{
    //ENUMS
    public enum eTechnicalSceneName
    {
        MainMenu,
        Opening,
        Credits
    }

    public enum eStageSceneName
    {
        UnsetScene,
        Stage1,
        Stage2,
        Stage3,
        Stage4
    }


    //DATA
    public List<Sprite> SceneSprites = new();



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //FUNCTIONALITIES

}
