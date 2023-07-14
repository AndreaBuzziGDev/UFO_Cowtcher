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
                Debug.Log("cycledHideout.Type: " + cycledHideout.Type + " Count: " + hideoutsByType[cycledHideout.Type].Count);

            }
        }
        Debug.Log("hideoutsByType Count: " + hideoutsByType.Count);

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
