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

    public List<Hideout> GetAvailableHideouts(ScriptableHideout.Type type)
    {
        List<Hideout> availableHideouts = new List<Hideout>();
        List<HideoutSlot> tempHideoutSlots = new List<HideoutSlot>();

        for (int i = 0; i < GetHideouts(type).Count; i++)
        {
            //ASK AN HIDEOUT IF IT IS AVAILABLE FOR HOSTING
            tempHideoutSlots = GetHideouts(type)[i].HideoutSlots;

            for (int j = 0; j < tempHideoutSlots.Count; j++)
            {
                if (tempHideoutSlots[i].HostedCow == null)
                    availableHideouts.Add(GetHideouts(type)[i]);
                else 
                    continue;
            }

            Debug.Log("Avaliable hideouts: " + availableHideouts[i].ToString());
        }
        return availableHideouts;
    }
}
