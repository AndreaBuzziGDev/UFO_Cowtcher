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
    public SAAbstract GetStatusAlteration()
    {
        return Alteration.GetBuff();
    }


    //SPAWN ITEM
    ///SPAWN ON DEFINED POSITION
    public void Spawn(Vector3 intendedPosition)
    {
        this.transform.position = intendedPosition;
        this.gameObject.SetActive(true);
    }

    ///SPAWN ITEM RANDOMLY ON SPAWN GRID
    public void SpawnRandomly()
    {
        SpawningGrid.Instance.SpawnObjectInsideGrid(this);
    }


}
