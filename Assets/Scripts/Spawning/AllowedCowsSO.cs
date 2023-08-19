using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Allowed Cows List", menuName = "Allowed Cows List")]
public class AllowedCowsSO : ScriptableObject
{
    //DATA
    [SerializeField] private List<CowSO.UniqueID> allowedCowsUIDList = new();
    public List<CowSO.UniqueID> AllowedCowsUIDList { get { return allowedCowsUIDList; } }


}
