using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    [SerializeField] GameObject Planet;
    [SerializeField] GameObject Shadow;
    [Range(0f, 1f)]
    public float rotation = 0f;

    private void Start()
    {

    }


    private void Update()
    {
        Planet.transform.Rotate(new Vector3(0, 0, rotation * Time.deltaTime));
        Shadow.transform.Rotate(new Vector3(0, 0, -rotation * Time.deltaTime));
    }
}
