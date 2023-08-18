using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossCaptGeneric : Moossion
{
    //DATA



    //CONSTRUCTOR
    public MoossCaptGeneric(Type type, int quantity) : base (type, quantity)
    {

    }



    //METHODS

    public override int GetDifficultyBasedRandomQuantity(int difficultyCoefficient)
    {
        //TODO: SOME DEGREE OF RANDOMIZATION


        //
        return 2 + difficultyCoefficient;
    }

}
