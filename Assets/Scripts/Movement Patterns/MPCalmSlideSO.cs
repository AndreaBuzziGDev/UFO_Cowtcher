using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Calm Slide", menuName = "MovementPattern/Calm/Slide")]
public class MPCalmSlideSO : MPAbstractCalmSO
{
    public override AbstractMovementPattern GetMovPattern()
    {
        return new MPCalmSlide(this);
    }
}
