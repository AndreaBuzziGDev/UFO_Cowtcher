using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryCowEscape : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject otherGO = collision.gameObject;
        Cow compCow = otherGO.GetComponent<Cow>();
        if (compCow != null && (compCow.Rarity == ScriptableCow.Rarity.Legendary))
        {
            Debug.Log("LEGENDARY COW!");
        }

    }


}
