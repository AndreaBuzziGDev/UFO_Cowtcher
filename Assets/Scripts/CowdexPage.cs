using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowdexPage : MonoBehaviour
{
    //FORECASTED THIS CLASS FOR FUTURE USAGES - EXPECTED TO BE A MONOBEHAVIOUR TO ATTACH TO A GameObject TO HANDLE UI-USED DATA

    //DATA
    private CowSO.UniqueID cowUID;
    public CowSO.UniqueID CowUID { get { return cowUID; } }

    private IndexedCow myIndexedCow;




    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //FUNCTIONALITIES
    public void RetrieveIndexedCowData()
    {
        myIndexedCow = Cowdex.Instance.GetIndexedCow(this.CowUID);
    }

    

    //TODO: METHOD TO HANDLE THE RITUAL "PROGRESSION" FROM IndexedCow TO SHOW UP ADEQUATELY IN THE GUI


}
