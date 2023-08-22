using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CowdexPage
{
    //DATA
    //TODO: USE GETTERS

    ///FOUNDATIONAL DATA
    public IndexedCow myIndexedCow;

    private CowSO.UniqueID myCowUID;
    public CowSO.UniqueID MyCowUID { get { return myCowUID; } }

    ///DATA TO BE USED ON THE UI
    public Sprite cowSprite;
    public string cowName;
    public string cowDescription;
    public string cowBuff;//TODO: THIS IS A COMPLEX DATA TO HANDLE AND NEEDS SAFETIES

    //TODO: OTHER DATA, LIKE IF THE COW HAS BEEN DISCOVERED OR NOT... (use getters to get updated info from the cowdex itself)



    //CONSTRUCTOR
    public CowdexPage(IndexedCow myIndexedCow)
    {
        ///
        this.myIndexedCow = myIndexedCow;
        myCowUID = myIndexedCow.ReferenceTemplate.UID;

        GameObject visualChild = this.myIndexedCow.PrefabCow.gameObject.transform.Find("VisualChild").gameObject;

        ///
        cowSprite = visualChild.GetComponent<SpriteRenderer>().sprite;

        cowName = this.myIndexedCow.ReferenceTemplate.CowName;
        cowDescription = this.myIndexedCow.ReferenceTemplate.Description;
        if (string.IsNullOrEmpty(this.myIndexedCow.ReferenceTemplate.effect))
        {
            cowBuff = "---";
        }
        else
        {
            cowBuff = this.myIndexedCow.ReferenceTemplate.effect;
        }

    }


    //METHODS
    //FUNCTIONALITIES



}
