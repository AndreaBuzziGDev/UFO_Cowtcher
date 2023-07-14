using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideoutManager : MonoSingleton<HideoutManager>
{
    //DATA
    private List<Hideout> allHideouts = new();
    private List<ScriptableHideout.Type> allHideoutTypes = new();

    //METHODS
    //...
    public override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetHideoutArrayToList();
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

    private void MakeListOfAllHideoutTypes()
    {
        for (int i = 0; i < allHideouts.Count; i++)
        {
            if(allHideoutTypes.Count == 0)
            {
                allHideoutTypes.Add(allHideouts[i].Type);
            }
            else if (allHideouts[i].Type != allHideouts[i - 1].Type)
            {
                allHideoutTypes.Add(allHideouts[i].Type);
            }
            else
            {
                continue;
            }
        }
    }

    private void CreateDictionaryByType()
    {
        Dictionary <ScriptableHideout.Type, List <Hideout>> dictionaryByType = new();
        for(int i = 0; i < allHideouts.Count; i++)
        {
            for (int j = 0; j < allHideoutTypes.Count; j++)
            {
                if (allHideouts[i].Type == allHideoutTypes[j])
                {
                    dictionaryByType.Add(allHideoutTypes[j], new List<Hideout>());
                }
                else 
                { 
                    continue;
                }
            }

            foreach(KeyValuePair<ScriptableHideout.Type, List<Hideout>> entry in dictionaryByType)
            {
                for (int w = 0;  w < entry.Value.Count; w++)
                {
                    entry.Value[w] = allHideouts[i];
                }
            }
        }
    }

    //FUNCTIONALITIES

}
