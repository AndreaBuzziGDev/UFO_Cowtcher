using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovementPattern
{
    //DATA

    //METHODS
    ///TEMPLATE
    public abstract IMovementPattern Template();

    ///MOVEMENT
    public abstract Vector3 ManageMovement(Cow interestedCow);

    ///TIMERS
    public abstract void UpdateTimers(float delta);
    public abstract void ResetTimers();

}
