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
    [SerializeField] List<ParticleSystem> bubbles;


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
        RenderSettings.fog = false;

        foreach (ParticleSystem pSyst in bubbles)
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
        RenderSettings.fog = true;

        foreach (ParticleSystem rf in bubbles)
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
        RenderSettings.fog = false;

        foreach (ParticleSystem rf in bubbles)
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
        StopFog();
    }

}
