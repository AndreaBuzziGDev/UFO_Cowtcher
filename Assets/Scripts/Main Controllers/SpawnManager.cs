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

    private List<SpawnQueuedCow> caughtCowWaitingForRespawn = new();


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
        ManageDequeueingCows();
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
    public List<SpawnPoint> GetSpawnPoints(List<SpawnPoint.Type> types)
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

    ///FUNCTIONALITY TO SPAWN COWS ACCESSIBLE FROM ANYWHERE
    public void SpawnCow(Cow spawnedCow)
    {
        //TODO: THIS IS USEFUL FUNCTIONALITY THAT CAN BE RECYCLED.
        List<SpawnPoint> possibleSpawnPoints = GetSpawnPoints(spawnedCow.AllowedSpawnPointTypes);

        if (possibleSpawnPoints.Count > 0)
        {
            int randomSpawnSlot = Random.Range(0, possibleSpawnPoints.Count);
            SpawnPoint sp = possibleSpawnPoints[randomSpawnSlot];
            sp.Spawn(spawnedCow);
        }
        else
        {
            Debug.Log("No Valid Spawn Point found for Cow: " + spawnedCow.CowName);
        }
    }


    ///ADD COW TO "CAUGHT" COWS THAT WANT TO RESPAWN
    public void MarkForRespawn(Cow caughtCow) => caughtCowWaitingForRespawn.Add(new SpawnQueuedCow(caughtCow));


    ///HANDLE THE DEQUEUEING OF COWS READY TO SPAWN
    private void ManageDequeueingCows()
    {
        foreach (SpawnQueuedCow sqc in caughtCowWaitingForRespawn)
        {
            sqc.LowerTimer(Time.deltaTime);
            if (sqc.IsReadyToSpawn)
            {
                sqc.Spawn();
            }
        }
    }



}
