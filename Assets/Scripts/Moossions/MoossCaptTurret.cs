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



    //ABSTRACT METHODS CONCRETIZATION
    ///DESCRIPTION
    public override string GetDescription()
    {
        return "Capture " + TargetQuantity + " cows while under the effect of a " + GetTurretNameForDesc(turret) + " Turret.";
    }

    ///COW CAPTURE LOGIC PROGRESS
    public override void HandleProgressLogic(Cow CapturedCow)
    {
        Debug.Log("Moossion - LOGIC FOR MOOSSION TYPE CAPTURE TURRET HAS NOT BEEN IMPLEMENTED");
        //TODO: EVALUATE SWITCH FROM SoughtTurret TO TYPE OF TURRET, DISCARD THE ENUM USED HERE

    }




    //UTILITIES
    ///
    public static SoughtTurret GetRandomTarget()
    {
        //TODO: IMPLEMENT A COW-TYPE TRACKING SYSTEM
        //TODO: WAIT FOR SpawnManager TO BE COMPLETE FOR THIS


        //TODO: RANDOMIZE EVEN FURTHER
        List<SoughtTurret> uniqueIDs = new List<SoughtTurret> { SoughtTurret.SlowingTurret, SoughtTurret.TerrorTurret };

        int randomIndex = Random.Range(0, uniqueIDs.Count - 1);

        return uniqueIDs[randomIndex];
    }



    ///
    public static string GetTurretNameForDesc(SoughtTurret sought)
    {
        switch (sought)
        {
            case SoughtTurret.TerrorTurret:
                return "Terror-Inflicting";

            case SoughtTurret.SlowingTurret:
                return "Slowing";

            default:
                return "INVALID TYPE " + sought;
        }

    }

}
