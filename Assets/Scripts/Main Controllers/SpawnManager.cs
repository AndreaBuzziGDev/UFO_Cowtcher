using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    //DATA
    private Dictionary<SpawnPoint.Type, List<SpawnPoint>> spawnPointsByType = new();

    private List<SpawnPoint> allSpawnPoints = new();
    public List<SpawnPoint> AllSpawnPoints { get { return allSpawnPoints; } }


    private List<CowSummoningRitual> rituals = new();
    [SerializeField] private List<ScriptableRitual> allTemplateRituals;//PUT ALL SCRIPTABLE OBJECT RITUALS INSIDE HERE.
    [SerializeField] private List<Cow> allowedCows;//PUT ALL PREFAB (GameObject) COWs INSIDE HERE.


    //METHODS

    //...

    // Start is called before the first frame update
    void Start()
    {
        initializeAllSpawnPoints();
        MakeDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //FUNCTIONALITIES

    //TODO: DEVELOP A DEBUG FUNCTIONALITY THAT DETECTS DUPLICATES AMONG THE ScriptableRitual AND REPORTS THEM AS ERRORS ON THE GAME/EDITOR CONSOLE.


    ///INITIALIZATION
    private void initializeAllSpawnPoints()
    {
        allSpawnPoints = FindObjectsOfType<SpawnPoint>().ToList();
    }

    private void MakeDictionary()
    {
        if (allSpawnPoints != null)
        {
            foreach (SpawnPoint cycledSpawnPoint in allSpawnPoints)
            {
                if (!spawnPointsByType.ContainsKey(cycledSpawnPoint.SpawnType))
                {
                    spawnPointsByType.Add(cycledSpawnPoint.SpawnType, new List<SpawnPoint> { cycledSpawnPoint });
                }
                else
                {
                    spawnPointsByType[cycledSpawnPoint.SpawnType].Add(cycledSpawnPoint);
                }
            }
        }

    }


    ///GET HIDEOUT
    ///
    public List<SpawnPoint> GetSpawnPoint(List<SpawnPoint.Type> types)
    {
        List<SpawnPoint> allSpawnPointsFromAllTypes = new();
        foreach(SpawnPoint.Type sType in types)
        {
            allSpawnPointsFromAllTypes.AddRange(GetSpawnPoint(sType));
        }

        return allSpawnPointsFromAllTypes;
    }
    public List<SpawnPoint> GetSpawnPoint(SpawnPoint.Type type)
    {
        if (spawnPointsByType.ContainsKey(type)) 
            return spawnPointsByType[type];
        else 
            return null;
    }



}
