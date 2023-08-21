using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInfoCow
{
    //ENUMS
    public enum Knowledge{
        Unknown = 0,
        Known = 1,
        Captured = 2
    }


    //DATA
    private CowSO.UniqueID savedCowUID;
    private Knowledge knowledgeValue;

    ///DATA GETTERS
    public CowSO.UniqueID CowUID { get { return savedCowUID; } }

    public Knowledge KnowledgeValue { get { return knowledgeValue; } }

    public bool IsKnown { get { return 1 >= (int)knowledgeValue; } }
    public bool IsCaptured { get { return 2 == (int)knowledgeValue; } }



    //CONSTRUCTOR
    private SaveInfoCow()
    {
        //PRIVATE EMPTY CONSTRUCTOR TO AVOID INSTANCIATION OF AN EMPTY DATA CLASS

    }

    public SaveInfoCow(CowSO.UniqueID cowUID, Knowledge knowValue)
    {
        savedCowUID = cowUID;
        knowledgeValue = knowValue;
    }

    public SaveInfoCow(int cowIndex, int knowValue)
    {
        savedCowUID = (CowSO.UniqueID) cowIndex;
        knowledgeValue = (Knowledge) knowValue;

    }



}
