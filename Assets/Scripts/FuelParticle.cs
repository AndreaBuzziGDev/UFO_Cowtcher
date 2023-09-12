using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelParticle : MonoBehaviour
{
    //DATA
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float particleSpeed = 5.0f;

    private GameObject targetObject;
    private Vector3 destination;


    //METHODS
    //...
    private void Start()
    {
        targetObject = UIController.Instance.IGPanel.PlayerFuelBar.gameObject;
        destination = targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //MOVE TOWARDS FUEL BAR
        rb.velocity = particleSpeed * destination.normalized;
    }
}
