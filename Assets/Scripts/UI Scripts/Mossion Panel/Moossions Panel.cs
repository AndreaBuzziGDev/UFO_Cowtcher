using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoossionsPanel : MonoBehaviour
{
    //DATA
    ///GUI REFERENCES
    [SerializeField] private MoossionsInformations Info_1;
    [SerializeField] private MoossionsInformations Info_2;
    [SerializeField] private MoossionsInformations Info_3;

    ///MOOSSION ICONS
    [SerializeField] private Sprite IconCaptureGeneric;
    [SerializeField] private Sprite IconCaptureSpecific;
    [SerializeField] private Sprite IconCaptureBuff;
    [SerializeField] private Sprite IconCaptureTurret;


    //METHODS

    // Start is called before the first frame update
    void OnEnable()
    {
        UpdateInformations();
    }


    //FUNCTIONALITIES
    public void UpdateInformations()
    {
        //RETRIEVE CURRENT MOOSSIONS
        Moossion moo_1 = MoossionManagerV2.Instance.MoossionOne;
        Moossion moo_2 = MoossionManagerV2.Instance.MoossionTwo;
        Moossion moo_3 = MoossionManagerV2.Instance.MoossionThree;

        //APPLY UPDATED INFO TO MoossionsInformations
        ///MOOSSION 1
        Info_1.UpdateInfos(moo_1, GetMatchingIcon(moo_1));

        ///MOOSSION 2
        Info_1.UpdateInfos(moo_2, GetMatchingIcon(moo_2));

        ///MOOSSION 3
        Info_1.UpdateInfos(moo_3, GetMatchingIcon(moo_3));


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
