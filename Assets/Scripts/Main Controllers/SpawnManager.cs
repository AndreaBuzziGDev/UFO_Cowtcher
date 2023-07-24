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
        //...

    }

    // Update is called once per frame
    void Update()
    {
        ManageDequeueingCows();
    }






    //FUNCTIONALITIES

    ///OVERALL INITIALIZATION PROCEDURE
    public void Initialization()
    {
        initializeAllSpawnPoints();
        MakeDictionarySpawnPoints();
    }

    ///MAIN INITIALIZATION
    private void initializeAllSpawnPoints()
    {
        allSpawnPoints = FindObjectsOfType<SpawnPoint>().ToList();
    }

    ///SPAWN POINT INITIALIZATION
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
        foreach (SpawnPoint.Type sType in types)
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
        List<RitualAbstract> rituals = Cowdex.Instance.GetRitualsThatContainCow(interestedCow.UID);

        //TODO: THIS CAN BE OPTIMIZED BY STORING UIDs AND LATER SINGLE-CALLING GetCows FROM Cowdex
        foreach (RitualAbstract ritual in rituals)
        {
            if (ritual.HasCow(interestedCow.UID))
            {
                ritual.DoRitual(interestedCow.UID);
                if (ritual.IsReadyToSpawn())
                {
                    ritual.HandleCowSpawn();
                    //Cow toBeSpawnedRitualCompleteCow = Cowdex.Instance.GetCow(interestedCow.UID);

                    GameObject toBeSpawnedRitualCompleteCow = Instantiate(Cowdex.Instance.GetCow(ritual.TargetSpawnedCow).gameObject, new Vector3(0, 0, 0), Quaternion.identity);

                    //TODO: CHECK IF THERE ARE SPAWN POINTS AVAILABLE FOR THE COW. IF NOT, SPAWN AT ORIGIN?
                    //TODO: SHOULD COWS SUMMONED BY RITUALS RATHER BE QUEUED WITH TIME 0?
                    SpawnCow(toBeSpawnedRitualCompleteCow.GetComponent<Cow>());

                }
            }

            /*
            CowSummoningRitualModule iteratedModule = new CowSummoningRitualModule(entry.Key, entry.Value);
            ritualDictionary.Add(entry.Key, iteratedModule);
            */
        }


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
