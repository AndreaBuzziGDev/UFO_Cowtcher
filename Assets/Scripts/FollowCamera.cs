using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform TargetUFO;
    public Vector3 CameraOffset;
    public float UFOVerticalOffset;
    public float Damping = 1.0f;

    //HANDLING ZOOM
    private bool isZooming;
    [SerializeField] private float ZoomMultiplier = 1.5f;
    [SerializeField] private float TimerToMaxZoom = 1f;
    [SerializeField] private float TimerDeZoomMax = 1f;
    private float timerDeZoom;
    private float baseFOV;
    private Camera cameraComp;
    float refSpeed;



    private void Awake()
    {
        cameraComp = gameObject.GetComponent<Camera>();
        baseFOV = cameraComp.fieldOfView;
    }


    private void FixedUpdate()
    {
        //HANDLING FOLLOW UFO
        if (!TargetUFO)
        {
            return;
        }
        transform.position = Vector3.Lerp(transform.position, TargetUFO.position + CameraOffset, Time.deltaTime * Damping);
        transform.LookAt(TargetUFO.position - new Vector3(0, UFOVerticalOffset, 0), Vector3.up);

        //HANDLING ZOOM
        if (isZooming)
        {
            cameraComp.fieldOfView = Mathf.SmoothDamp(cameraComp.fieldOfView, baseFOV / ZoomMultiplier, ref refSpeed, TimerToMaxZoom);
            timerDeZoom = TimerDeZoomMax;
        }
        else
        {
            if(timerDeZoom > 0)
            {
                timerDeZoom -= Time.deltaTime;
            }
            else
            {
                cameraComp.fieldOfView = Mathf.SmoothDamp(cameraComp.fieldOfView, baseFOV, ref refSpeed, TimerToMaxZoom / 3);
            }
        }

    }

    public void SetIsZooming(bool zooming)
    {
        this.isZooming = zooming;
    }



}