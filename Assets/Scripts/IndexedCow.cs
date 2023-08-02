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

    private CowSO referenceTemplate;
    public CowSO ReferenceTemplate { get { return referenceTemplate; } }



    //CONSTRUCTOR
    public IndexedCow(CowKnowledgeState startingState, CowSO template)
    {
        this.state = startingState;
        this.referenceTemplate = template;
    }

    //METHODS
    public void ChangeState(CowKnowledgeState targetState)
    {
        //NB: MIGHT HOST FUTURE FUNCTIONALITY EXPANSIONS
        this.state = targetState;
    }

    public List<IndexedCow> RitualCows()
    {
        //TODO: HANDLE SUMMONING RITUAL NULL
        List<IndexedCow> relatedCows = Cowdex.Instance.GetIndexedCows(referenceTemplate.SummoningRitual.RequiredCows);

        //TODO: COWDEX MUST HANDLE THE ANY COW PROPERLY
        //      HANDLING OF THE "GENERICALLY-ALLOWED" COW TYPE HERE ?



        return relatedCows;
    }


}
