using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCalmStillness : AbstractMovementPattern
{
    //DATA
    ///TEMPLATE
    private readonly MPCalmStillnessSO template;

    //CONSTRUCTOR
    public MPCalmStillness(MPCalmStillnessSO inputTemplate)
    {
        this.template = inputTemplate;
    }


    ///TEMPLATE
    public override MPAbstractParentSO Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        return Vector3.zero;
    }

    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        //NOT NEEDED

    }
    public override void ResetTimers()
    {
        //NOT NEEDED

    }

}
