using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidShowerData : ScriptableObject
{
    //DATA

    [Range(0.1f, 5.0f)] public float TimeBetweenAsteroids = 0.5f;

    [Range(2.0f, 20.0f)] public float AsteroidStartingAltitude = 10.0f;

}
