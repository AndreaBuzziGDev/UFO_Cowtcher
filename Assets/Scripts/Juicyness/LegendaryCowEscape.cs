using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryCowEscape : MonoBehaviour
{
    void OnCollisionStay(Collision collision)
    {
        GameObject otherGO = collision.gameObject;
        Cow compCow = otherGO.GetComponent<Cow>();
        if (compCow != null && (compCow.Rarity == CowSO.Rarity.Legendary))
        {
            if (compCow.IsPanicking)
            {
                compCow.Flee();
            }
        }

    }


}
