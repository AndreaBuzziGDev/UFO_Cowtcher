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
