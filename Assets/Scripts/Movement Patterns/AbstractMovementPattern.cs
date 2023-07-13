using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovementPattern : ScriptableObject
{
    public abstract Vector3 ManageMovement(Vector3 cowPosition);

}
