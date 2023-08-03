using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CowManager : MonoSingleton<CowManager>
{
    //DATA
    private List<Cow> allCows = new();


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


    //FUNCTIONALITIES
    public List<Cow> getAllCows()
    {
        List<Cow> currentCows = FindObjectsOfType<Cow>().ToList();
        Debug.Log("Current Cows on Map: " + currentCows.Count);

        return currentCows;
        //return allCows;
    }


}
