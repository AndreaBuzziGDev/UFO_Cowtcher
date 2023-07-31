using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//TODO: EVALUATE USING MONOSINGLETON
public class SpawningGrid : MonoSingleton<SpawningGrid>
{
    //DATA
    private List<SpawningCorner> boundaries = new();
    private SpawningCorner southWest;
    private SpawningCorner northEast;



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        //TAKES THE CHILDREN "SpawningCorner"
        boundaries = GetComponentsInChildren<SpawningCorner>().ToList();

        //CONVENTION: TAKES THE SOUTH WEST AND NORTH EAST DUO
        ///SOUTH WEST
        //TODO: MOVE INTO A DEDICATED METHOD
        foreach(SpawningCorner sc in boundaries)
        {
            if(southWest != null)
            {
                if(sc.transform.position.x < southWest.transform.position.x)
                {
                    if (sc.transform.position.z < southWest.transform.position.z)
                    {
                        southWest = sc;
                    }
                }
            }
            else
            {
                southWest = sc;
            }
        }

        ///NORTH EAST
        foreach (SpawningCorner sc in boundaries)
        {
            if (northEast != null)
            {
                if (sc.transform.position.x > northEast.transform.position.x)
                {
                    if (sc.transform.position.z > northEast.transform.position.z)
                    {
                        northEast = sc;
                    }
                }
            }
            else
            {
                northEast = sc;
            }
        }

        Debug.Log("SpawningGrid - southWest: " + southWest.transform.position);
        Debug.Log("SpawningGrid - northEast: " + northEast.transform.position);

    }


    //FUNCTIONALITIES
    public Vector3 GetRandomPointInsideSpawnGrid()
    {
        int randomX = (int)Random.Range(southWest.transform.position.x, northEast.transform.position.x);
        int randomZ = (int)Random.Range(southWest.transform.position.z, northEast.transform.position.z);

        Debug.Log("SpawningGrid - randomX: " + randomX);
        Debug.Log("SpawningGrid - randomZ: " + randomZ);


        return new Vector3(randomX, 0, randomZ);
    }


    public void SpawnCowInsideGrid(Cow interestedCow)
    {
        interestedCow.transform.position = GetRandomPointInsideSpawnGrid();
        interestedCow.gameObject.SetActive(true);
    }

    public static void SpawnCowAtZero(Cow interestedCow)
    {
        //FALLBACK: SPAWN AT zero
        interestedCow.transform.position = Vector3.zero;
        interestedCow.gameObject.SetActive(true);
    }

    //SPAWN OBJECTS INTERACTION

}
