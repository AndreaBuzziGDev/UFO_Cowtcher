using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hideout", menuName = "Hideout")]
public class ScriptableHideout : ScriptableObject
{
    //ENUMS
    public enum Type
    {
        Barn,
        Rock,
        Garage
    }

    //DATA
    public Type type = 0;
    public int numberOfHideoutSlots = 1;
    public float HideoutPermanenceTimer = 5.0f;
    public float UFODetectionRadius = 3.0f;
}
