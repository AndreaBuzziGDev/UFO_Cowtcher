using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowCollider : MonoBehaviour
{
    //DATA
    [SerializeField] private Cow parentCow;
    private CowMovement mov;

    ///COLLISION USEFUL DATA
    


    //METHODS
    //...
    private void Awake()
    {
        mov = parentCow.GetComponent<CowMovement>();
    }


    //COLLISION DETECTION
    void OnCollisionEnter(Collision collision)
    {
        //
        ContactPoint contact = collision.contacts[0];
        Debug.Log("CowCollider - OnCollisionEnter Normal: " + contact.normal);

        //


    }


    //FUNCTIONALITIES
    public Cow GetCow() => parentCow;
    public CowMovement GetMovement() => mov;

}
