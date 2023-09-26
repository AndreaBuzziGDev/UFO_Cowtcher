using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleHint : MonoInteractible
{
    //DATA
    ///AUDIO SOURCE
    [SerializeField] private AudioSource birdPlaySoundSource;
    [SerializeField] private AudioSource treeShakeSoundSource;

    ///HINTS
    [SerializeField] private List<HintAbstract> hints = new();

    ///
    [SerializeField] private float cooldownMax = 30;
    private float cooldownTimer;
    public bool IsCoolingDown { get { return cooldownTimer > 0; } }

    private bool hasReset;



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        hasReset = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCoolingDown)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else if(!hasReset) Reset();

    }


    //IMPLEMENTING MonoInteractible
    public override void Interact(GameObject interactionSource)
    {
        //TODO: THIS MIGHT MAKE GOOD USE OF AN INTERACTION CONDITION THAT ALLOWS FOR A BETTER CONTROL (NOT NEEDED FOR NOW)
        if (!IsCoolingDown)
        {
            foreach (HintAbstract h in hints) h.Play();

            birdPlaySoundSource.Play();
            treeShakeSoundSource.Play();
            cooldownTimer = cooldownMax;
            hasReset = false;
        }

    }



    //FUNCTIONALITIES
    public void Reset()
    {
        //APPLY RESET TO ALL HINTS
        foreach (HintAbstract h in hints) h.ResetHint();
        hasReset = true;
    }



}
