using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Capture Speed", menuName = "Status Alterations/Capture Speed")]
public class SACaptureSpeedSO : SAAbstractSO
{
    [SerializeField] public float buffDuration = 10.0f;
    [SerializeField] [Range(5.0f, 100.0f)] public float captureSpeedIntensity = 30.0f;//PERCENT
    [SerializeField] public bool isDebuff = false;

    public override SAAbstract GetBuff() => new SACaptureSpeed(this);
}
