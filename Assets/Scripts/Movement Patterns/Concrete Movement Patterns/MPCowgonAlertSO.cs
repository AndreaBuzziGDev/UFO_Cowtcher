using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Alert Cowgon", menuName = "MovementPattern/Calm/Cowgon Alert")]
public class MPCowgonAlertSO : MPAbstractAlertSO
{
    [SerializeField] public float timerToPlayerStun = 10.0f;
    [SerializeField] [Range(0.1f, 5.0f)] public float stunDuration = 1.0f;

    MPCowgonAlert movPattern;

    public override AbstractMovementPattern GetMovPattern()
    {
        if (movPattern == null) movPattern = new MPCowgonAlert(this);
        return movPattern;
    }
}