using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoSingleton<AsteroidManager>
{
    //DATA

    ///ASTEROID SHOWER
    [SerializeField] private AsteroidShower shower;

    ///ASTEROID SHOWER TIMER
    [SerializeField] private float asteroidShowerCooldown = 5.0f;
    private float asteroidShowerTimer;
    public bool IsDoingAsteroidShower { get { return asteroidShowerTimer > 0.0f; } }



    ///ASTEROID QUEUE
    private Queue<Asteroid> queuedAsteroids = new();
    [SerializeField] private int asteroidShowerThreshold = 5;
    public bool HasReachedThreshold { get { return queuedAsteroids.Count >= asteroidShowerThreshold; } }



    ///TESTING
    [SerializeField] private bool enableAsteroidTest;
    [SerializeField] private Asteroid testAsteroidPrefab;
    [SerializeField] private float testAsteroidCooldown = 1.0f;
    private float testAsteroidTimer;





    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        //INITIALIZATION
        if (shower == null)
        {
            Debug.LogError("NO ASTEROID SHOWER PREFAB SET!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //MANUAL TEST DONE TO VERIFY FUNCTIONALITY OF THE TEST
        if(enableAsteroidTest) TestFeature();


        //ASTEROID SHOWER
        if (HasReachedThreshold && !IsDoingAsteroidShower)
        {
            DoAsteroidShower();
        }

        //UPDATE INNER TIMER
        UpdateAsteroidTimer();
    }



    //INITIALIZATION
    ///INIZIALIZE ASTEROID DICTIONARY




    ///FOR TESTING
    private void TestFeature()
    {
        if(testAsteroidTimer <= 0)
        {
            EnqueueAsteroid(testAsteroidPrefab);
            testAsteroidTimer = testAsteroidCooldown;
        }
        else
        {
            testAsteroidTimer -= Time.deltaTime;
        }
    }







    //FUNCTIONALITIES
    ///ASTEROID SHOWER
    public void DoAsteroidShower()
    {
        //BUILD AN ASTEROID SHOWER
        GameObject instance = Instantiate(shower.gameObject, new Vector3(0, 0, 0), Quaternion.identity);

        //ENQUEUE ASTEROID SHOWER
        Queue<Asteroid> tempQueue = new();

        //TODO: CAN THIS BE SIMPLIFIED?
        for(int i = 0; i < asteroidShowerThreshold; i++) tempQueue.Enqueue(queuedAsteroids.Dequeue());
        instance.GetComponent<AsteroidShower>().SetAsteroidQueue(tempQueue);

        //RESET ASTEROID SHOWER TIMER
        asteroidShowerTimer = asteroidShowerCooldown;

    }



    ///ASTEROID ADDITION TO QUEUE
    public void EnqueueAsteroid(Asteroid asteroid, int copies)
    {
        Debug.Log("AsteroidManager - Enqueueing " + copies + " asteroids " + asteroid.name);
        for(int i=0; i<copies; i++) EnqueueAsteroid(asteroid);
    }

    public void EnqueueAsteroid(List<Asteroid> asteroids)
    {
        foreach (Asteroid ac in asteroids) EnqueueAsteroid(ac);
    }
    public void EnqueueAsteroid(Asteroid asteroid) => queuedAsteroids.Enqueue(asteroid);


    //
    private void UpdateAsteroidTimer()
    {
        if (IsDoingAsteroidShower)
        {
            asteroidShowerTimer -= Time.deltaTime;
        }
    }




}
