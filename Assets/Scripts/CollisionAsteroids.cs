using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAsteroids : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CollisionAsteroids");

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
