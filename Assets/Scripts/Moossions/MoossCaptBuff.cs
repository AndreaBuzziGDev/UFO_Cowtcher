using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossCaptBuff : Moossion
{
    //ENUMS
    public enum SoughtBuff
    {
        SpeedMovementBoost,
        FuelGainBoost
    }

    //DATA
    private SoughtBuff buff;

    public SoughtBuff Buff { get { return buff; } }


    //CONSTRUCTOR
    public MoossCaptBuff(Type type, int quantity, SoughtBuff targetBuff) : base(type, quantity)
    {
        buff = targetBuff;
    }



    //METHODS

    public override int GetDifficultyBasedRandomQuantity(int difficultyCoefficient)
    {
        //TODO: SOME DEGREE OF RANDOMIZATION

        //TODO: SOME DEGREE OF CONTROL (QUANTITY IS ADJUSTED BASED ON RARITY)


        //
        return 2 + difficultyCoefficient;
    }

}
