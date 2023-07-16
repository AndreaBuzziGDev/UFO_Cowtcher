using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideoutSlot
{
    //DATA
    public Cow HostedCow;
    public bool IsHosting { get { return (HostedCow != null); } }

    public float SlotPermanenceTimer;
    public bool CanSpawn { get { return (SlotPermanenceTimer <= 0.0f); } }


    //CONSTRUCTOR
    //NOT NEEDED


    //METHODS
    public void Host(Cow interestedCow)
    {
        this.HostedCow = interestedCow;
        interestedCow.gameObject.SetActive(false);
    }

    public Cow Vacate(float newPermanenceTimer)
    {
        SlotPermanenceTimer = newPermanenceTimer;

        Cow toVacate = HostedCow;
        HostedCow = null;

        Debug.Log("Cow to be Vacated: " + toVacate);

        return toVacate;
    }


}
