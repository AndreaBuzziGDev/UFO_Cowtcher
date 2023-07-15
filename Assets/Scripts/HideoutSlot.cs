using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideoutSlot
{
    //DATA
    public Cow HostedCow;
    public bool IsHosting { get { return (HostedCow != null); } }

    public float SlotPermanenceTimer;
    public bool CanSpawn = false;


    //CONSTRUCTOR
    //NOT NEEDED


    //METHODS
    public void Host(Cow interestedCow)
    {
        this.HostedCow = interestedCow;
        interestedCow.gameObject.SetActive(false);
    }

    public Cow Vacate()
    {
        Cow toVacate = HostedCow;
        HostedCow = null;
        CanSpawn = false;

        Debug.Log("Cow to be Vacated: " + toVacate);

        return toVacate;
    }


}
