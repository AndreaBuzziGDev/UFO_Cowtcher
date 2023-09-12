using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelParticle_WorldItem : MonoBehaviour
{
    //DATA
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float particleMaxSpeed = 50.0f;

    private Camera cam;
    private UFO targetObject;

    private float timer;
    private float maxTimer = 1.0f;


    //METHODS
    //...
    private void Start()
    {
        cam = Camera.main;
        timer = 0;

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

        timer += Time.deltaTime;

        //TODO: VERTICAL ACCELERATION
        Vector3 intendedVelocity = Mathf.Lerp(0, particleMaxSpeed, EaseInQuad(timer / maxTimer)) * destination.normalized;
        Vector3 mitigatedVelocity = new Vector3(intendedVelocity.x, 0, intendedVelocity.z);

        rb.velocity = Vector3.Lerp(mitigatedVelocity, intendedVelocity, EaseInExpo(timer / maxTimer));
    }


    //COLLISIONS
    void OnTriggerEnter(Collider other)
    {
        //DETECT IF COLLISION IS UFO
        GameObject otherGO = other.gameObject;
        UFO playerUFO = otherGO.GetComponent<UFO>();
        if (playerUFO != null)
        {
            //TODO: PLAY PARTICLE EFFECT WHEN UFO IS HIT ?
            Destroy(this.gameObject);
        }
    }

    //EASING
    public static float EaseInQuad(float t) => t * t;

    public static float EaseInExpo(float t) => (float) Mathf.Pow(2, 10 * (t - 1));

}
