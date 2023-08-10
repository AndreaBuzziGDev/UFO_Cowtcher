using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowCollider : MonoBehaviour
{
    //DATA
    [SerializeField] private Cow parentCow;
    private CowMovement mov;


    //METHODS
    //...
    private void Awake()
    {
        mov = parentCow.GetComponent<CowMovement>();
    }



    //FUNCTIONALITIES
    public CowMovement GetMovement() => mov;

}
