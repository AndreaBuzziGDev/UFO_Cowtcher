using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{

    [SerializeField] GameObject Planet;
    [SerializeField] GameObject Shadow;
    [SerializeField] GameObject Accessory;
    [SerializeField] GameObject AccessoryRetro;
    [Range(0f, 100f)]
    public float rotation = 0f;
    private Quaternion initialRotation;
    private int spin = 1;
    private int a = 1;
    private string tmp;
    Color c = new Color(255, 255, 255, 255);

    private void Start()
    {
        initialRotation = Accessory.transform.localRotation;
        tmp = Accessory.GetComponent<Image>().sprite.name;
    }


    private void Update()
    {
        if (Accessory.GetComponent<Image>().sprite.name != tmp)
        {
            tmp = Accessory.GetComponent<Image>().sprite.name;
            Accessory.transform.localRotation = initialRotation;
        }

        Planet.transform.Rotate(new Vector3(0, 0, rotation * Time.deltaTime));
        Shadow.transform.Rotate(new Vector3(0, 0, -rotation * Time.deltaTime));
        

        if (Accessory.GetComponent<Image>().sprite.name == "Moon_0")
        {
            Accessory.transform.Rotate(new Vector3(0, 0, -rotation / 4 * Time.deltaTime));
        }
        else if (AccessoryRetro.GetComponent<Image>().sprite.name == "Portal_0")
        {
            AccessoryRetro.transform.Rotate(new Vector3(0, 0, -rotation / 2 * Time.deltaTime));
        }
        else if (Accessory.GetComponent<Image>().sprite.name == "Halo_0")
        {
            

            if (Accessory.transform.rotation.z > 0)
            {
                spin = -1;
            }
            
            else if(Accessory.transform.rotation.z < -0.05)
            {
                spin = 1;
            }

            Accessory.transform.Rotate(new Vector3(0, 0, spin * rotation/6 * Time.deltaTime));

        }

    }
}
