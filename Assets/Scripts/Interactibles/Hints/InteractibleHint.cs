using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleHint : MonoInteractible
{
    //DATA
    ///HINTS
    [SerializeField] private List<HintAbstract> hints = new();

    ///
    [SerializeField] private float cooldown = 30;
    private float cooldownTimer;



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


    //IMPLEMENTING MonoInteractible
    public override void Interact(GameObject interactionSource)
    {
        //TODO: THIS MIGHT MAKE GOOD USE OF AN INTERACTION CONDITION THAT ALLOWS FOR A BETTER CONTROL (NOT NEEDED FOR NOW)

        foreach (HintAbstract h in hints) h.Play();
    }



    //FUNCTIONALITIES




}
