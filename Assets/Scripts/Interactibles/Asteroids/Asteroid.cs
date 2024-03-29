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
    [SerializeField] [Range(1, 10)] private int quantityOnCapture = 5;//TODO: USE
    public int QuantityOnCapture { get { return quantityOnCapture; } }

    ///GAMEPLAY PROPERTIES - ADDITIONAL CONTROL FEATURES
    [SerializeField] private bool spawnsOnBadImpact;
    //[SerializeField] private float badImpactCoordY = 2;

    ///ASTEROID CONTENT
    [SerializeField] private MonoInteractible myAsteroidContent;

    ///EXPLOSION ON IMPACT
    [SerializeField] private Vector3 additionalTranslate;
    [SerializeField] private GameObject ImpactExplosion;

    ///TRAIL SOUND
    [SerializeField] private AudioSource asteroidTrailSound;
    [SerializeField] private float maxHearingDistance = 20f;

    ///EXPLOSION SOUND
    [SerializeField] private GameObject asteroidExplosionSoundCarryingPrefab;



    //METHODS
    //...
    private void Start()
    {
        if (myAsteroidContent == null) 
            Debug.LogError("Asteroid " + this.gameObject.name + " has no content assigned.");


        //NORMALIZED POSITION
        Vector3 myNormalizedPos = new Vector3(
            this.transform.position.x,
            0,
            this.transform.position.z
            );

        if ((myNormalizedPos - GameController.Instance.FindUFOAnywhere().GetPositionXZ()).magnitude < maxHearingDistance){
            asteroidTrailSound.Play();
        }
    }


    //COLLISION
    void OnCollisionEnter(Collision collision)
    {
        bool isWithinGrid = SpawningGrid.Instance.IsPointWithinGrid(this.transform.position);

        //IF IMPACTED WITHIN SPAWNIN GRID DEPLOY CONTENT
        if (isWithinGrid && myAsteroidContent != null)
        {
            Instantiate(myAsteroidContent.gameObject, new Vector3(this.transform.position.x, 0, this.transform.position.z), Quaternion.identity);
        }

        HandleImpact();
    }

    //FUNCTIONALITIES
    private void HandleImpact()
    {
        //EXPLOSION ON IMPACT
        if(ImpactExplosion != null)
        {
            GameObject explosionPrefab = Instantiate(ImpactExplosion, this.transform.position + additionalTranslate, Quaternion.identity);
            //TODO: DESTROY DELAYED OR SOMEHOW STOP EXPLOSION FROM OCCURRING
            Destroy(explosionPrefab, 5);
        }

        //PLAY SOUND OF EXPLOSION
        GameObject soundExplosion = Instantiate(asteroidExplosionSoundCarryingPrefab, this.transform.position, Quaternion.identity);
        Destroy(soundExplosion, 4);

        //DESTROY ASTEROID
        Destroy(this.gameObject);
    }

    
}
