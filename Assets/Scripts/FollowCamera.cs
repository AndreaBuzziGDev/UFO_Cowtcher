using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform TargetUFO;
    public Vector3 CameraOffset;
    public float UFOVerticalOffset;
    public float Damping = 1.0f;


    public Transform parentObject;
    public float zoomLevel;
    public float maxZoom;

    //HANDLING ZOOM
    [SerializeField] private float ZoomMultiplier = 2;
    private float baseFOV;
    private Camera cameraComp;



    private void Awake()
    {
        cameraComp = gameObject.GetComponent<Camera>();
        baseFOV = cameraComp.fieldOfView;
    }


    private void FixedUpdate()
    {
        if (!TargetUFO)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, TargetUFO.position + CameraOffset, Time.deltaTime * Damping);

        transform.LookAt(TargetUFO.position - new Vector3(0, UFOVerticalOffset, 0), Vector3.up);

        //sets zoom in with float value
        /*
        //if()
        //{
            transform.position = parentObject.position + (transform.forward * zoomLevel);
            zoomLevel = Mathf.Clamp(zoomLevel, 0, maxZoom);
        //}
        */
    }

    public void HandleZoom(bool zooming)
    {
        if (zooming)
        {
            cameraComp.fieldOfView = baseFOV / ZoomMultiplier;
        }
        else
        {
            cameraComp.fieldOfView = baseFOV;
        }
    }



}