using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoossCaptGeneric : Moossion
{
    //DATA



    //CONSTRUCTOR
    public MoossCaptGeneric(Type type, int quantity) : base (type, quantity)
    {

    }



    //METHODS
    //MOOSSIONS SHOULD INTERCEPT AN EVENT THAT CARRIES THE INFOS ON A CAPTURED COW.
    //THE CONTENT OF THIS EVENT SHOULD BE CHECKED AND THE MISSION SHOULD PROGRESS IF THE CHECK IS PASSED.



    //ABSTRACT METHODS CONCRETIZATION
    ///DESCRIPTION
    public override string GetDescription()
    {
        return "Capture " + TargetQuantity + " cows of any type.";
    }

    ///COW CAPTURE LOGIC PROGRESS
    public override void HandleProgressLogic(Cow CapturedCow)
    {
        DoProgress(1);
    }




    //UTILITIES


}
