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



    //CONSTRUCTOR
    public IndexedCow(CowKnowledgeState startingState, ScriptableCow template)
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
        List<IndexedCow> relatedCows = new();

        //TODO: IMPLEMENT MASS RETRIEVAL FUNCTIONALITY IN COWDEX INSTEAD?
        foreach (ScriptableCow.UniqueID UID in referenceTemplate.SummoningRitual.RequiredCows)
        {
            relatedCows.Add(Cowdex.Instance.GetIndexedCow(UID));
        }

        //TODO: COWDEX MUST HANDLE THE ANY COW PROPERLY
        //      HANDLING OF THE "GENERICALLY-ALLOWED" COW TYPE HERE ?



        return relatedCows;
    }


}
