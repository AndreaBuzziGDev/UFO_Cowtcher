using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilsRadius
{

    public static Vector3 RandomPositionOnCircleRadius(float radius)
    {
        var angle = Random.value * (2f * Mathf.PI);
        var direction = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle));
        return direction * radius;
    }

}
