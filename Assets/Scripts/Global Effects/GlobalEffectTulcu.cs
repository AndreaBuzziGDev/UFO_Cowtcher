using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEffectTulcu : MonoSingleton<GlobalEffectTulcu>
{
    //DATA
    [SerializeField] List<ParticleSystem> rainFalls;
    [SerializeField] List<ParticleSystem> rainSplashes;


    //METHODS
    //...

    //TODO: COMPLETE. MUST WORK PROPERLY VIA A REFACTOR OF THE TULCU EFFECT (NEEDS TO WORK LIKE EVERYTHING ELSE

    // Start is called before the first frame update
    void Start()
    {
        /*
        foreach (ParticleSystem rf in rainFalls)
            rf.Stop();
        foreach (ParticleSystem rs in rainSplashes)
            rs.Stop();
        */
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if ()
        {

        }
        */
        PlayRain();
    }


    //FUNCTIONALITIES
    private void PlayRain()
    {
        foreach (ParticleSystem rf in rainFalls)
        {
            if (!rf.isPlaying)
                rf.Play();
        }
        foreach (ParticleSystem rs in rainSplashes)
        {
            if (!rs.isPlaying)
                rs.Play();
        }
    }

}
