using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideout : MonoBehaviour
{
    //DATA
    [SerializeField] private ScriptableHideout hideoutTemplate;
    public ScriptableHideout HideoutTemplate { get { return hideoutTemplate; } }

    [SerializeField] private UFO ufo;


    private List<HideoutSlot> hideoutSlots = new List<HideoutSlot>();

    ///TEMPLATE CLONED DATA
    private ScriptableHideout.Type type = 0;
    public ScriptableHideout.Type Type { get { return type; } }

    private int numberOfHideoutSlots;
    private float hideoutPermanenceTimer;
    private float ufoDetectionRadius;

    private Vector3 ufoDistanceXZ = Vector3.zero;


    //METHODS
    //...

    private void Awake()
    {
        //DATA CLONED FROM SCRIPTABLE HIDEOUT
        type = hideoutTemplate.type;
        numberOfHideoutSlots = hideoutTemplate.numberOfHideoutSlots;
        hideoutPermanenceTimer = hideoutTemplate.HideoutPermanenceTimer;
        ufoDetectionRadius = hideoutTemplate.UFODetectionRadius;

        //GET THE POSITION OF THE UFO AT THE HEIGHT OF THE HIDEOUT
        ufoDistanceXZ = new Vector3(ufo.transform.position.x, this.transform.position.y, ufo.transform.position.z);

        //HANDLE CONSTRUCTION OF hideoutSlots
        InitalizeHideoutSlots();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ufoDistanceXZ = new Vector3(ufo.transform.position.x, this.transform.position.y, ufo.transform.position.z);

        for (int i = 0; i < hideoutSlots.Count; i++)
        {
            if (!IsUFONear() && hideoutSlots[i].HostedCow != null)
            {
                hideoutSlots[i].SlotPermanenceTimer -= Time.deltaTime;

                if (hideoutSlots[i].SlotPermanenceTimer <= 0)
                {
                    hideoutSlots[i].CanSpawn = true;
                    hideoutSlots[i].SlotPermanenceTimer = hideoutTemplate.HideoutPermanenceTimer;
                    //REMEMBER TO PUT "CanSpawn" BACK TO FALSE AND SET ITS COW TO NULL WHEN THE COW IS SPAWNED
                }
            }
        }
    }



    //FUNCTIONALITIES
    public bool HasAvailableSlots()
    {
        int numOfAvailableSlots = 0;

        for (int i = 0; i < hideoutSlots.Count; i++)
        {
            if (hideoutSlots[i].HostedCow != null)
            {
                numOfAvailableSlots++;
            }
        }

        return (numOfAvailableSlots > 0);
    }

    //MADE IT PUBLIC BECAUSE SOME RITUALS NEED TO KNOW IF A COW WAS TAKEN NEAR A HIDEOUT
    public bool IsUFONear()
    {
        float distanceFromUFO = Vector3.Distance(transform.position, ufoDistanceXZ);

        //Debug.Log("UFO distance in range: " + (distanceFromUFO <= ufoDetectionRadius));
        return (distanceFromUFO <= ufoDetectionRadius);
    }

    private void InitalizeHideoutSlots()
    {
        for (int i = 0; i <= numberOfHideoutSlots; i++)
        {
            hideoutSlots.Add(new HideoutSlot());
        }

        for (int i = 0; i < hideoutSlots.Count; i++)
        {
            hideoutSlots[i].SlotPermanenceTimer = hideoutPermanenceTimer;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, ufoDetectionRadius);
    }
#endif
}
