using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //DATA
    ///JUICYNESS - ASTEROID DIRECTION AND SPEED PROPERTIES
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float angleX = 10;
    [SerializeField] private float angleZ = 10;


    ///GAMEPLAY PROPERTIES
    [SerializeField] [Range(1f, 100f)] private float contentSpawnChance = 30;
    [SerializeField] private bool grantAtLeastOne;


    ///ASTEROID CONTENT
    [SerializeField] private MonoInteractible myAsteroidContent;




    //METHODS
    //...
    private void Awake()
    {
        if (myAsteroidContent == null) Debug.LogError("Asteroid " + this.gameObject.name + " has no content assigned.");
    }

    private void Start()
    {


    }


    //COLLISION
    void OnCollisionEnter(Collision collision)
    {
        bool isWithinGrid = SpawningGrid.Instance.IsPointWithinGrid(this.transform.position);

        //IF IMPACTED WITHIN SPAWNIN GRID DEPLOY CONTENT
        if (isWithinGrid && myAsteroidContent != null)
        {
            //TODO: DEVELOP RANDOM CHANCE TO DEPLOY ITEM ON IMPACT

            if (myAsteroidContent != null)
            {
                Instantiate(myAsteroidContent.gameObject, new Vector3(this.transform.position.x, 0, this.transform.position.z), Quaternion.identity);
            }
        }

        //TODO: DEVELOP EXPLOSION ON IMPACT

        Destroy(this.gameObject);
    }

    //FUNCTIONALITIES


    
}
