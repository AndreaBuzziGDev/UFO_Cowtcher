using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEffectAvalanche : MonoSingleton<GlobalEffectAvalanche>
{
    //DATA
    private float avalancheSpeedMultiplier = 100.0f;
    public float AvalancheSpeedMult { get { return avalancheSpeedMultiplier / 100.0f; } }
    public bool IsAvalanche { get { return AvalancheSpeedMult > 1.0f; } }//TODO: SHOULD PROBABLY USE A BOOL VAR FOR THIS?

    ///PARTICLES
    [SerializeField] List<ParticleSystem> snowFalls;



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        foreach (ParticleSystem rf in snowFalls)
            rf.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAvalanche)
            PlaySnow();
        else
            StopSnow();
    }


    //FUNCTIONALITIES
    public void ApplyAvalanche(float avalancheDuration, float speedBonusPercent)
    {
        avalancheSpeedMultiplier += speedBonusPercent;
        StartCoroutine(AvalancheRoutine(avalancheDuration));
    }



    private void PlaySnow()
    {
        foreach (ParticleSystem sf in snowFalls)
        {
            if (!sf.isPlaying)
            {
                sf.gameObject.SetActive(true);
                sf.Play();
            }
        }
    }
    private void StopSnow()
    {
        foreach (ParticleSystem sf in snowFalls)
        {
            if (!sf.isPlaying)
                sf.Stop();
        }
    }



    //COROUTINES
    private IEnumerator AvalancheRoutine(float avalancheDuration)
    {
        //WAIT FOR TIME
        yield return new WaitForSeconds(avalancheDuration);

        //RE-SET SPEED
        avalancheSpeedMultiplier = 100.0f;
    }

}
