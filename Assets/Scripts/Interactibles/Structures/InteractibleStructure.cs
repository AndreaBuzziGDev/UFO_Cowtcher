using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleStructure : MonoBehaviour
{
    //DATA
    ///
    private bool isOperative = false;
    public bool IsOperative { get { return isOperative; } }

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
    public bool IsObjectWithinOperativeRadius(GameObject within)
    {
        float distance = (this.transform.position - within.transform.position).magnitude;
        return distance < myStructure.OperativeRadius;
    }



}
