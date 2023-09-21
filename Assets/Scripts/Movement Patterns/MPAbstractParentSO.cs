using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MPAbstractParentSO : ScriptableObject, IMovementPattern
{
    //DATA
    [SerializeField] public bool jumps = false;
    [SerializeField] public float jumpHeight = 0.5f;
    [SerializeField] [Range(1.0f, 5.0f)] public float jumpSpeed = 1f;

    //METHODS
    public abstract AbstractMovementPattern GetMovPattern();

}
