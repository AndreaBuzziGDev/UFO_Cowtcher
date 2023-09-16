using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowCaptureNew : MonoBehaviour
{
    //DATA
    private CowSO.UniqueID cowUID;
    public CowSO.UniqueID CowUID { get { return cowUID; } }


    //CONSTRUCTOR
    public CowCaptureNew(CowSO.UniqueID capturedCowUID) => cowUID = capturedCowUID;

}
