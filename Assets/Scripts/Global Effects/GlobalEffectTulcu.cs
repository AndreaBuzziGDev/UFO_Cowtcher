using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEffectTulcu : MonoSingleton<GlobalEffectTulcu>
{
    //DATA
    private int terrorCount = 0;
    public bool IsTerrorActive { get { return terrorCount > 0; } }

    ///PARTICLES
    [SerializeField] List<ParticleSystem> rainFalls;
    [SerializeField] List<ParticleSystem> rainSplashes;


    //METHODS
    //...

    //TODO: COMPLETE. MUST WORK PROPERLY VIA A REFACTOR OF THE TULCU EFFECT (NEEDS TO WORK LIKE EVERYTHING ELSE

    // Start is called before the first frame update
    void Start()
    {
        foreach (ParticleSystem rf in rainFalls)
            rf.gameObject.SetActive(false);
        foreach (ParticleSystem rs in rainSplashes)
            rs.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IsTerrorActive)
            PlayRain();
    }


    //FUNCTIONALITIES
    public void ApplyTerror(float terrorDuration, int terrorIterations, float waveDelay)
    {
        terrorCount = terrorIterations;
        StartCoroutine(TerrorRoutine(terrorDuration, waveDelay));
    }


    private void PlayRain()
    {
        foreach (ParticleSystem rf in rainFalls)
        {
            if (!rf.isPlaying)
            {
                rf.gameObject.SetActive(true);
                rf.Play();
            }
        }
        foreach (ParticleSystem rs in rainSplashes)
        {
            if (!rs.isPlaying)
            {
                rs.gameObject.SetActive(true);
                rs.Play();
            }
        }
    }

    private void StopRain()
    {
        foreach (ParticleSystem rf in rainFalls)
        {
            if (rf.isPlaying)
                rf.gameObject.SetActive(false);
        }
        foreach (ParticleSystem rs in rainSplashes)
        {
            if (rs.isPlaying)
                rs.gameObject.SetActive(false);
        }
    }



    //COROUTINES
    private IEnumerator TerrorRoutine(float terrorDuration, float waveDelay)
    {
        //APPLY TERROR TO PLAYER
        //TODO: CHANGE
        GameController.Instance.FindPlayerAnywhere().ApplyTerror(terrorDuration / 3);//TODO: STUN THE UFO FOR FULL TIMER?

        //APPLY TERROR TO COWS (FIRE EVENT?)
        CowManager.Instance.ApplyGlobalTerrify(terrorDuration);

        //playerController.ApplyStun(this.stunDuration);
        UIController.Instance.IGPanel.DebuffPanel.fadeToTransparent = true;

        //
        terrorCount--;

        if (terrorCount > 0)
        {
            yield return new WaitForSeconds(waveDelay);
            StartCoroutine(TerrorRoutine(terrorDuration, waveDelay));

        }
        else
            StopRain();

    }

}
