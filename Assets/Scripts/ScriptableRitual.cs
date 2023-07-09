using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ritual", menuName = "Ritual")]
public class ScriptableRitual : ScriptableObject
{
    //DATA
    List<ScriptableCow.UniqueID> RequiredCows = new List<ScriptableCow.UniqueID>();

}
