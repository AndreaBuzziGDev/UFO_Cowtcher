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


    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //FUNCTIONALITIES
    public void ApplyCurse(float curseDuration)
    {
        //MAKE ALL COWS THAT ARE NOT COWTCHMAN DISAPPEAR

        //
        List<Cow> allFoundCows = FindObjectsOfType<Cow>().ToList();

        foreach(Cow fCow in allFoundCows)
        {
            if (fCow.gameObject.activeSelf && fCow.CowTemplate.UID != CowSO.UniqueID.L003_Flying_Cowtchman)
            {
                disappearedCows.Add(fCow);
                fCow.gameObject.SetActive(false);
            }
        }

        isCurseActive = true;
        StartCoroutine(CurseRoutine(curseDuration));
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
