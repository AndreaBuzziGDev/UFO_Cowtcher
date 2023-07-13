using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexedCow
{
    //ENUMS
    public enum CowKnowledgeState
    {
        Unknown,
        Known,
        Captured
    }

    //DATA
    private CowKnowledgeState state = CowKnowledgeState.Unknown;
    public CowKnowledgeState State { get { return state; } }

    private ScriptableCow referenceTemplate;
    public ScriptableCow ReferenceTemplate { get { return referenceTemplate; } }


    //TODO: NON SERVE NEMMENO. BASTA USARE IL Cowdex PER RECUPERARE LA COW CORRISPONDENTE.
    //LETTERALMENTE MEGLIO AVERE LA LISTA DELLE REQUIRED COWS.


    private List<IndexedCow> cowSummoningRitual = new();
    public List<IndexedCow> CowSummoningRitual { get { return cowSummoningRitual; } }


    //CONSTRUCTOR
    //TODO: IT MIGHT BE USEFUL TO BUILD WRAPPERS TO MAKE THE COW TRANSITION INTO ANOTHER STATE VALUE
    public IndexedCow(CowKnowledgeState targetState, ScriptableCow template)
    {
        this.state = targetState;
        this.referenceTemplate = template;
        //NB: cowSummoningRitual NEEDS TO BE INITIALIZED (in a second moment?)

    }


    //METHODS
    public void SetRitual(List<IndexedCow> listOfRelated)
    {
        this.cowSummoningRitual = listOfRelated;
    }



}
