using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Status Alteration", menuName = "Status Alteration")]
public abstract class SAAbstractSO : ScriptableObject
{
    [SerializeField] public SAAbstract.EBuffType buffType;
    [SerializeField] public bool LastsIndefinitely = false;


    public abstract SAAbstract GetBuff();

}
