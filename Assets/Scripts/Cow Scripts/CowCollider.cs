using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowCollider : MonoBehaviour
{
    //DATA
    [SerializeField] private Cow cowScript;
    [SerializeField] private CowMovement mov;

    ///COLLISION USEFUL DATA
    private Vector3 lastCollisionNormal;

    private bool hasCollided;
    public bool HasCollided { get { return hasCollided; } }



    //METHODS
    //...

    //COLLISION DETECTION
    void OnCollisionEnter(Collision collision)
    {
        //
        ContactPoint contact = collision.contacts[0];

        //
        lastCollisionNormal = contact.normal;
        hasCollided = true;
    }


    //FUNCTIONALITIES
    public Cow GetCow() => cowScript;
    public CowMovement GetMovement() => mov;



    public Vector3 GetCollisionData()
    {
        hasCollided = false;
        return lastCollisionNormal;
    }


}
