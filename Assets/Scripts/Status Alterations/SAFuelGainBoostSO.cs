using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fuel Gain Boost", menuName = "Status Alterations/Fuel Gain Boost")]
public class SAFuelGainBoostSO : SAAbstractSO
{
    [SerializeField] public float buffDuration = 10.0f;
    [SerializeField] [Range(0.10f, 4.0f)] public float additionalFuelGainPercent = 1.0f;//ADDITIONAL BONUS (+1 = +100% = DOUBLE THE AMOUNT)

    public override SAAbstract GetBuff() => new SAFuelGainBoost(this);
}


