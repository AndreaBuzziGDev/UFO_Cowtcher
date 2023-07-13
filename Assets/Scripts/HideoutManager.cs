using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideoutManager : MonoSingleton<HideoutManager>
{
    //DATA
    private Dictionary<ScriptableHideout.Type, List<Hideout>> allHideouts = new Dictionary<ScriptableHideout.Type, List<Hideout>>();

    //METHODS
    //...
    public override void Awake()
    {
        base.Awake();

    }

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
