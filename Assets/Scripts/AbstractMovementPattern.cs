using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Movement Pattern", menuName = "Movement pattern")]
public abstract class AbstractMovementPattern : ScriptableObject
{

    public abstract Vector3 ManageMovement();

}
