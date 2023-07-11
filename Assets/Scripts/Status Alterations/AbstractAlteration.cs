using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAlteration
{
    //TODO: IMPLEMENT BUFF USAGE WHERE NEEDED

    public enum EBuffType
    {
        None,
        SpeedBoost,
        FuelBoost2X,
        FastCatch,
        FuelLoss,
        Acceleration,
        ScreenTerror,
        LevelTerror
    }

    public abstract void ApplyBuff();

}
