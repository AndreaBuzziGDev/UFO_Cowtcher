using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossionPoolGeneric
{
    //DATA
    ///MOOSSION POOL
    [SerializeField] private static List<Moossion> moossionPool = new();
    public static List<Moossion> MoossionPool { get { return moossionPool; } }

    ///TARGET MOOSSION POOL
    //TODO: USE ANOTHER SCRIPT


    //METHODS
    //...


    //INITIALIZATION
    public static void BakeMoossionPool()
    {
        //
    }


    //MOOSSIONS

    public static Moossion Moossion1()
    {
        //CONFIGURE
        Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 2);

        return mooss;
    }

    public static Moossion Moossion2()
    {
        //CONFIGURE
        Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 2);

        return mooss;
    }

    public static Moossion Moossion3()
    {
        //CONFIGURE
        Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 2);

        return mooss;
    }

    public static Moossion Moossion4()
    {
        //CONFIGURE
        Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 2);

        return mooss;
    }

    public static Moossion Moossion5()
    {
        //CONFIGURE
        Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 2);

        return mooss;
    }

    public static Moossion Moossion6()
    {
        //CONFIGURE
        Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 2);

        return mooss;
    }

    public static Moossion Moossion7()
    {
        //CONFIGURE
        Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 2);

        return mooss;
    }

    public static Moossion Moossion8()
    {
        //CONFIGURE
        Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 2);

        return mooss;
    }

    public static Moossion Moossion9()
    {
        //CONFIGURE
        Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 2);

        return mooss;
    }

    public static Moossion Moossion10()
    {
        //CONFIGURE
        Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 2);

        return mooss;
    }

}
