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

}
