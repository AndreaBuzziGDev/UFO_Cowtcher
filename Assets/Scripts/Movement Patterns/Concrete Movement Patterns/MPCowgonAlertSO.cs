using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Alert Cowgon", menuName = "MovementPattern/Alert/Cowgon Alert")]
public class MPCowgonAlertSO : MPAbstractAlertSO
{
    [SerializeField] public float timerToPlayerStun = 10.0f;
    [SerializeField] [Range(0.1f, 5.0f)] public float stunDuration = 1.0f;

    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPCowgonAlert(this);
    }
}