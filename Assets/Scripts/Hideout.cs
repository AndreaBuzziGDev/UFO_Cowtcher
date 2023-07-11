using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideout : MonoBehaviour
{
    //DATA
    [SerializeField] private ScriptableHideout HideoutTemplate;


    private List<HideoutSlot> hideoutSlots = new List<HideoutSlot>();

    ///TEMPLATE CLONED DATA
    private ScriptableHideout.Type type = 0;
    private int numberOfHideoutSlots;
    private float hideoutPermanenceTimer;


    //METHODS
    //...

    private void Awake()
    {
        //TODO: HANDLE CONSTRUCTION OF hideoutSlots

        //TODO: CLONE DATA FROM SCRIPTABLE HIDEOUT (TEMPLATE)

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //FUNCTIONALITIES
    public bool IsFull()
    {
        //TODO: IMPLEMENT

        return true;
    }

}
