using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform TargetUFO;
    public Vector3 CameraOffset;
    public float UFOVerticalOffset;
    public float Damping = 1.0f;

    private void Update()
    {
        if (!TargetUFO)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, TargetUFO.position + CameraOffset, Time.deltaTime * Damping);

        transform.LookAt(TargetUFO.position - new Vector3(0, UFOVerticalOffset, 0), Vector3.up);
    }
}