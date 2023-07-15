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

    [Tooltip("How many cows can be inside the hideout slot at the same time")]
    public int numberOfHideoutSlots = 1;

    [Tooltip("How long the slot must be inhabited before the cow can respawn")]
    public float HideoutPermanenceTimer = 5.0f;

    [Tooltip("If the UFO is within this radius, the permanence timer won't lower")]
    public float UFODetectionRadius = 3.0f;

    [Tooltip("The Cow-Hideout distance under which a cow can enter the hideout")]
    public float CowAllowedRadius = 3.0f;

}
