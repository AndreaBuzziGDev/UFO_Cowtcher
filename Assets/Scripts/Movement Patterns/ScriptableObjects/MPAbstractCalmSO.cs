using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MPAbstractCalmSO : ScriptableObject, IMovementPattern
{
    public abstract AbstractMovementPattern GetMovPattern();

}
