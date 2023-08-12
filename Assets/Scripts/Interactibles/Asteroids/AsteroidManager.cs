using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoSingleton<AsteroidManager>
{
    //DATA
    ///ASTEROIDS WITH THEIR CONTENT
    ///NB: UNUSED AND NEEDS TO BE POLISHED TO WORK
    [SerializeField] private List<AsteroidCollision> allAsteroids = new();
    private Dictionary<string, AsteroidCollision> asteroidDictionary = new();


    ///ASTEROID SHOWER ITSELF
    [SerializeField] private AsteroidShower shower;


    ///ASTEROID QUEUE
    private Queue<AsteroidCollision> queuedAsteroids = new();
    [SerializeField] private int asteroidShowerThreshold = 5;
    public bool HasReachedThreshold { get { return queuedAsteroids.Count >= asteroidShowerThreshold; } }


    ///ASTEROID SHOWER TIMER
    [SerializeField] private float asteroidShowerCooldown = 5.0f;
    private float asteroidShowerTimer;
    public bool IsDoingAsteroidShower { get { return asteroidShowerTimer > 0.0f; } }


    ///TESTING
    [SerializeField] private bool enableAsteroidTest;
    [SerializeField] private AsteroidCollision testAsteroidPrefab;
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
    public void DoAsteroidShower()
    {
        //BUILD AN ASTEROID SHOWER
        GameObject instance = Instantiate(shower.gameObject, new Vector3(0, 0, 0), Quaternion.identity);

        //ENQUEUE ASTEROID SHOWER
        Queue<AsteroidCollision> tempQueue = new();

        //TODO: CAN THIS BE SIMPLIFIED?
        for(int i = 0; i < asteroidShowerThreshold; i++) tempQueue.Enqueue(queuedAsteroids.Dequeue());
        instance.GetComponent<AsteroidShower>().SetAsteroidQueue(tempQueue);

        //RESET ASTEROID SHOWER TIMER
        asteroidShowerTimer = asteroidShowerCooldown;

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
