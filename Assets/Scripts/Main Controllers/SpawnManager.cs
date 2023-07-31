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


    ///SPAWN MODE SETTINGS
    [SerializeField] private bool isGridSpawnMode = false;

    ///SPAWN
    //TODO: INTRODUCE FLAG TO DETERMINE WETHER THE SYSTEM WILL USE WEIGHTED CHANCE OR SOMETHING ELSE
    [Tooltip("If checked, this uses the random spawn percentage instead of respawning the captured cow with a cooldown")]
    [SerializeField] private bool isRandomizedSpawnMode = false;

    private Dictionary<CowSO.UniqueID, float> spawnChances = new();
    private Dictionary<CowSO.UniqueID, float> weightedSpawnChances = new();




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
        //TODO: WILL PROBABLY REQUIRE A DIFFERENT IF INNESTATION
        ManageDequeueingCows();
        if (simultaneousSpawnTimer > 0.0f)
        {
            simultaneousSpawnTimer -= Time.deltaTime;
        }
        currentSpawnedCount = 0;





        if (isRandomizedSpawnMode)
        {
            //MODE: SPAWN BASED ON RANDOM CHANCE + RITUAL SUMMONED COW
            ManageRandomlySpawnCows();

        }

    }






    //FUNCTIONALITIES

    ///OVERALL INITIALIZATION PROCEDURE
    public void Initialization()
    {
        initializeCowCount();
        initializeSpawnProbabilityDictionary();

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

    ///INITIALIZE SPAWN PROBABILITY DICTIONARY
    private void initializeSpawnProbabilityDictionary()
    {
        //TODO: PERHAPS A SYSTEM THAT TAKES INTO ACCOUNT THE SPAWN CHANCE OF EACH OF THE EXISTING COWS ON THE MAP CAN BE TAKEN INTO ACCOUNT?
        List<CowSO.UniqueID> UIDs = new List<CowSO.UniqueID> { CowSO.UniqueID.C000Jamal, CowSO.UniqueID.C001Kevin };
        TrackSpawnProbability(UIDs);
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
        if (isGridSpawnMode)
        {
            SpawnCowByGrid(spawnedCow);
        } 
        else
        {
            SpawnCowBySpawnPoint(spawnedCow);
        }
    }


    //TODO: SOME CODE COULD BE MOVED TO A SpawnManagerHelper Class for simplification and separation of concerns
    private void SpawnCowByGrid(Cow spawnedCow)
    {
        Debug.Log("SpawnManager - Grid: " + SpawningGrid.Instance);
        if (SpawningGrid.Instance != null)
        {
            SpawningGrid.Instance.SpawnCowInsideGrid(spawnedCow);
        }
        else
        {
            //FALLBACK: SPAWN AT zero
            Debug.Log("SpawnManager - No Spawning Grid Found");
            SpawningGrid.SpawnCowAtZero(spawnedCow);
        }
    }

    private void SpawnCowBySpawnPoint(Cow spawnedCow)
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
    public void MarkForRespawn(CowSO.UniqueID caughtCowUID)
    {
        GameObject prefabCowGO = Instantiate(Cowdex.Instance.GetCow(caughtCowUID).gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        prefabCowGO.gameObject.SetActive(false);

        caughtCowWaitingForRespawn.Add(new SpawnQueuedCow(prefabCowGO.GetComponentInChildren<Cow>()));
    }

    //TODO: HANDLE "EASY" OVERLOADING OF METHODS VIA NATIVE C# CAPABILITIES
    public void MarkForRespawn(CowSO.UniqueID caughtCowUID, float customTimer)
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

                    Debug.Log("SpawnManager - ManageDequeueingCows");
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








    ///PROBABILITY-BASED SPAWN FUNCTIONALITIES
    private void TrackSpawnProbability(List<CowSO.UniqueID> UIDs)
    {
        List<Cow> cowPrefabs = Cowdex.Instance.GetCows(UIDs);

        foreach (Cow prefabCow in cowPrefabs)
        {
            spawnChances.Add(prefabCow.UID, prefabCow.CowTemplate.spawnProbability);
        }

        CalculateWeightedProbabilities();
    }

    private void CalculateWeightedProbabilities()
    {
        float totalSum = 0;
        foreach (KeyValuePair<CowSO.UniqueID, float> entry in spawnChances)
        {
            totalSum += entry.Value;
        }

        float weightCoefficient = 100 / totalSum;
        Debug.Log("SpawnManager Randomly - weightCoefficient: " + weightCoefficient);

        foreach (KeyValuePair<CowSO.UniqueID, float> entry in spawnChances)
        {
            weightedSpawnChances.Add(entry.Key, entry.Value * weightCoefficient);
            Debug.Log("SpawnManager Randomly - Base Probability for Cow: " + entry.Key + " is: " + entry.Value);
            Debug.Log("SpawnManager Randomly - Weighted Probability for Cow: " + entry.Key + " is: " + entry.Value * weightCoefficient);
        }

    }





    private void ManageRandomlySpawnCows()
    {
        //...

    }

}
