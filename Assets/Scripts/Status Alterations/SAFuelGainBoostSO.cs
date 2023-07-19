using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fuel Gain Boost", menuName = "Status Alterations/Fuel Gain Boost")]
public class SAFuelGainBoostSO : SAAbstractSO
{
    [SerializeField] public float buffDuration = 10.0f;
    [SerializeField] [Range(1.0f, 10.0f)] public float fuelGainMultiplier = 2.0f;

    public override SAAbstract GetBuff() => new SAFuelGainBoost(this);
}


