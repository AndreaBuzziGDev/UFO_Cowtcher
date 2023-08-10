using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryCowEscape : MonoBehaviour
{
    void OnCollisionStay(Collision collision)
    {
        //Debug.Log("LegendaryCowEscape");

        GameObject otherGO = collision.gameObject;
        Cow compCow = otherGO.GetComponent<Cow>();
        if (compCow != null /*&& (compCow.Rarity == CowSO.Rarity.Legendary)*/)
        {
            //Debug.Log("compCow.IsPanicking: " + compCow.IsPanicking);
            if (compCow.IsPanicking)
            {
                //compCow.Flee();
            }
        }

    }


}
