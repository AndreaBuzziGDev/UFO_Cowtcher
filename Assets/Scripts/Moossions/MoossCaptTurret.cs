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

    ///DESCRIPTION HELPER
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

    ///COW CAPTURE LOGIC PROGRESS
    public override void HandleProgressLogic(Cow CapturedCow)
    {
        //TODO: EVALUATE SWITCH FROM SoughtTurret TO TYPE OF TURRET, DISCARD THE ENUM USED HERE
        switch (turret)
        {
            case SoughtTurret.TerrorTurret:
                if (CowManager.Instance.IsGlobalTerrify) DoProgress(1);
                break;
            case SoughtTurret.SlowingTurret:
                if (CowManager.Instance.IsGloballySlowed) DoProgress(1);
                break;
            default:
                Debug.LogError("Logic not implemented for Turret: " + turret);
                break;
        }
    }




    //UTILITIES
    public static SoughtTurret GetRandomTargetTurret()
    {
        List<SoughtTurret> uniqueIDs = new List<SoughtTurret> { SoughtTurret.SlowingTurret, SoughtTurret.TerrorTurret };

        int randomIndex = Random.Range(0, uniqueIDs.Count);

        return uniqueIDs[randomIndex];
    }

}
