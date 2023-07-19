using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Instant Percent Fuel Loss", menuName = "Status Alterations/Instant Percent Fuel Loss")]
public class SAFuelLossInstantSO : SAAbstractSO
{
    [SerializeField] [Range(1.0f, 90.0f)] public float currentFuelPercentLoss = 10.0f;//PERCENT

    public override SAAbstract GetBuff()
    {
        SAAbstract result = new SAFuelLossInstant(this);
        return result;
    }

}
