using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GlobalEffectDutch : MonoSingleton<GlobalEffectDutch>
{
    //DATA
    private bool isCurseActive;
    public bool IsCurseActive { get { return isCurseActive; } }

    List<Cow> disappearedCows = new();

    ///PARTICLE & ATMOSPHERIC
    [SerializeField] List<ParticleSystem> windRushes;


    ///EXCLUDED COWS
    HashSet<CowSO.UniqueID> excludedCows = new HashSet<CowSO.UniqueID> {
        CowSO.UniqueID.L003_Flying_Cowtchman,
        CowSO.UniqueID.L006_Cowre_Trainer
    };


    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        foreach (ParticleSystem pSyst in windRushes)
            pSyst.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCurseActive)
            PlayFog();
    }


    //FUNCTIONALITIES
    public void ApplyCurse(float curseDuration)
    {
        //MAKE ALL COWS THAT ARE NOT COWTCHMAN DISAPPEAR

        //
        List<Cow> allFoundCows = FindObjectsOfType<Cow>().ToList();

        foreach(Cow fCow in allFoundCows)
        {
            if (fCow.gameObject.activeSelf && !excludedCows.Contains(fCow.CowTemplate.UID))
            {
                disappearedCows.Add(fCow);
                fCow.gameObject.SetActive(false);
            }
        }

        isCurseActive = true;
        StartCoroutine(CurseRoutine(curseDuration));
    }


    private void PlayFog()
    {
        foreach (ParticleSystem rf in windRushes)
        {
            if (!rf.isPlaying)
            {
                rf.gameObject.SetActive(true);
                rf.Play();
            }
        }
    }

    private void StopFog()
    {
        foreach (ParticleSystem rf in windRushes)
        {
            if (rf.isPlaying)
                rf.gameObject.SetActive(false);
        }
    }



    //COROUTINES
    private IEnumerator CurseRoutine(float curseDuration)
    {
        //WAIT FOR TIME
        yield return new WaitForSeconds(curseDuration);


        //RE-ENABLE FOG-DISABLED COWS
        foreach(Cow dCow in disappearedCows)
            dCow.gameObject.SetActive(true);

        isCurseActive = false;
    }

}
