using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelParticleGeneration : MonoBehaviour
{
    //DATA
    [SerializeField] FuelParticle_WorldItem particlePrefab;
    [SerializeField] float particleRadius = 0.5f;
    [SerializeField] int particleAmount = 5;
    [SerializeField] Vector3 offset = Vector3.zero;

    [SerializeField] bool generatesParticlesOnStart = true;


    //METHODS
    //...
    private void Start()
    {
        if(generatesParticlesOnStart) CreateFuelParticles(particleAmount);
    }

    //FUNCTIONALITIES
    public void CreateFuelParticles() => CreateFuelParticles(particleAmount);

    private void CreateFuelParticles(int targetAmount)
    {
        Debug.Log("targetAmount: " + targetAmount);
        for(int i = 0; i < targetAmount; i++)
        {
            //RANDOMIZE IN CIRCLE AROUND COW
            Instantiate(
                particlePrefab, 
                this.transform.position + offset + UtilsRadius.RandomPositionOnCircleRadius(particleRadius), 
                Quaternion.identity
                );
        }
    }


    //DEBUGGING & TOOLING
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, particleRadius);
    }
#endif

}
