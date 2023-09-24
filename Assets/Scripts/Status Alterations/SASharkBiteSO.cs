using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shark Bite", menuName = "Status Alterations/Shark Bite")]
public class SASharkBiteSO : SAAbstractSO
{
    [SerializeField] [Range (0, 100)] public float currentScoreLoss = 20.0f;

    public override SAAbstract GetBuff() => new SASharkBite(this);
}
