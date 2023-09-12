using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelParticle_WorldItem : MonoBehaviour
{
    //DATA
    private Camera cam;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float particleSpeed = 5.0f;

    private UFO targetObject;
    private Vector3 destination;


    //METHODS
    //...
    private void Start()
    {
        cam = Camera.main;
        targetObject = GameController.Instance.FindUFOAnywhere();
        destination = targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //MOVE TOWARDS UFO
        //TODO: ACCELERATE
        rb.velocity = particleSpeed * destination.normalized;

    }
}
