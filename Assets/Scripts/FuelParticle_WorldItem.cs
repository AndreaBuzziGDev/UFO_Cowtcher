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

        //TARGET UFO
        targetObject = GameController.Instance.FindUFOAnywhere();

        //TARGET FUEL BAR
        //targetObject = UIController.Instance.IGPanel.PlayerFuelBar;
    }

    // Update is called once per frame
    void Update()
    {
        //MOVE TOWARDS UFO
        Vector3 destination = targetObject.transform.position - this.transform.position;

        //MOVE TOWARDS FUEL BAR
        /*
        Vector3 destination = cam.ScreenToWorldPoint(targetObject.transform.position) - this.transform.position;
        Debug.Log("destination 1 - : " + targetObject.transform.position);
        Debug.Log("destination 2 - : " + cam.ScreenToWorldPoint(targetObject.transform.position));
        Debug.Log("destination 3 - : " + destination);
        */

        //TODO: ACCELERATE
        rb.velocity = particleSpeed * destination.normalized;

    }
}
