using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoSingleton<AsteroidManager>
{
    //DATA
    [SerializeField] private bool isAsteroidSystemActive = true;
    [SerializeField] private List<Asteroid> asteroidTypes = new();
    [SerializeField] [Range(2.0f, 20.0f)] private float asteroidStartingAltitude = 10.0f;

    [SerializeField] [Range(1.0f, 100.0f)] private float asteroidChanceMultiplier = 10.0f;
    private float asteroidTimer;
    private int asteroidPhaseMultiplier = 0;



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        //INITIALIZATION
        if (asteroidTypes.Count == 0)
        {
            Debug.LogError("AsteroidManager - NO ASTEROIDS SET!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(isAsteroidSystemActive) HandleTimer();
    }



    //INITIALIZATION



    //FUNCTIONALITIES
    private void HandleTimer()
    {
        if(asteroidTimer > 0)
        {
            asteroidTimer -= Time.deltaTime;
        }
        else
        {
            asteroidPhaseMultiplier++;
            float randomFloat = Random.Range(1, 100);

            //IF CHANCE PASSED, DO ASTEROID (EG: 1 x 10 = 10%)
            if (randomFloat <= asteroidPhaseMultiplier * asteroidChanceMultiplier)
            {
                //CHOOSE RANDOM ASTEROID
                int randomIndex = Random.Range(0, asteroidTypes.Count);

                //RELEASE ASTEROID
                ReleaseAsteroid(asteroidTypes[randomIndex]);

                //RESET CHANCE
                asteroidPhaseMultiplier = 0;

            }

            //RESET TIMER
            asteroidTimer = 1.0f;

        }
    }


    //UTILITIES
    public void ReleaseAsteroid(Asteroid interestedAsteroid)
    {
        // ASTEROID POSITION
        Vector3 nextAsteroidPosition = SpawningGrid.Instance.GetRandomPointInsideSpawnGrid();
        nextAsteroidPosition = new Vector3(nextAsteroidPosition.x, asteroidStartingAltitude, nextAsteroidPosition.z);

        //INSTANCIATE ASTEROID
        Asteroid asteroid = Instantiate(interestedAsteroid, nextAsteroidPosition, Quaternion.identity);

    }

}
