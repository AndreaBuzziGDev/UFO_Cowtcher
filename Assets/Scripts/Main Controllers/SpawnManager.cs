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

    ///RESPAWNING COWS
    private List<SpawnQueuedCow> caughtCowWaitingForRespawn = new();

    ///NUMBER OF COWS IN THE MAP
    private int currentNumOfCows = 0;
    [SerializeField] private int maxNumOfCows = 20;

    ///NUMBER OF SIMULTANEOUSLY SPAWNED COWS
    private int currentSpawnedCount = 0;
    [SerializeField] private int maxSpawnedCount = 2;

    ///SIMULTANEOUS SPAWN TIMER
    private float simultaneousSpawnTimer = 0;
    [SerializeField] private float maxSpawnTimer = 1.0f;




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
        if (simultaneousSpawnTimer > 0.0f)
        {
            simultaneousSpawnTimer -= Time.deltaTime;
        }
        currentSpawnedCount = 0;
    }






    //FUNCTIONALITIES

    ///OVERALL INITIALIZATION PROCEDURE
    public void Initialization()
    {
        initializeCowCount();

        initializeAllSpawnPoints();
        MakeDictionarySpawnPoints();
    }

    ///MAIN INITIALIZATION
    ///COW TRACKING INITIALIZATION
    private void initializeCowCount()
    {
        List<Cow> cows = FindObjectsOfType<Cow>().ToList();
        currentNumOfCows = cows.Count;
        Debug.Log("SpawnManager - start num of cows: " + currentNumOfCows);
    }
    
    
    ///SPAWN POINTS INITIALIZATION
    private void initializeAllSpawnPoints()
    {
        allSpawnPoints = FindObjectsOfType<SpawnPoint>().ToList();
    }

    ///SPAWN POINT DICTIONARY INITIALIZATION
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

    ///GET SPAWN POINTS
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


    ///FUNCTIONALITY TO CAPTURE COWS ACCESSIBLE FROM ANYWHERE
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
                    //UPDATE RITUAL PROGRESSION
                    ritual.HandleCowSpawn();

                    //SUMMONING RITUAL TARGET COW IS AUTOMATICALLY ADDED TO RESPAWN QUEUE
                    MarkForRespawn(ritual.TargetSpawnedCow, 0);
                }
            }
        }

        //LOWER COUNT OF CURRENT COWS
        currentNumOfCows--;

        //TODO: AS OF SPRINT IN WEEK 24 07 2023: COWS WILL NOT AUTOMATICALLY ENTER RESPAWN QUEUE WHEN CAPTURED.
        //      DESIRED FEATURE IS: IF MAX NUMBER OF COWS IS NOT REACHED, RANDOMLY GENERATE COW BASED ON THEIR ADJUSTED PROBABILITY%
        MarkForRespawn(interestedCow.UID);
    }


    ///ADD COW TO "CAUGHT" COWS THAT WANT TO RESPAWN
    public void MarkForRespawn(ScriptableCow.UniqueID caughtCowUID)
    {
        GameObject prefabCowGO = Instantiate(Cowdex.Instance.GetCow(caughtCowUID).gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        prefabCowGO.gameObject.SetActive(false);

        caughtCowWaitingForRespawn.Add(new SpawnQueuedCow(prefabCowGO.GetComponentInChildren<Cow>()));
    }

    //TODO: HANDLE "EASY" OVERLOADING OF METHODS VIA NATIVE C# CAPABILITIES
    public void MarkForRespawn(ScriptableCow.UniqueID caughtCowUID, float customTimer)
    {
        GameObject prefabCowGO = Instantiate(Cowdex.Instance.GetCow(caughtCowUID).gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        prefabCowGO.gameObject.SetActive(false);
        
        caughtCowWaitingForRespawn.Add(new SpawnQueuedCow(prefabCowGO.GetComponentInChildren<Cow>(), customTimer));
    }




    ///HANDLE THE DEQUEUEING OF COWS READY TO SPAWN
    private void ManageDequeueingCows()
    {
        List<SpawnQueuedCow> tempList = new();
        foreach (SpawnQueuedCow sqc in caughtCowWaitingForRespawn)
        {
            sqc.LowerTimer(Time.deltaTime);
            if (sqc.IsReadyToSpawn && (currentNumOfCows < maxNumOfCows))
            {
                //TODO: COULD BE GREAT TO HAVE A SPAWNMANAGER HELPER TO HANDLE SOME OF THE DETAIL'S LOGIC
                if ((currentSpawnedCount < maxSpawnedCount) && (simultaneousSpawnTimer <= 0.0f))
                {
                    currentNumOfCows++;
                    currentSpawnedCount++;

                    sqc.Spawn();
                    tempList.Add(sqc);//DE-QUEUEING
                }
            }
        }

        if (currentSpawnedCount >= maxSpawnedCount)
        {
            //
            simultaneousSpawnTimer = maxSpawnTimer;
        }



        caughtCowWaitingForRespawn = caughtCowWaitingForRespawn.Except(tempList).ToList();
    }



}
