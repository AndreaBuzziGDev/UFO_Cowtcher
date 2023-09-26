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

    // Start is called before the first frame update
    void Start()
    {
        PlayRain();

    }

    // Update is called once per frame
    void Update()
    {
     
        
    }


    //FUNCTIONALITIES
    private void PlayRain()
    {
        foreach (ParticleSystem rf in rainFalls)
            rf.Play();
        foreach (ParticleSystem rs in rainSplashes)
            rs.Play();
    }

}
