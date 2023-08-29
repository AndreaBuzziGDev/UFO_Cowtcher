using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Capture Radius", menuName = "Status Alterations/Capture Radius")]
public class SACaptureRadiusSO : SAAbstractSO
{
    [SerializeField] public float buffDuration = 10.0f;
    [SerializeField] [Range(5.0f, 100.0f)] public float captureRadiusIncrease = 20.0f;//PERCENT
    [SerializeField] public bool isDebuff = false;

    public override SAAbstract GetBuff() => new SACaptureRadius(this);
}
