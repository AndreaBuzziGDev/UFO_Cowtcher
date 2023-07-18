using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SASpeedBoostSO : SAAbstractSO
{
    [SerializeField] public float buffDuration = 10.0f;
    [SerializeField] [Range(5.0f, 200.0f)] public float speedBoostIntensity = 10.0f;//PERCENT

    public override SAAbstract GetBuff() => new SASpeedBoost(this);
}
