using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoSingleton<DifficultyManager>
{
    //DATA
    ///FUNCTIONALITY DATA
    [SerializeField] private bool captureScalingDifficulty;
    public bool IsCaptureScaling { get { return captureScalingDifficulty; } }


    ///STRUCTURAL DATA
    Dictionary<CowSO.UniqueID, int> CapturedCowsCounter = new();





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


    //INITIALIZATION
    public void Initialization()
    {
        InitializeCowCounter();


    }
    
    ///CAPTURED COW DIFFICULTY REGISTER
    private void InitializeCowCounter()
    {
        //GENERAL EQUALIZED DIFFICULTY --> START AT 0
        CapturedCowsCounter = new();

    }





    //FUNCTIONALITIES
    public void CountCapturedCow(CowSO.UniqueID interestedCowUID)
    {
        if (CapturedCowsCounter.ContainsKey(interestedCowUID))
        {
            CapturedCowsCounter[interestedCowUID]++;
        }
        else
            CapturedCowsCounter.Add(interestedCowUID, 1);
    }

    public int GetCountCapturedCow(CowSO.UniqueID interestedCowUID)
    {
        if (captureScalingDifficulty && CapturedCowsCounter.ContainsKey(interestedCowUID)) 
            return CapturedCowsCounter[interestedCowUID];
        else
            return 0;
    }



    //UTILITIES
    



}
