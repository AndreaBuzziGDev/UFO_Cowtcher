using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //ENUMS
    public enum Type
    {
        GenericEnvironment,
        Barn,
        Paddock,
        Tree,
        Rock
    }


    //DATA
    [SerializeField] private Type spawnType = 0;
    public Type SpawnType { get { return spawnType; } }

    [SerializeField] private float spawnRadius = 2.0f;


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
    public void Spawn(Cow interestedCow)
    {
        Vector3 newCowPosition = UtilsRadius.RandomPositionOnCircleRadius(spawnRadius) + transform.position;
        interestedCow.transform.position = newCowPosition;
        interestedCow.gameObject.SetActive(true);
    }


}
