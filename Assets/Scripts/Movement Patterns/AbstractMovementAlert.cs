using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovementAlert : AbstractMovementPattern
{
    //DATA
    [SerializeField] private float timerAlertSpecialMovement = 10.0f;
    public float TimerAlertSpecialMovement { get { return timerAlertSpecialMovement; } }


    //METHODS
    public abstract Vector3 ManagePanic(Cow myCow);

    public Vector3 GetFleeFromMap() => UtilsRadius.Vector3OnUnitCircle(1).normalized;


}
