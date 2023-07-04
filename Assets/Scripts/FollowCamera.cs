using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform TargetUFO;
    public Vector3 Offset;
    public float Damping = 1.0f;

    private void Update()
    {
        if (!TargetUFO)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, TargetUFO.position + Offset, Time.deltaTime * Damping);

        transform.LookAt(TargetUFO, Vector3.up);
    }
}