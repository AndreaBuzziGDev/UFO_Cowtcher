using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alert Cowctor", menuName = "MovementPattern/Alert/Cowctor Alert")]
public class MPCowctorAlertSO : MPAbstractAlertSO
{
    [SerializeField] public float timerSameDirectionMovement = 10.0f;
    [SerializeField] [Range(1, 9)] public float MinDirectionPersistenceSlider = 2.0f;

    MPCowctorAlert movPattern;

    public override AbstractMovementPattern GetMovPattern()
    {
        if (movPattern == null) movPattern = new MPCowctorAlert(this);
        return movPattern;
    }
}
