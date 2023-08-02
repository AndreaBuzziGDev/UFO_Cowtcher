using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSummoningRitualModule
{
    //DATA
    private CowSO.UniqueID targetCowType;
    private int targetAmount;
    private int actualAmount;

    public bool IsReadyToSpawn { get { return (actualAmount >= targetAmount); } }


    //CONSTRUCTORS
    public CowSummoningRitualModule(CowSO.UniqueID assignedCowType, int target)
    {
        this.targetCowType = assignedCowType;
        this.targetAmount = target;
        this.actualAmount = 0;
    }


    //METHODS
    public void ChangeAmount(int delta) => actualAmount += delta;

    public void HandleCowSpawn() => this.actualAmount -= this.targetAmount;

}
