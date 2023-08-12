using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoSingleton<AsteroidManager>
{
    //DATA
    ///ASTEROIDS WITH THEIR CONTENT
    [SerializeField] private List<AsteroidCollision> allAsteroids = new();
    private Dictionary<string, AsteroidCollision> asteroidDictionary = new();


    ///ASTEROID SHOWER
    private Queue<AsteroidCollision> queuedAsteroids = new();
    [SerializeField] private int asteroidShowerThreshold;
    public bool HasReachedThreshold { get { return queuedAsteroids.Count >= asteroidShowerThreshold; } }


    [SerializeField] private float asteroidShowerTimerMax = 5.0f;
    private float asteroidShowerTimer;
    public bool IsDoingAsteroidShower { get { return asteroidShowerTimer > 0.0f; } }




    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        
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



    public void AddAsteroid(List<AsteroidCollision> asteroids)
    {
        foreach (AsteroidCollision ac in asteroids) AddAsteroid(ac);
    }
    public void AddAsteroid(AsteroidCollision asteroid) => queuedAsteroids.Enqueue(asteroid);


    //
    private void UpdateAsteroidTimer()
    {
        if (IsDoingAsteroidShower)
        {
            asteroidShowerTimer -= Time.deltaTime;
        }
    }




}