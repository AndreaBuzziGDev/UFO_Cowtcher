using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleStructure : MonoBehaviour
{
    //DATA
    [SerializeField] private StructureSOAbstract StructureScriptableObject;
    Structure myStructure;


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
        //HANDLEM THE STRUCTURE'S LOGIC
        
    }



    //FUNCTIONALITIES
    public bool WithinOperativeRadius(GameObject within)
    {
        float distance = (this.transform.position - within.transform.position).magnitude;
        return distance < myStructure.OperativeRadius;
    }



}
