using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelParticleGeneration : MonoBehaviour
{
    //DATA
    [SerializeField] FuelParticle_WorldItem particlePrefab;
    float particleRadius = 0.5f;



    //METHODS
    //...
    private void Start()
    {
        CreateFuelParticles(5);
    }

    //FUNCTIONALITIES
    public void CreateFuelParticles(int targetAmount)
    {
        for(int i = 0; i <= targetAmount; i++)
        {
            //RANDOMIZE IN CIRCLE AROUND COW
            Instantiate(
                particlePrefab, 
                this.transform.position + UtilsRadius.RandomPositionOnCircleRadius(particleRadius), 
                Quaternion.identity
                );
        }
    }


}
