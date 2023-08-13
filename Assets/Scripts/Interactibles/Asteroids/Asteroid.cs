using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //DATA
    ///JUICYNESS - ASTEROID DIRECTION AND SPEED PROPERTIES
    /*
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float angleX = 10;
    [SerializeField] private float angleZ = 10;
    */

    ///GAMEPLAY PROPERTIES
    [SerializeField] [Range(1f, 100f)] private float contentSpawnChance = 30;
    [SerializeField] [Range(1, 10)] private int quantityOnCapture = 5;//TODO: USE

    ///GAMEPLAY PROPERTIES - ADDITIONAL CONTROL FEATURES
    [SerializeField] private bool spawnsOnBadImpact;
    [SerializeField] private float badImpactCoordY = 2;


    //TODO:
    //ADDITIONAL "FREE" ASTEROID CHANCE?
    //ADDITIONAL "FREE" ASTEROID MAX QUANTITY?
    //GRANT AT LEAST ONE DROP?

    ///ASTEROID CONTENT
    [SerializeField] private MonoInteractible myAsteroidContent;

    ///EXPLOSION ON IMPACT
    [SerializeField] private Vector3 additionalTranslate;
    [SerializeField] private GameObject ImpactExplosion;



    //METHODS
    //...
    private void Start()
    {
        if (myAsteroidContent == null) Debug.LogError("Asteroid " + this.gameObject.name + " has no content assigned.");
    }


    //COLLISION
    void OnCollisionEnter(Collision collision)
    {
        bool isWithinGrid = SpawningGrid.Instance.IsPointWithinGrid(this.transform.position);

        //IF IMPACTED WITHIN SPAWNIN GRID DEPLOY CONTENT
        if (isWithinGrid && myAsteroidContent != null)
        {
            float randomChance = Random.Range(1, 100);
            if (randomChance >= contentSpawnChance)
            {
                if (this.transform.position.y <= badImpactCoordY || spawnsOnBadImpact)
                {
                    //SPAWN ASTEROID CONTENT
                    Instantiate(myAsteroidContent.gameObject, new Vector3(this.transform.position.x, 0, this.transform.position.z), Quaternion.identity);
                }
            }
        }

        HandleImpact();
    }

    //FUNCTIONALITIES
    private void HandleImpact()
    {

        //TODO: DEVELOP EXPLOSION ON IMPACT
        //EXPLOSION ON IMPACT
        if(ImpactExplosion != null)
        {
            GameObject explosionPrefab = Instantiate(ImpactExplosion, this.transform.position + additionalTranslate, Quaternion.identity);
            //TODO: DESTROY DELAYED OR SOMEHOW STOP EXPLOSION FROM OCCURRING
            Destroy(explosionPrefab, 1);
        }


        //DESTROY ASTEROID
        Destroy(this.gameObject);
    }

    
}
