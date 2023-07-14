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

    private List<Hideout> GetAvailableHideouts(ScriptableHideout.Type type)
    {
        for (int i = 0; i < GetHideouts(type).Count; i++)
        {
            //ASK AN HIDEOUT IF IT IS AVAILABLE FOR HOSTING

        }
        return null;
    }
}
