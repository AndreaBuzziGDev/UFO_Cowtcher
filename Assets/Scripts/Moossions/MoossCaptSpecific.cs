using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossCaptSpecific : Moossion
{
    //DATA
    private CowSO.UniqueID targetUID;
    public CowSO.UniqueID TargetUID { get { return targetUID; } }


    //CONSTRUCTOR
    public MoossCaptSpecific(Type type, int quantity, CowSO.UniqueID cowUID) : base(type, quantity)
    {
        this.targetUID = cowUID;
    }



    //METHODS

    public override int GetDifficultyBasedRandomQuantity(int difficultyCoefficient)
    {
        //TODO: SOME DEGREE OF RANDOMIZATION

        //TODO: SOME DEGREE OF CONTROL (QUANTITY IS ADJUSTED BASED ON RARITY)


        //
        return 1 + difficultyCoefficient;
    }

}
