using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HideoutManager : MonoSingleton<HideoutManager>
{
    //DATA
    private List<Hideout> allHideouts = new();
    private Dictionary<ScriptableHideout.Type, List<Hideout>> hideoutsByType = new();

    //METHODS
    // Start is called before the first frame update

    //TODO: STUDY AND APPLY THE SAME CHANGES TO THE Awake METHOD MADE TO GameController IN THIS MONOSINGLETON AS WELL

    void Start()
    {
        initializeAllHidelouts();
        MakeDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void initializeAllHidelouts()
    {
        allHideouts = FindObjectsOfType<Hideout>().ToList();
        Debug.Log("allHideouts size: " + allHideouts.Count);
    }

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
    private List<Hideout> GetHideouts(ScriptableHideout.Type type)
    {
        if (hideoutsByType.ContainsKey(type)) 
            return hideoutsByType[type];
        else 
            return null;
    }

    public List<Hideout> GetAvailableHideouts(ScriptableHideout.Type type)
    {
        List<Hideout> availableHideouts = new List<Hideout>();

        foreach (Hideout cycledHideout in GetHideouts(type))
        {
            //ASK AN HIDEOUT IF IT IS AVAILABLE FOR HOSTING
            foreach (HideoutSlot hsl in cycledHideout.HideoutSlots)
            {
                if (!hsl.IsHosting) availableHideouts.Add(cycledHideout);
            }

            Debug.Log("Hideout: " + cycledHideout.Type + " avaliable hideouts: " + cycledHideout.ToString());
        }
        return availableHideouts;
    }
}
