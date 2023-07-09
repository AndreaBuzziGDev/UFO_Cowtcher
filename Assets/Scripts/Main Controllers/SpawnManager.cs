using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    //DATA
    [SerializeField] private List<SpawnPoint> allSpawnPoints;//NB: THIS WILL BE POPULATED AT THE LAUNCH OF THE SCENE, NOT MANUALLY IN THE EDITOR.

    //TODO: VERIFY IF SERIALIZATION WORKS.
    [SerializeField] private List<CowSummoningRitual> rituals;//NB: THIS WILL BE POPULATED AT RUNTIME. DO NOT EDIT MANUALLY IN THE EDITOR.

    [SerializeField] private List<ScriptableRitual> allTemplateRituals;//PUT ALL SCRIPTABLE OBJECT RITUALS INSIDE HERE.

    [SerializeField] private List<Cow> allowedCows;//PUT ALL PREFAB (GameObject) COWs INSIDE HERE.


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

    //TODO: DEVELOP A DEBUG FUNCTIONALITY THAT DETECTS DUPLICATES AMONG THE ScriptableRitual AND REPORTS THEM AS ERRORS ON THE GAME/EDITOR CONSOLE.


}
