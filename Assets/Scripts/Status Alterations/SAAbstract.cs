using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SAAbstract
{
    //TODO: IMPLEMENT BUFF USAGE WHERE NEEDED

    //DATA
    public enum EBuffType
    {
        None,//SUPPOSEDLY UNUSED/USELESS
        SpeedBoost,
        FuelBoost2X,
        FastCatch,
        FuelLoss,
        Radar,
        CaptureRadius
    }

    protected EBuffType type = 0;
    public EBuffType Type { get { return type; } }


    ///TEMPLATE
    public abstract SAAbstractSO Template();

    ///BUFF
    public abstract void ApplyBuff();

    public virtual void ExpireBuff()
    {
        //DEFAULT: DO NOTHING

    }


    ///TIMERS
    public abstract void UpdateTimers(float delta);
    public abstract bool IsStillRunning();

}
