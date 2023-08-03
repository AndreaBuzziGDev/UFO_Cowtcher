using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleStructure : MonoBehaviour, IInteractible
{
    //DATA
    ///
    private bool hasBeenActivated = false;
    public bool HasBeenActivated { get { return hasBeenActivated; } }



    ///STRUCTURE DATA
    [SerializeField] private StructureAbstractSO StructureScriptableObject;
    StructureAbstract myStructure;


    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        if (StructureScriptableObject != null) myStructure = StructureScriptableObject.GetStructure();
        else Debug.LogError("Structure " + this.gameObject.name + " is missing Data. Assign Scriptable Object.");
    }

    // Update is called once per frame
    void Update()
    {
        //HANDLE THE STRUCTURE'S LOGIC
        
    }



    //FUNCTIONALITIES

    ///ENABLE TURRET



    ///INTERACT
    public void Interact(GameObject interactionSource)
    {
        //TODO: ENABLE TURRET WITH CAPTURE


        //IF SOURCE UFO
        if (IsObjectWithinOperativeRadius(interactionSource))
        {
            //TODO: SHOULD BE REFACTORED TO INTERVIEW THE StructureAbstract OBJECT, IN ORDER TO ALLOW DIFFERENT BEHAVIOURS
            if (!hasBeenActivated)
            {
                myStructure.DoBehaviour();
                hasBeenActivated = true;
            }
        }
    }



    //UTILITIES
    public bool IsObjectWithinOperativeRadius(GameObject within)
    {
        float distance = (this.transform.position - within.transform.position).magnitude;
        return distance < myStructure.OperativeRadius;
    }

}
