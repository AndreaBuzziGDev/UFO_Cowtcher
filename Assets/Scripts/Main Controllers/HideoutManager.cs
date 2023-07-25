using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HideoutManager : MonoSingleton<HideoutManager>
{
    //DATA
    private List<Hideout> allHideouts = new();
    private Dictionary<HideoutSO.Type, List<Hideout>> hideoutsByType = new();

    //METHODS
    // Start is called before the first frame update

    //TODO: STUDY AND APPLY THE SAME CHANGES TO THE Awake METHOD MADE TO GameController IN THIS MONOSINGLETON AS WELL

    void Start()
    {
        //...

    }

    // Update is called once per frame
    void Update()
    {
        //...

    }





    //INITIALIZATION

    ///OVERALL INITIALIZATION PROCEDURE
    public void Initialization()
    {
        initializeAllHideouts();
        MakeDictionary();

        //TODO: INTRODUCE DEBUGGING FUNCTIONALITIES (FIND DUPLICATES ETC)

    }

    ///MAIN INITIALIZATION
    private void initializeAllHideouts()
    {
        allHideouts = FindObjectsOfType<Hideout>().ToList();
        Debug.Log("allHideouts size: " + allHideouts.Count);
    }

    ///HIDEOUTS INITIALIZATION
    private void MakeDictionary()
    {
        if (allHideouts != null)
        {
            foreach(Hideout cycledHideout in allHideouts)
            {
                if (!hideoutsByType.ContainsKey(cycledHideout.Type))
                {
                    hideoutsByType.Add(cycledHideout.Type, new List<Hideout> { cycledHideout });
                }
                else
                {
                    hideoutsByType[cycledHideout.Type].Add(cycledHideout);
                }
            }
        }

    }






    //FUNCTIONALITIES
    ///DATA RETRIEVAL
    ///
    ///RETRIEVE ANY Hideout
    private List<Hideout> GetHideouts(HideoutSO.Type type)
    {
        if (hideoutsByType.ContainsKey(type)) 
            return hideoutsByType[type];
        else 
            return null;
    }

    ///RETRIEVE HIDEOUTS THAT HAVE AVAILABLE SLOTS
    public List<Hideout> GetAvailableHideouts(HideoutSO.Type type)
    {
        List<Hideout> availableHideouts = new List<Hideout>();

        foreach (Hideout cycledHideout in GetHideouts(type))
        {
            //ASK AN HIDEOUT IF IT IS AVAILABLE FOR HOSTING
            foreach (HideoutSlot hsl in cycledHideout.HideoutSlots)
            {
                if (!hsl.IsHosting) availableHideouts.Add(cycledHideout);
            }
        }
        return availableHideouts;
    }
}
