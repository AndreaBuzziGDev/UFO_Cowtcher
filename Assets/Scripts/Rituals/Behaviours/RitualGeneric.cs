using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualGeneric : RitualAbstract
{
    //DATA
    RitualGenericSO template;


    //CONSTRUCTOR
    public RitualGeneric(RitualGenericSO inputTemplate)
    {
        this.template = inputTemplate;
        requiredCows = template.RequiredCows;
    }

    //METHODS

    public override void DoRitual(ScriptableCow.UniqueID UID)
    {
        Debug.Log("RitualGeneric - Increasing counter for Cow: " + UID);

        CowSummoningRitualModule module = ritualDictionary[UID];
        module.ChangeAmount(1);

        //ALSO INCREASE "ANY" COUNTER.
        if (HasCow(ScriptableCow.UniqueID.ANY))
        {
            Debug.Log("RitualGeneric - ALSO Increasing counter for Cow: " + ScriptableCow.UniqueID.ANY);
            ritualDictionary[ScriptableCow.UniqueID.ANY].ChangeAmount(1);
        }

    }
}
