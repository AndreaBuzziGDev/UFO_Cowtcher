using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCow : MonoBehaviour
{
    //DATA

    [SerializeField] private FakeUFO myUFO;
    [SerializeField] private float mySpeed = 5.0f;

    private Rigidbody myRB;


    //DIRECTION
    private Vector3 myDirection;

    //ROTATION FOR THAT DIRECTION
    public float myDirectionRotation;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 ufoPos = myUFO.transform.position;
        Vector3 ufoProjectedPos = new(ufoPos.x, 0, ufoPos.z);

        myDirection = this.transform.position - ufoProjectedPos;

        myRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //TODO: ROTATE BY myDirectionRotation
        Vector3 intendedDirection = mySpeed * myDirection;
        Debug.Log("FakeCow - intendedDirection: " + intendedDirection);

        //TODO: ROTATE BY myDirectionRotation
        Vector3 newIntendedDirection = Quaternion.AngleAxis(myDirectionRotation, Vector3.up) * intendedDirection;
        Debug.Log("FakeCow - newIntendedDirection: " + newIntendedDirection);

        //TODO: CHANGE myDirection TO newIntendedDirection
        myRB.velocity = mySpeed * newIntendedDirection;
    }
}
