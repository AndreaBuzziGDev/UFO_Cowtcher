using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovementAlert : AbstractMovementPattern
{
    public abstract Vector3 ManagePanic(Cow myCow);

    public Vector3 GetFleeFromMap() => UtilsRadius.Vector3OnUnitCircle(1).normalized;


}
