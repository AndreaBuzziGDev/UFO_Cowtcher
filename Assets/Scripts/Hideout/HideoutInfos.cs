using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideoutInfos : MonoBehaviour
{
    //DATA
    ///PARENT REFERENCE
    [SerializeField] private Hideout parentHideout;

    ///UI REFERENCE
    [SerializeField] private SpriteRenderer cowLogo;
    [SerializeField] private TMPro.TextMeshProUGUI hideoutCounter;



    //METHODS
    //FUNCTIONALITIES
    public void UpdateCounter(int currentCount, int maxCapacity) => hideoutCounter.text = currentCount + "/" + maxCapacity;

}
