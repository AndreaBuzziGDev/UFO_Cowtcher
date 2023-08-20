using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoSingleton<AsteroidManager>
{
    //DATA
    [SerializeField] private List<Asteroid> asteroidTypes = new();
    [SerializeField] [Range(2.0f, 20.0f)] private float asteroidStartingAltitude = 10.0f;

    private float asteroidTimer;
    private int asteroidChanceMultiplier = 0;








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
        HandleTimer();

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
            asteroidChanceMultiplier++;
            int randomInt = Random.Range(1, 10);

            //IF CHANCE PASSED, DO ASTEROID
            if (randomInt <= asteroidChanceMultiplier)
            {
                //CHOOSE RANDOM ASTEROID
                int randomIndex = Random.Range(0, asteroidTypes.Count-1);

                //RELEASE ASTEROID
                ReleaseAsteroid(asteroidTypes[randomIndex]);

                //RESET CHANCE
                asteroidChanceMultiplier = 0;

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
