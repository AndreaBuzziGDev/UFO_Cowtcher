using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelParticle_WorldItem : MonoBehaviour
{
    //DATA
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float particleSpeed = 5.0f;

    private Camera cam;
    private UFO targetObject;


    //METHODS
    //...
    private void Start()
    {
        cam = Camera.main;
        targetObject = GameController.Instance.FindUFOAnywhere();
    }

    // Update is called once per frame
    void Update()
    {
        //MOVE TOWARDS UFO
        Vector3 destination = targetObject.transform.position - this.transform.position;
        Debug.Log("destination: " + destination);

        //TODO: ACCELERATE
        rb.velocity = particleSpeed * destination.normalized;

    }
}
