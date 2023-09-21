using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Legendary Alert", menuName = "MovementPattern/Alert/Legendary Alert")]
public class MPLegendaryAlertSO : MPAbstractAlertSO
{
    [SerializeField] public float timerToPlayerStun = 10.0f;
    [SerializeField] [Range(0.1f, 5.0f)] public float stunDuration = 1.0f;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPLegendaryAlert(this);
    }
}