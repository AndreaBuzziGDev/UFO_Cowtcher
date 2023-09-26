using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEffectTulcu : MonoSingleton<GlobalEffectTulcu>
{
    //DATA

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
        /*
        if ()
        {

        }
        */
        if(true)
            PlayRain();
        else
            StopRain();//TODO: MOVE ELSEWHERE LIKE WITH SNOWSTORM
    }


    //FUNCTIONALITIES
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

}
