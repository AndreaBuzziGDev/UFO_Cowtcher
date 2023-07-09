using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //ENUMS
    public enum Type
    {
        GenericEnvironment,
        Granary,
        Paddock
    }


    //DATA
    private Type spawnType = Type.GenericEnvironment;
    public Type SpawnType { get { return spawnType; } }


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
