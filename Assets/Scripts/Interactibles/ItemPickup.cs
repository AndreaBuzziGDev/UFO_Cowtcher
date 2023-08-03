using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractible
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


    //IMPLEMENTING IInteractible

    public void Interact(GameObject interactionSource)
    {
        //DELIVER BUFF TO THE PLAYER UFO
        GameController.Instance.FindPlayerAnywhere().AddStatusAlteration(this.GetStatusAlteration());

        //DESTROY PICKED UP ITEM
        Destroy(this.gameObject);
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
