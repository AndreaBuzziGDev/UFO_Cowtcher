using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAsteroids : MonoBehaviour
{
    [SerializeField] private MonoInteractible myAsteroidContent;



    void OnCollisionEnter(Collision collision)
    {
        //TODO: EDIT ASTEROID PREFAB SO THAT IT HAS A DEDICATED LAYER THAT DOES NOT COLLIDE WITH THE BOX COLLIDER ON THE FENCES (no mid-air impact)
        bool isWithinGrid = SpawningGrid.Instance.IsPointWithinGrid(this.transform.position);

        //IF IMPACTED WITHIN SPAWNIN GRID DEPLOY CONTENT
        if (isWithinGrid && myAsteroidContent != null)
        {
            //TODO: DEVELOP RANDOM CHANCE TO DEPLOY ITEM ON IMPACT

            Instantiate(myAsteroidContent.gameObject, new Vector3(this.transform.position.x, 0, this.transform.position.z), Quaternion.identity);
        }

        //TODO: DEVELOP EXPLOSION ON IMPACT

        Destroy(this.gameObject);

        /*
        GameObject otherGO = collision.gameObject;
        Cow compCow = otherGO.GetComponent<Cow>();
        if (compCow != null && (compCow.Rarity == CowSO.Rarity.Legendary))
        {
            Debug.Log("compCow.IsPanicking: " + compCow.IsPanicking);
            if (compCow.IsPanicking)
            {
                compCow.Flee();
            }
        }
        */
    }
}
