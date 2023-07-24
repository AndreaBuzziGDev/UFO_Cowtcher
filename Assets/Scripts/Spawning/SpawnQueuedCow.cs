using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQueuedCow
{
    //DATA
    private Cow queued;
    private float respawnTimer;
    public bool IsReadyToSpawn { get { return (respawnTimer <= 0.0f); } }



    //CONSTRUCTOR
    public SpawnQueuedCow(Cow respawnedCow)
    {
        this.queued = respawnedCow;
        this.respawnTimer = respawnedCow.CowTemplate.TimerRespawn;
    }

    public SpawnQueuedCow(Cow respawnedCow, float customTimer)
    {
        this.queued = respawnedCow;
        this.respawnTimer = customTimer;
    }


    //METHODS
    //FUNCTIONALITIES
    public void LowerTimer(float delta)
    {
        if (!IsReadyToSpawn) this.respawnTimer -= delta;
    }

    public void Spawn() => SpawnManager.Instance.SpawnCow(queued);

}
