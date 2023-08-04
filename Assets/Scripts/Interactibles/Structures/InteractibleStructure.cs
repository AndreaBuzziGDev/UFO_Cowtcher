using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleStructure : MonoBehaviour, IInteractible
{
    //DATA
    ///
    private bool hasBeenDepleted = false;
    public bool HasBeenDepleted { get { return hasBeenDepleted; } set { hasBeenDepleted = value; } }



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
        //IF SOURCE UFO
        if (IsObjectWithinOperativeRadius(interactionSource))
        {
            //TODO: SHOULD BE REFACTORED TO INTERVIEW THE StructureAbstract OBJECT, IN ORDER TO ALLOW DIFFERENT BEHAVIOURS
            if (!hasBeenDepleted)
            {
                myStructure.DoBehaviour(this);
                hasBeenDepleted = true;
            }
        }
    }



    //UTILITIES
    public bool IsObjectWithinOperativeRadius(GameObject within)
    {
        Vector3 basePosition = new Vector3(within.transform.position.x, 0, within.transform.position.z);
        float distance = (this.transform.position - basePosition).magnitude;
        return distance < myStructure.OperativeRadius;
    }


}
