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

    private Dictionary<CowSO.UniqueID, int> tallySpawnChances = new();




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
        SpawnManagerCow.Instance.Initialization();

        InitializeCowCount();
        InitializeSpawnProbabilityDictionary();

        initializeAllSpawnPoints();
        MakeDictionarySpawnPoints();


    }

    ///MAIN INITIALIZATION
    ///COW TRACKING INITIALIZATION
    private void InitializeCowCount()
    {
        List<Cow> cows = FindObjectsOfType<Cow>().ToList();
        currentNumOfCows = cows.Count;
        Debug.Log("SpawnManager - start num of cows: " + currentNumOfCows);

        //TODO: UPGRADE SO THAT IT TRACKS THE DIFFERENT TYPES OF COWS THAT EXIST ON THE MAP


        //


    }

    ///INITIALIZE SPAWN PROBABILITY DICTIONARY
    private void InitializeSpawnProbabilityDictionary()
    {
        //GRANT "MINIMALLY-GRANTED" COWS
        List<CowSO.UniqueID> UIDs = new List<CowSO.UniqueID>();

        //THE SYSTEM IS INITIALIZED TAKING INTO ACCOUNT THE COWS THAT THE PLAYER HAS UNLOCKED (KNOWN or CAPTURED)
        List<IndexedCow> indexedCows = Cowdex.Instance.GetAllIndexedActualCows();

        foreach(IndexedCow ic in indexedCows)
        {
            if (!UIDs.Contains(ic.ReferenceTemplate.UID))
            {
                if ((int)ic.KnowledgeState > 0)
                {
                    UIDs.Add(ic.ReferenceTemplate.UID);
                    Debug.Log("SpawnManager - Cow with UID: " + ic.ReferenceTemplate.UID + " is added to the spawn system due to its knowledge status being: " + ic.KnowledgeState.ToString());
                }
            }
        }

        //PREPARING DATA STRUCTURES
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
        //NOTIFY SYSTEMS THAT COW HAS BEEN CAPTURED
        SaveInfoCow cowSI = SaveSystem.LoadCowProgress(interestedCow.UID);
        if (!cowSI.IsCaptured)
        {
            SaveSystem.SaveCowProgress(interestedCow.UID, SaveInfoCow.Knowledge.Captured);
            //FIRE EVENT FOR A NEW COW BEING CAPTURED

        }


        //LOWER COUNT OF CURRENT COWS
        currentNumOfCows--;

        //
        if (isRandomizedSpawnMode)
        {
            if (!tallySpawnChances.ContainsKey(interestedCow.UID))
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

        //TODO: THIS MUST TRACK ONLY THE ALLOWED COWS FOR THIS MAP.
        List<CowSO.UniqueID> allowedCowIds = SpawnManagerCow.Instance.AllowedCowIDs;

        foreach (Cow prefabCow in cowPrefabs)
        {
            //ENFORCED BEHAVIOUR: ONLY "ALLOWED" COWS SPAWN IN THE SCENE
            if (!SpawnManagerCow.Instance.AllowAllCows)
            {
                if (allowedCowIds.Contains(prefabCow.CowTemplate.UID)) tallySpawnChances.Add(prefabCow.CowTemplate.UID, prefabCow.CowTemplate.spawnChanceTally);
            }
            //DEFAULT BEHAVIOUR: ALL COWS ENABLED
            else tallySpawnChances.Add(prefabCow.CowTemplate.UID, prefabCow.CowTemplate.spawnChanceTally);

        }

    }



    private void ManageRandomlySpawnCow()
    {
        if (currentNumOfCows < maxNumOfCows)
        {
            //MODE: WEIGHTED CHANCE
            //SpawnRandomlyWeightedChance();

            //MODE: SOMETHING ELSE
            SpawnRandomlyTallyChance();

        }
    }

    //TALLY CHANCE: SIMILAR TO WEIGHTED CHANCE, BUT A CHANCE TALLY WILL BE USED INSTEAD
    private void SpawnRandomlyTallyChance()
    {
        //TODO: USE THE FUNCTIONALITIES PROVIDED BY SpawnManagerCow

        //1) OBTAIN RANDOM INT - USE THE TALLY CALCULATED BY SpawnManagerCow AS THE UPPER BOUNDARY
        int randomChance = Random.Range(1, SpawnManagerHelper.GetTally(tallySpawnChances));

        //2) OBTAIN THE MATCHING RANDOM COW FROM THE SpawnManagerCow
        CowSO.UniqueID randomChoice = SpawnManagerHelper.GetCorrespondingCowFromTally(tallySpawnChances, randomChance);

        //3) SPAWN COW
        //TODO: THIS COULD BE EXPORTED
        if (randomChoice != CowSO.UniqueID.ANY)
        {
            GameObject prefabCowGO = Instantiate(Cowdex.Instance.GetCow(randomChoice).gameObject, new Vector3(0, 0, 0), Quaternion.identity);
            prefabCowGO.SetActive(false);

            SpawnCow(prefabCowGO.GetComponentInChildren<Cow>());
            currentNumOfCows++;
        }
    }


}
