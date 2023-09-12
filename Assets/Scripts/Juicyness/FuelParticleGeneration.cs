using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelParticleGeneration : MonoBehaviour
{
    //DATA
    [SerializeField] FuelParticle_WorldItem particlePrefab;



    //METHODS
    //...

    public void CreateFuelParticles(int targetAmount)
    {
        for(int i = 0; i <= targetAmount; i++)
        {
            Instantiate(particlePrefab);
        }
    }


}
