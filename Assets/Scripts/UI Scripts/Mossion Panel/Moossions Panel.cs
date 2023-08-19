using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoossionsPanel : MonoBehaviour
{
    //DATA
    ///GUI REFERENCES
    private List<MoossionsInformations> informations = new();

    ///MOOSSION ICONS
    [SerializeField] private Sprite IconCaptureGeneric;
    [SerializeField] private Sprite IconCaptureSpecific;
    [SerializeField] private Sprite IconCaptureBuff;
    [SerializeField] private Sprite IconCaptureTurret;




    // Start is called before the first frame update
    void Start()
    {
        //TODO: BETTER TO CHANGE DIRECTLY INTO A BAKED GUI REFERENCE?
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

    public Sprite GetMatchingIcon(Moossion inputMoossion)
    {
        switch (inputMoossion.MoossionType)
        {
            case Moossion.Type.CaptureGeneric:
                return IconCaptureGeneric;
            case Moossion.Type.CaptureSpecific:
                return IconCaptureSpecific;
            case Moossion.Type.CaptureBuff:
                return IconCaptureBuff;
            case Moossion.Type.CaptureTurret:
                return IconCaptureTurret;
            default:
                Debug.LogError("MATCHING ICON NOT FOUND FOR TYPE: " + inputMoossion.MoossionType);
                return IconCaptureGeneric;
        }

    }





}
