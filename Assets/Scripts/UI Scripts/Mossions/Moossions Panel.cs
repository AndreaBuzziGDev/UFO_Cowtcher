using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoossionsPanel : MonoBehaviour
{
    //DATA
    private List<MoossionsInformations> informations = new();



    // Start is called before the first frame update
    void Start()
    {
        informations = this.gameObject.GetComponentsInChildren<MoossionsInformations>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //FUNCTIONALITIES
    public void UpdateInformations()
    {
        //RETRIEVE CURRENT MOOSSIONS


        //APPLY UPDATED INFO TO MoossionsInformations

        //TODO: DEVELOP

    }




}
