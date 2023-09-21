using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovementPattern
{
    //DATA

    //METHODS
    ///TEMPLATE
    public abstract MPAbstractParentSO Template();

    ///MOVEMENT
    public abstract Vector3 ManageMovement(CowMovement myCowMovement);

    
    ///JUMP
    public bool Jumps { get { return Template().jumps; } }
    public float JumpHeight { get { return Template().jumpHeight; } }
    public float JumpSpeed { get { return Template().jumpSpeed; } }


    ///TIMERS
    public abstract void UpdateTimers(float delta);
    public abstract void ResetTimers();

}
