using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelParticle : MonoBehaviour
{
    //DATA
    private Camera cam;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float particleSpeed = 5.0f;

    private GameObject targetObject;//TODO: TRY RECT TRANSFORM
    private Vector3 destination;


    //METHODS
    //...
    private void Start()
    {
        cam = Camera.main;
        targetObject = UIController.Instance.IGPanel.PlayerFuelBar.gameObject;
        destination = targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //MOVE TOWARDS FUEL BAR
        rb.velocity = particleSpeed * destination.normalized;
        */
        Vector3 fuelBitTargetLocation = cam.WorldToViewportPoint(targetObject.transform.position);
        rb.velocity = particleSpeed * fuelBitTargetLocation.normalized;

    }
}
