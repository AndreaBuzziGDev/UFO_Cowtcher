using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTestScript : MonoBehaviour
{
    //DATA
    CowSO.UniqueID testCowUID = CowSO.UniqueID.C001Kevin;


    //METHODS
    //...

    //TEST SAVE COW
    public void TestSaveCow()
    {
        SaveSystem.SaveCowProgress(testCowUID, SaveInfoCow.Knowledge.Known);
        Debug.Log("Saved Cow with UID: " + testCowUID);
    }


    //TEST LOAD COW
    public void TestLoadCow()
    {
        SaveInfoCow cowSI = SaveSystem.LoadCowProgress(testCowUID);
        Debug.Log("cowSI CowUID: " + cowSI.CowUID);
        Debug.Log("cowSI KnowledgeValue: " + cowSI.KnowledgeValue);
        Debug.Log("cowSI IsKnown: " + cowSI.IsKnown);
        Debug.Log("cowSI IsCaptured: " + cowSI.IsCaptured);

    }


    //TEST RESET COW
    public void TestResetCow()
    {
        SaveSystem.ResetCowProgress();
        Debug.Log("reset cow with UID: " + testCowUID);
        TestLoadCow();
    }




    //...


}
