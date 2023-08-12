using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoSingleton<AsteroidManager>
{
    //DATA
    ///ASTEROIDS WITH THEIR CONTENT
    [SerializeField] private List<AsteroidCollision> allAsteroids = new();
    private Dictionary<string, AsteroidCollision> asteroidDictionary = new();




    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //INITIALIZATION
    ///INIZIALIZE ASTEROID DICTIONARY




    //FUNCTIONALITIES
    public void DoAsteroidShower()
    {
        //BUILD AN ASTEROID SHOWER


        //ENQUEUE ASTEROID SHOWER


    }

}
