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
    [SerializeField] private AsteroidShower shower;

    ///ASTEROID QUEUE
    private Queue<AsteroidCollision> queuedAsteroids = new();
    [SerializeField] private int asteroidShowerThreshold = 5;
    public bool HasReachedThreshold { get { return queuedAsteroids.Count >= asteroidShowerThreshold; } }

    ///ASTEROID SHOWER TIMER
    [SerializeField] private float asteroidShowerCooldown = 5.0f;
    private float asteroidShowerTimer;
    public bool IsDoingAsteroidShower { get { return asteroidShowerTimer > 0.0f; } }




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
