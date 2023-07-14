using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideoutManager : MonoSingleton<HideoutManager>
{
    //DATA
    private List<Hideout> allHideouts = new();
    private Dictionary<ScriptableHideout.Type, List<Hideout>> hideoutsByType = new();

    //METHODS
    //...
    public override void Awake()
    {
        base.Awake();
        SetHideoutArrayToList();
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetHideoutArrayToList()
    {
        Hideout[] array = FindObjectsOfType<Hideout>();
        for (int i = 0; i < array.Length; i++)
        {
            allHideouts.Add(array[i]);
        }
    }

    private void MakeDictionary()
    {
        if (allHideouts != null)
        {
            for (int i = 0; i < allHideouts.Count; i++)
            {
                if (!hideoutsByType.ContainsKey(allHideouts[i].Type))
                {
                    hideoutsByType.Add(allHideouts[i].Type, new List<Hideout>());
                }
                else
                {
                    continue;
                }
            }
        }

        foreach (KeyValuePair<ScriptableHideout.Type, List<Hideout>> entry in hideoutsByType)
        {
            for (int i = 0; i < allHideouts.Count; i++)
            {
                if (hideoutsByType.ContainsKey(entry.Key))
                {
                    entry.Value.Add(allHideouts[i]);
                }
                else
                {
                    continue;
                }
            }
        }
    }

    //FUNCTIONALITIES
    private List<Hideout> GetHideouts(ScriptableHideout.Type type)
    {
        if (hideoutsByType.ContainsKey(type))
        {
            foreach (KeyValuePair<ScriptableHideout.Type, List<Hideout>> entry in hideoutsByType)
            {
                if (entry.Key.Equals(type))
                {
                    return entry.Value;
                }
                else continue;
            }
            return null;
        }
        else return null;
    }

    private List<Hideout> GetAvailableHideouts(ScriptableHideout.Type type)
    {
        for (int i = 0; i < GetHideouts(type).Count; i++)
        {

        }
        return null;
    }
}
