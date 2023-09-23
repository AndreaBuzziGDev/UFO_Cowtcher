using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Freeze", menuName = "Status Alterations/Freeze")]
public class SAFreezeSO : SAAbstractSO
{
    [SerializeField] public float buffDuration = 3.0f;

    public override SAAbstract GetBuff() => new SAFreeze(this);
}