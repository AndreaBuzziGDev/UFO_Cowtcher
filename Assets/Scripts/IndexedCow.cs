using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexedCow
{
    //DATA
    public SaveInfoCow.Knowledge KnowledgeState { get { return SaveSystem.LoadCowProgress(ReferenceTemplate.UID).KnowledgeValue; } }

    private Cow prefabCow;
    public Cow PrefabCow { get { return prefabCow; } }
    public CowSO ReferenceTemplate { get { return prefabCow.CowTemplate; } }



    //CONSTRUCTOR
    public IndexedCow(Cow referenceCow)
    {
        this.prefabCow = referenceCow;
    }

}
