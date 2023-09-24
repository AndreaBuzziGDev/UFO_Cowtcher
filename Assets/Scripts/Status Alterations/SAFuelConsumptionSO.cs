using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fuel Consumption", menuName = "Status Alterations/Fuel Consumption")]
public class SAFuelConsumptionSO : SAAbstractSO
{
    [SerializeField] public float buffDuration = 10.0f;
    [SerializeField] [Range(0,100)] public float consumptionIncrease = 20.0f;

    public override SAAbstract GetBuff() => new SAFuelConsumption(this);
}