using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBit : MonoBehaviour
{
    // if this entire script works, we only need to spawn it (maybe from the cow to easily use its fuelAmount as spawn number)
    // maybe with a very small delay between each spawn

    private Camera cam;
    [SerializeField] private float speed; // set to 0.1 in inspector just for testing, change later

    private Vector3 startingPosition;

    private RectTransform fuelBitTarget;
    private Vector3 fuelBitTargetLocation;

    private float interpolationTime;


    void Start()
    {
        cam = Camera.main;
        startingPosition = transform.position;

        fuelBitTarget = UIController.Instance.IGPanel.FuelBitTarget;
    }

    void Update()
    {
        // wanted to get the world position of the fuelBitTarget set in the IGPanel relative to the screen but I can't find a way to do it
        fuelBitTargetLocation = cam.ScreenToWorldPoint(fuelBitTarget.transform.position);
        fuelBitTargetLocation = new Vector3(fuelBitTargetLocation.x, fuelBitTargetLocation.y, GameController.Instance.FindUFOAnywhere().gameObject.transform.position.z);

        interpolationTime += Time.deltaTime;
        transform.position = Vector3.Lerp(startingPosition, fuelBitTargetLocation, interpolationTime * speed);

        if (transform.position == fuelBitTargetLocation) Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        // this is just to be able to see where the fuelBit goes towards
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(fuelBitTargetLocation, 1);
    }
}
