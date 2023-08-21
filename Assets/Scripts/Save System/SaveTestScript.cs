using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTestScript : MonoBehaviour
{
    //DATA
    CowSO.UniqueID testCow = CowSO.UniqueID.C000Jamal;


    //METHODS
    //...

    //TEST SAVE COW
    public void TestSaveCow()
    {


    }


    //TEST LOAD COW
    public void TestLoadCow()
    {
        SaveInfoCow cowSI = SaveSystem.LoadCowProgress(testCow);
        Debug.Log("cowSI CowUID: " + cowSI.CowUID);
        Debug.Log("cowSI KnowledgeValue: " + cowSI.KnowledgeValue);
        Debug.Log("cowSI IsKnown: " + cowSI.IsKnown);
        Debug.Log("cowSI IsCaptured: " + cowSI.IsCaptured);

    }


    //TEST ...


}
