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

    // Update is called once per frame
    void Update()
    {
        if (isRandomizedSpawnMode)
        {
            //MODE: SPAWN BASED ON RANDOM CHANCE + RITUAL SUMMONED COW
            //TODO: ADJUST PARAMETERS AND STUFF...
            ManageRandomlySpawnCow();
        }
        else
        {
            //MODE: RESPAWN BASED ON CAPTURED COWS + RITUAL SUMMONED COW
            ManageDequeueingCows();
            if (simultaneousSpawnTimer > 0.0f)
            {
                simultaneousSpawnTimer -= Time.deltaTime;
            }
            currentSpawnedCount = 0;
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

        //TODO: UPGRADE SO THAT IT TRACKS THE DIFFERENT TYPES OF COWS THAT EXIST ON THE MAP


        //


    }

    ///INITIALIZE SPAWN PROBABILITY DICTIONARY
    private void initializeSpawnProbabilityDictionary()
    {
        //TODO: PERHAPS A SYSTEM THAT TAKES INTO ACCOUNT THE SPAWN CHANCE OF EACH OF THE EXISTING COWS ON THE MAP CAN BE TAKEN INTO ACCOUNT?
        List<CowSO.UniqueID> UIDs = new List<CowSO.UniqueID> { CowSO.UniqueID.C000Jamal, CowSO.UniqueID.C001Kevin };
        //List<CowSO.UniqueID> UIDs = new List<CowSO.UniqueID> { CowSO.UniqueID.C000Jamal };
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
            //FALLBACK: SPAWN AT zero
            Debug.Log("No Valid Spawn Point found for Cow: " + spawnedCow.CowName);
            SpawningGrid.SpawnCowAtZero(spawnedCow);
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

        //
        if (isRandomizedSpawnMode)
        {
            if (!spawnChances.ContainsKey(interestedCow.UID))
            {
                TrackSpawnProbability(new List<CowSO.UniqueID> { interestedCow.UID });
            }
        }
        else
        {
            //QUEUED BEHAVIOUR: RESPAWN CAUGHT COWS
            MarkForRespawn(interestedCow.UID);
        }
    }


    ///ADD COW TO "CAUGHT" COWS THAT WANT TO RESPAWN
    public void MarkForRespawn(CowSO.UniqueID caughtCowUID)
    {
        MarkForRespawn(caughtCowUID, Cowdex.Instance.GetCow(caughtCowUID).CowTemplate.TimerRespawn);
    }

    //TODO: HANDLE "EASY" OVERLOADING OF METHODS VIA NATIVE C# CAPABILITIES
    public void MarkForRespawn(CowSO.UniqueID caughtCowUID, float customTimer)
    {
        GameObject prefabCowGO = Instantiate(Cowdex.Instance.GetCow(caughtCowUID).gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        prefabCowGO.gameObject.SetActive(false);

        if (isRandomizedSpawnMode)
        {
            //MODE: RANDOMIZED SPAWN - RITUAL COWS ARE SPAWNED IMMEDIATELY
            SpawnCow(prefabCowGO.GetComponentInChildren<Cow>());
            currentNumOfCows++;
        }
        else
        {
            //MODE: QUEUED SPAWN - RITUAL COWS AND CAPTURED COWS ARE ADDED TO THE RESPAWN QUEUE
            caughtCowWaitingForRespawn.Add(new SpawnQueuedCow(prefabCowGO.GetComponentInChildren<Cow>(), customTimer));
        }
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
            //NB: REFERENCING TEMPLATE. THIS IS A PREFAB, WHICH HAS NOT-YET RUN THE "Awake" METHOD
            spawnChances.Add(prefabCow.CowTemplate.UID, prefabCow.CowTemplate.spawnProbability);
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

        weightedSpawnChances = new Dictionary<CowSO.UniqueID, float>();
        foreach (KeyValuePair<CowSO.UniqueID, float> entry in spawnChances)
        {
            weightedSpawnChances.Add(entry.Key, entry.Value * weightCoefficient);
            Debug.Log("SpawnManager Randomly - Base Probability for Cow: " + entry.Key + " is: " + entry.Value);
            Debug.Log("SpawnManager Randomly - Weighted Probability for Cow: " + entry.Key + " is: " + entry.Value * weightCoefficient);
        }

    }





    private void ManageRandomlySpawnCow()
    {
        if (currentNumOfCows < maxNumOfCows)
        {
            //MODE: WEIGHTED CHANCE
            //TODO: COMMENT
            SpawnRandomlyWeightedChance();

            //MODE: SOMETHING ELSE
            //TODO: UNCOMMENT
            //SpawnRandomlyTallyChance();

        }
    }


    //WEIGHTED CHANCE: CHANCE WILL CHANGE BASED ON HOW MANY ARE INPUT, COLLECTIVE CHANCE WILL ALWAYS BE 100%
    private void SpawnRandomlyWeightedChance()
    {
        float randomFloat = Random.Range(0, 100);
        Debug.Log("SpawnManager ManageRandomlySpawnCows - randomFloat: " + randomFloat);

        float chanceTally = 0;
        CowSO.UniqueID choice = CowSO.UniqueID.ANY;
        foreach (KeyValuePair<CowSO.UniqueID, float> entry in weightedSpawnChances)
        {
            chanceTally += entry.Value;
            Debug.Log("SpawnManager ManageRandomlySpawnCows - chanceTally: " + chanceTally);

            if (randomFloat <= chanceTally)
            {
                //THIS IS THE RANDOMLY CHOSEN COW
                choice = entry.Key;
                break;
            }
        }

        if (choice != CowSO.UniqueID.ANY)
        {
            GameObject prefabCowGO = Instantiate(Cowdex.Instance.GetCow(choice).gameObject, new Vector3(0, 0, 0), Quaternion.identity);
            prefabCowGO.SetActive(false);

            SpawnCow(prefabCowGO.GetComponentInChildren<Cow>());
            currentNumOfCows++;
        }

    }


    //TALLY CHANCE: SIMILAR TO WEIGHTED CHANCE, BUT A CHANCE TALLY WILL BE USED INSTEAD
    private void SpawnRandomlyTallyChance()
    {
        //TODO: USE THE FUNCTIONALITIES PROVIDED BY SpawnManagerCow

        //1) OBTAIN RANDOM INT - USE THE TALLY CALCULATED BY SpawnManagerCow AS THE UPPER BOUNDARY


        //2) OBTAIN THE MATCHING RANDOM COW FROM THE SpawnManagerCow


        //3) SPAWN COW

    }


}
