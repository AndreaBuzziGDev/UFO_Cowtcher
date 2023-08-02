using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningCorner : MonoBehaviour
{
    //DATA



    //METHODS
    public float getWeight()
    {
        Vector3 position = transform.position;
        return position.x + position.z;
    }

}
