using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    //DATA
    ///STATUS ALTERATION
    public SAAbstractSO Alteration;



    //METHODS
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //FUNCTIONALITIES
    public SAAbstract getStatusAlteration()
    {
        return Alteration.GetBuff();
    }

}
