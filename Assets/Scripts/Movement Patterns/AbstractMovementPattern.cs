using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovementPattern : ScriptableObject
{
    //DATA
    [SerializeField] private float timerCalmSpecialMovement = 3.0f;
    public float TimerCalmSpecialMovement { get { return timerCalmSpecialMovement; } }

    public abstract Vector3 ManageMovement(Cow interestedCow);

}
