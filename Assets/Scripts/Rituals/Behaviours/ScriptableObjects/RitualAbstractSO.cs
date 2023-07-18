using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Ritual", menuName = "Ritual")]
public abstract class RitualAbstractSO : ScriptableObject
{
    //DATA
    [SerializeField] private List<ScriptableCow.UniqueID> requiredCows = new List<ScriptableCow.UniqueID>();
    public List<ScriptableCow.UniqueID> RequiredCows { get { return requiredCows; } }


    [SerializeField] private ERitualType type = 0;
    public ERitualType Type { get { return type; } }


    public enum ERitualType
    {
        SimpleCapture,
        SequentialCapture,
        ItemProximity,
        ScoreThreshold
    }

}
