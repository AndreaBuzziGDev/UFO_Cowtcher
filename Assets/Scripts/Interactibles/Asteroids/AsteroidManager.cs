using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoSingleton<AsteroidManager>
{
    //DATA
    ///ASTEROIDS WITH THEIR CONTENT
    [SerializeField] private List<AsteroidCollision> allAsteroids = new();
    private Dictionary<string, AsteroidCollision> asteroidDictionary = new();


    ///ASTEROID SHOWER ITSELF
    private Queue<AsteroidCollision> queuedAsteroids = new();
    [SerializeField] private int asteroidShowerThreshold = 5;
    public bool HasReachedThreshold { get { return queuedAsteroids.Count >= asteroidShowerThreshold; } }

    ///ASTEROID SHOWER TIMER
    [SerializeField] private float asteroidShowerTimerMax = 5.0f;
    private float asteroidShowerTimer;
    public bool IsDoingAsteroidShower { get { return asteroidShowerTimer > 0.0f; } }




    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        //INITIALIZATION


    }

    // Update is called once per frame
    void Update()
    {
        if (HasReachedThreshold && !IsDoingAsteroidShower)
        {
            //DO ASTEROID SHOWER
            DoAsteroidShower();
        }

        UpdateAsteroidTimer();
    }



    //INITIALIZATION
    ///INIZIALIZE ASTEROID DICTIONARY




    //FUNCTIONALITIES
    public void DoAsteroidShower()
    {
        //BUILD AN ASTEROID SHOWER


        //ENQUEUE ASTEROID SHOWER


        //RESET ASTEROID SHOWER TIMER
        asteroidShowerTimer = asteroidShowerTimerMax;

    }



    public void EnqueueAsteroid(List<AsteroidCollision> asteroids)
    {
        foreach (AsteroidCollision ac in asteroids) EnqueueAsteroid(ac);
    }
    public void EnqueueAsteroid(AsteroidCollision asteroid) => queuedAsteroids.Enqueue(asteroid);


    //
    private void UpdateAsteroidTimer()
    {
        if (IsDoingAsteroidShower)
        {
            asteroidShowerTimer -= Time.deltaTime;
        }
    }




}
