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
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("CowCollider - OnCollisionStay");

        //
        /*
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 2)
            audioSource.Play();
        */
    }


    //FUNCTIONALITIES
    public Cow GetCow() => parentCow;
    public CowMovement GetMovement() => mov;

}
