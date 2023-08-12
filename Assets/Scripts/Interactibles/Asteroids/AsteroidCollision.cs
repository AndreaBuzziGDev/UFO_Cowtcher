using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    //DATA
    [SerializeField] private MonoInteractible myAsteroidContent;

    //METHODS

    //COLLISION
    void OnCollisionEnter(Collision collision)
    {
        //TODO: EDIT ASTEROID PREFAB SO THAT IT HAS A DEDICATED LAYER THAT DOES NOT COLLIDE WITH THE BOX COLLIDER ON THE FENCES (no mid-air impact)
        bool isWithinGrid = SpawningGrid.Instance.IsPointWithinGrid(this.transform.position);
        Debug.Log("CollisionAsteroids - OnCollisionEnter");

        //IF IMPACTED WITHIN SPAWNIN GRID DEPLOY CONTENT
        if (isWithinGrid && myAsteroidContent != null)
            Debug.Log("CollisionAsteroids - OnCollisionEnter: IS VALID POINT OF COLLISION");
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
    
}
