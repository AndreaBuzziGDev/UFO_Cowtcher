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

    private List<SpawnQueuedCow> caughtCowWaitingForRespawn = new();


    //METHODS

    //...

    //TODO: STUDY AND APPLY THE SAME CHANGES TO THE Awake METHOD MADE TO GameController IN THIS MONOSINGLETON AS WELL


    // Start is called before the first frame update
    void Start()
    {
        initializeAllSpawnPoints();
        MakeDictionarySpawnPoints();
    }

    // Update is called once per frame
    void Update()
    {
        ManageDequeueingCows();
    }


    //INITIALIZATIONS

    //TODO: DEVELOP A DEBUG FUNCTIONALITY THAT DETECTS DUPLICATES AMONG THE ScriptableRitual AND REPORTS THEM AS ERRORS ON THE GAME/EDITOR CONSOLE.


    ///SPAWN POINTS DATA INITIALIZATION
    private void initializeAllSpawnPoints()
    {
        allSpawnPoints = FindObjectsOfType<SpawnPoint>().ToList();
    }

    private void MakeDictionarySpawnPoints()
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






    //FUNCTIONALITIES

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
            return new List<SpawnPoint>();
    }

    ///FUNCTIONALITY TO SPAWN COWS ACCESSIBLE FROM ANYWHERE
    public void SpawnCow(Cow spawnedCow)
    {
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

    public void HandleCowCapture(Cow interestedCow)
    {
        //


        //
        MarkForRespawn(interestedCow.UID);
    }


    ///ADD COW TO "CAUGHT" COWS THAT WANT TO RESPAWN
    public void MarkForRespawn(ScriptableCow.UniqueID caughtCowUID) 
    {
        GameObject prefabCowGO = Instantiate(Cowdex.Instance.GetCow(caughtCowUID).gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        prefabCowGO.gameObject.SetActive(false);

        caughtCowWaitingForRespawn.Add(new SpawnQueuedCow(prefabCowGO.GetComponentInChildren<Cow>()));
    }


    ///HANDLE THE DEQUEUEING OF COWS READY TO SPAWN
    private void ManageDequeueingCows()
    {
        List<SpawnQueuedCow> tempList = new();
        foreach (SpawnQueuedCow sqc in caughtCowWaitingForRespawn)
        {
            sqc.LowerTimer(Time.deltaTime);
            if (sqc.IsReadyToSpawn)
            {
                sqc.Spawn();
                tempList.Add(sqc);
            }
        }

        caughtCowWaitingForRespawn = caughtCowWaitingForRespawn.Except(tempList).ToList();
    }



}
