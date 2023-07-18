using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MPAbstractAlertSO : ScriptableObject, IMovementPattern
{
    public abstract AbstractMovementPattern GetMovPattern();
}
