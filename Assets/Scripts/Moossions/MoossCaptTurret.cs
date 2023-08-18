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
    //MOOSSIONS SHOULD INTERCEPT AN EVENT THAT CARRIES THE INFOS ON A CAPTURED COW.
    //THE CONTENT OF THIS EVENT SHOULD BE CHECKED AND THE MISSION SHOULD PROGRESS IF THE CHECK IS PASSED.


}
