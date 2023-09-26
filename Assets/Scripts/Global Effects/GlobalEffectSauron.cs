using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEffectSauron : MonoSingleton<GlobalEffectSauron>
{
    //DATA
    private float sauronMult = 100.0f;
    public float SauronMult { get { return sauronMult / 100.0f; } }

    public bool IsRingPowerActive { get { return SauronMult < 1; } }

    ///PARTICLES
    [SerializeField] List<ParticleSystem> ignesFatui;


    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        foreach (ParticleSystem igne in ignesFatui)
            igne.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRingPowerActive)
            PlayRingPower();
    }


    //FUNCTIONALITIES
    public void ApplyRingPower(float ringPowerDuration, float speedMalus)
    {
        sauronMult -= speedMalus;
        StartCoroutine(RingPowerRoutine(ringPowerDuration));
    }



    private void PlayRingPower()
    {
        foreach (ParticleSystem igne in ignesFatui)
        {
            if (!igne.isPlaying)
            {
                igne.gameObject.SetActive(true);
                igne.Play();
            }
        }
    }
    private void StopRingPower()
    {
        foreach (ParticleSystem igne in ignesFatui)
        {
            if (igne.isPlaying)
                igne.gameObject.SetActive(false);
        }
    }



    //COROUTINES
    private IEnumerator RingPowerRoutine(float ringPowerDuration)
    {
        //WAIT FOR TIME
        yield return new WaitForSeconds(ringPowerDuration);

        //RE-SET SPEED
        sauronMult = 100.0f;
        StopRingPower();
    }

}
