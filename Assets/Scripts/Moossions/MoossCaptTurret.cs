using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossCaptTurret : Moossion
{
    //ENUMS
    public enum SoughtTurret
    {
        TerrorTurret,
        SlowingTurret
    }

    //DATA
    private SoughtTurret turret;

    public SoughtTurret Buff { get { return turret; } }


    //CONSTRUCTOR
    public MoossCaptTurret(Type type, int quantity, SoughtTurret targetTurret) : base(type, quantity)
    {
        turret = targetTurret;
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
