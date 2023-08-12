using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidShower : MonoBehaviour
{
    //DATA
    ///TEMPLATE
    [SerializeField] private AsteroidShowerData template;


    ///SHOWER DATA
    private float timeBetweenAsteroids;
    public bool IsBetweenAsteroids { get { return timeBetweenAsteroids > 0; } }


    ///QUEUED ASTEROIDS
    private Queue<Asteroid> queuedAsteroids = new();



    //METHODS
    //...

    // Update is called once per frame
    void Update()
    {
        UpdateAsteroidTimer();

        if(!IsBetweenAsteroids) DeployNextAsteroid();
    }



    //FUNCTIONALITIES
    ///
    public void SetAsteroidQueue(Queue<Asteroid> asteroids)
    {
        queuedAsteroids = asteroids;
    }
    
    
    ///
    private void UpdateAsteroidTimer()
    {
        if(IsBetweenAsteroids)
        {
            timeBetweenAsteroids -= Time.deltaTime;
        }
    }

    ///
    public void DeployNextAsteroid()
    {
        //CHECK IF THE QUEUE STILL HAS ASTEROIDS
        if(queuedAsteroids.Count > 0)
        {
            Debug.Log("Asteroid Shower Has: " + queuedAsteroids.Count + " more asteroids to go");

            //ASTEROID POSITION
            Vector3 nextAsteroidPosition = SpawningGrid.Instance.GetRandomPointInsideSpawnGrid();
            nextAsteroidPosition = new Vector3(nextAsteroidPosition.x, template.AsteroidStartingAltitude, nextAsteroidPosition.z);

            //INSTANCIATE ASTEROID
            Asteroid asteroid = Instantiate(queuedAsteroids.Dequeue(), nextAsteroidPosition, Quaternion.identity);

            //TODO: IMPLEMENT


            //RESET TIMER
            timeBetweenAsteroids = template.TimeBetweenAsteroids;

        }
        else
        {
            Debug.Log("Asteroid Shower ended");
            Destroy(this.gameObject);
        }


    }

}
