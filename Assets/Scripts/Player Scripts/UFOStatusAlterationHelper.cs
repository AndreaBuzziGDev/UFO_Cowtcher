using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOStatusAlterationHelper
{
    //ALL STATIC CODE

    //
    public static bool HasBuffMoveSpeed()
    {
        foreach(SAAbstract sa in GetPlayerAlterations())
        {
            if (sa.Type == SAAbstract.EBuffType.SpeedBoost) return true;
        }

        return false;
    }

    public static bool HasBuffCaptureSpeed()
    {
        foreach (SAAbstract sa in GetPlayerAlterations())
        {
            if (sa.Type == SAAbstract.EBuffType.FastCatch) return true;
        }

        return false;
    }

    public static bool HasBuffFuelGain()
    {
        foreach (SAAbstract sa in GetPlayerAlterations())
        {
            if (sa.Type == SAAbstract.EBuffType.FuelBoost2X) return true;
        }

        return false;
    }

    public static bool HasBuffRadar()
    {
        foreach (SAAbstract sa in GetPlayerAlterations())
        {
            if (sa.Type == SAAbstract.EBuffType.Radar) return true;
        }

        return false;
    }

    public static bool HasBuffCaptureRadius()
    {
        foreach (SAAbstract sa in GetPlayerAlterations())
        {
            if (sa.Type == SAAbstract.EBuffType.CaptureRadius) return true;
        }

        return false;
    }


    //ALTERNATIVE STATUS ALTERATIONS (NOT VIA PICKUP)
    public static bool HasStun() => GameController.Instance.FindPlayerAnywhere().IsStunned;
    public static bool HasFreeze() => GameController.Instance.FindPlayerAnywhere().IsFrozen;




    //UTILITIES
    public static List<SAAbstract> GetPlayerAlterations()
    {
        return GameController.Instance.FindPlayerAnywhere().StatusAlterations;
    }

    public static bool HasPositiveAlterations()
    {
        List<SAAbstract> allAlterations = GetPlayerAlterations();

        foreach(SAAbstract alteration in allAlterations)
        {
            if (alteration.GetType() == typeof(SASpeedBoost)) return true;
            if (alteration.GetType() == typeof(SAFuelGainBoost)) return true;
            if (alteration.GetType() == typeof(SACaptureSpeed)) return true;
            if (alteration.GetType() == typeof(SACaptureRadius)) return true;
        }

        return false;
    }


}
