using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBit : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float speed;

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
        fuelBitTargetLocation = cam.ScreenToWorldPoint(fuelBitTarget.pivot);
        fuelBitTargetLocation = new Vector3(fuelBitTargetLocation.x, fuelBitTargetLocation.y, GameController.Instance.FindUFOAnywhere().gameObject.transform.position.z);

        interpolationTime += Time.deltaTime;
        transform.position = Vector3.Lerp(startingPosition, fuelBitTargetLocation, interpolationTime * speed);

        if (transform.position == fuelBitTargetLocation) Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(fuelBitTargetLocation, 1);
    }
}
