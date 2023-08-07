using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CowdexPage
{
    //DATA
    public Sprite cowSprite;
    public Cow myCow;


    //CONSTRUCTOR
    public CowdexPage(CowSO.UniqueID cowUID)
    {
        myCow = Cowdex.Instance.GetCow(cowUID);

        GameObject visualChild = myCow.gameObject.transform.Find("VisualChild").gameObject;
        Debug.Log("CowdexPage - visualChild: " + visualChild.name);

        cowSprite = visualChild.GetComponent<SpriteRenderer>().sprite;
        Debug.Log("CowdexPage - visualChild cowImage: " + cowSprite);

    }


    //METHODS
    //FUNCTIONALITIES



}
