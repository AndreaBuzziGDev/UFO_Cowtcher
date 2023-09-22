using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowCollider : MonoBehaviour
{
    //DATA
    [SerializeField] private Cow parentCow;
    private CowMovement mov;

    ///COLLISION USEFUL DATA
    private Vector3 lastCollisionNormal;

    private bool hasCollided;
    public bool HasCollided { get { return hasCollided; } }



    //METHODS
    //...
    private void Awake()
    {
        //TODO: HANDLE VIA SERIALIZATION?
        mov = parentCow.GetComponent<CowMovement>();
    }


    //COLLISION DETECTION
    void OnCollisionEnter(Collision collision)
    {
        //
        ContactPoint contact = collision.contacts[0];
        Debug.Log("CowCollider - OnCollisionEnter Normal: " + contact.normal);

        //
        lastCollisionNormal = contact.normal;
        hasCollided = true;
    }


    //FUNCTIONALITIES
    public Cow GetCow() => parentCow;
    public CowMovement GetMovement() => mov;



    public Vector3 GetCollisionData()
    {
        hasCollided = false;
        return lastCollisionNormal;
    }


}
