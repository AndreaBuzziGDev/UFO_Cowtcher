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


    private List<IndexedCow> cowSummoningRitual;
    public List<IndexedCow> CowSummoningRitual { get { return cowSummoningRitual; } }


    //METHODS




}
