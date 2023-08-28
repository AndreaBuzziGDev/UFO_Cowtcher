using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossionPoolGeneric
{
    //DATA
    ///TEST DATA
    private static CowSO.UniqueID testCowUID = CowSO.UniqueID.C000BlackCow;

    //METHODS
    //...


    //INITIALIZATION
    public static Moossion PickRandomMoossion()
    {
        int randomIndex = Random.Range(1, 11);
        switch (randomIndex)
        {
            case 1:
                return Moossion1();
            case 2:
                return Moossion2();
            case 3:
                return Moossion3();
            case 4:
                return Moossion4();
            case 5:
                return Moossion5();
            case 6:
                return Moossion6();
            case 7:
                return Moossion7();
            case 8:
                return Moossion8();
            case 9:
                return Moossion9();
            case 10:
                return Moossion10();
            default:
                Debug.LogError("MossionPoolGeneric - Error, defaulting to null");
                return null;
        }
    }


    //MOOSSIONS

    public static Moossion Moossion1()
    {
        //CONFIGURE
        //Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 1);
        //Moossion mooss = new MoossCaptSpecific(Moossion.Type.CaptureSpecific, 1, testCowUID);
        Moossion mooss = new MoossCaptBuff(Moossion.Type.CaptureBuff, 1, MoossCaptBuff.SoughtBuff.SpeedMovementBoost);

        return mooss;
    }

    public static Moossion Moossion2()
    {
        //CONFIGURE
        //Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 1);
        //Moossion mooss = new MoossCaptSpecific(Moossion.Type.CaptureSpecific, 1, testCowUID);
        Moossion mooss = new MoossCaptBuff(Moossion.Type.CaptureBuff, 1, MoossCaptBuff.SoughtBuff.SpeedMovementBoost);

        return mooss;
    }

    public static Moossion Moossion3()
    {
        //CONFIGURE
        //Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 1);
        //Moossion mooss = new MoossCaptSpecific(Moossion.Type.CaptureSpecific, 1, testCowUID);
        Moossion mooss = new MoossCaptBuff(Moossion.Type.CaptureBuff, 1, MoossCaptBuff.SoughtBuff.SpeedMovementBoost);

        return mooss;
    }

    public static Moossion Moossion4()
    {
        //CONFIGURE
        //Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 1);
        //Moossion mooss = new MoossCaptSpecific(Moossion.Type.CaptureSpecific, 1, testCowUID);
        Moossion mooss = new MoossCaptBuff(Moossion.Type.CaptureBuff, 1, MoossCaptBuff.SoughtBuff.SpeedMovementBoost);

        return mooss;
    }

    public static Moossion Moossion5()
    {
        //CONFIGURE
        //Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 1);
        //Moossion mooss = new MoossCaptSpecific(Moossion.Type.CaptureSpecific, 1, testCowUID);
        Moossion mooss = new MoossCaptBuff(Moossion.Type.CaptureBuff, 1, MoossCaptBuff.SoughtBuff.SpeedMovementBoost);

        return mooss;
    }

    public static Moossion Moossion6()
    {
        //CONFIGURE
        //Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 1);
        //Moossion mooss = new MoossCaptSpecific(Moossion.Type.CaptureSpecific, 1, testCowUID);
        Moossion mooss = new MoossCaptBuff(Moossion.Type.CaptureBuff, 1, MoossCaptBuff.SoughtBuff.SpeedMovementBoost);

        return mooss;
    }

    public static Moossion Moossion7()
    {
        //CONFIGURE
        //Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 1);
        //Moossion mooss = new MoossCaptSpecific(Moossion.Type.CaptureSpecific, 1, testCowUID);
        Moossion mooss = new MoossCaptBuff(Moossion.Type.CaptureBuff, 1, MoossCaptBuff.SoughtBuff.SpeedMovementBoost);

        return mooss;
    }

    public static Moossion Moossion8()
    {
        //CONFIGURE
        //Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 1);
        //Moossion mooss = new MoossCaptSpecific(Moossion.Type.CaptureSpecific, 1, testCowUID);
        Moossion mooss = new MoossCaptBuff(Moossion.Type.CaptureBuff, 1, MoossCaptBuff.SoughtBuff.SpeedMovementBoost);

        return mooss;
    }

    public static Moossion Moossion9()
    {
        //CONFIGURE
        //Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 1);
        //Moossion mooss = new MoossCaptSpecific(Moossion.Type.CaptureSpecific, 1, testCowUID);
        Moossion mooss = new MoossCaptBuff(Moossion.Type.CaptureBuff, 1, MoossCaptBuff.SoughtBuff.SpeedMovementBoost);

        return mooss;
    }

    public static Moossion Moossion10()
    {
        //CONFIGURE
        //Moossion mooss = new MoossCaptGeneric(Moossion.Type.CaptureGeneric, 1);
        //Moossion mooss = new MoossCaptSpecific(Moossion.Type.CaptureSpecific, 1, testCowUID);
        Moossion mooss = new MoossCaptBuff(Moossion.Type.CaptureBuff, 1, MoossCaptBuff.SoughtBuff.SpeedMovementBoost);

        return mooss;
    }

}
