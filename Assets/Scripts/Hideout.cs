using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideout : MonoBehaviour
{
    //DATA
    [SerializeField] private HideoutSO hideoutTemplate;
    public HideoutSO HideoutTemplate { get { return hideoutTemplate; } }
    private UFO ufo;


    ///HIDEOUT SLOTS
    private List<HideoutSlot> hideoutSlots = new List<HideoutSlot>();
    public List<HideoutSlot> HideoutSlots { get { return hideoutSlots; } }


    ///TEMPLATE CLONED DATA
    private HideoutSO.Type type = 0;
    public HideoutSO.Type Type { get { return type; } }
    private int numberOfHideoutSlots;
    private float hideoutPermanenceTimer;
    private float spawnRadius = 2.5f;




    ///NO HIDEOUT VACATION IF UFO IS WITHIN DISTANCE:
    private Vector3 ufoDistanceXZ = Vector3.zero;
    private float ufoDetectionRadius;


    ///SHAKE VARIABLES
    [Header("Shake Settings")]
    [SerializeField] private float shakeAmount;
    [SerializeField] private float shakeSpeed;
    [SerializeField] private float shakeTime;

    private bool shake = false;
    private float currentShakeTime;
    private Vector3 hideoutPosition;



    ///DEBUG FIELDS
    //TODO: DELETE
    [Header("Debug")]
    [SerializeField] private int debugNumAvailSlots;




    //METHODS
    //...
    private void Awake()
    {
        //DATA CLONED FROM SCRIPTABLE HIDEOUT
        type = hideoutTemplate.type;
        numberOfHideoutSlots = hideoutTemplate.numberOfHideoutSlots;
        hideoutPermanenceTimer = hideoutTemplate.HideoutPermanenceTimer;
        spawnRadius = hideoutTemplate.spawnRadius;

        ufoDetectionRadius = hideoutTemplate.UFODetectionRadius;

        //UFO
        ufo = FindObjectOfType<UFO>();
        if (ufo != null) ufoDistanceXZ = new Vector3(ufo.transform.position.x, this.transform.position.y, ufo.transform.position.z);

        //HANDLE CONSTRUCTION OF hideoutSlots
        InitalizeHideoutSlots();

        currentShakeTime = shakeTime;
        hideoutPosition = this.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        int availSlots = 0;

        //TODO: EXPORT AS DEDICATED FUNCTIONALITY (updateHideoutSlot Timers and Statuses)
        ufoDistanceXZ = new Vector3(ufo.transform.position.x, this.transform.position.y, ufo.transform.position.z);

        for (int i = 0; i < hideoutSlots.Count; i++)
        {
            if (!IsUFONear() && hideoutSlots[i].HostedCow != null)
            {
                hideoutSlots[i].SlotPermanenceTimer -= Time.deltaTime;

                if (hideoutSlots[i].CanSpawn)
                {
                    Cow respawnedCow = hideoutSlots[i].Vacate(hideoutPermanenceTimer);
                    VacateHideout(respawnedCow);

                }
            }

            //COUNT SLOTS THAT ARE AVAILABLE
            if (hideoutSlots[i].HostedCow == null)
            {
                availSlots++;
            }
        }

        if (shake)
        {
            currentShakeTime -= Time.deltaTime;
            AnimateHideout();
        }

        if (currentShakeTime <= 0)
        {
            currentShakeTime = shakeTime;
            shake = false;
            transform.position = hideoutPosition;
        }


        //UPDATE COUNT SLOTS THAT ARE AVAILABLE
        debugNumAvailSlots = availSlots;

    }




    //INITIALIZATION
    private void InitalizeHideoutSlots()
    {
        for (int i = 0; i < numberOfHideoutSlots; i++)
        {
            hideoutSlots.Add(new HideoutSlot());
        }

        for (int i = 0; i < hideoutSlots.Count; i++)
        {
            hideoutSlots[i].SlotPermanenceTimer = hideoutPermanenceTimer;
        }
    }


    //VACATE HIDEOUT
    private void VacateHideout(Cow interestedCow)
    {
        Vector3 newCowPosition = UtilsRadius.Vector3OnUnitCircle(spawnRadius) + transform.position;
        interestedCow.transform.position = newCowPosition;
        interestedCow.gameObject.SetActive(true);
    }



    //FUNCTIONALITIES
    public bool HasAvailableSlots()
    {
        int numOfAvailableSlots = 0;

        for (int i = 0; i < hideoutSlots.Count; i++)
        {
            if (!hideoutSlots[i].IsHosting)
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

    public void Host(Cow interestedCow)
    {
        foreach(HideoutSlot slot in hideoutSlots)
        {
            if (!slot.IsHosting)
            {
                slot.Host(interestedCow);
                shake = true;
                break;
            }
        }
    }


    //JUICYNESS
    private void AnimateHideout()
    {
        hideoutPosition = this.transform.position;
        transform.position = new Vector3(transform.position.x + Mathf.Sin(Time.time * shakeSpeed) * shakeAmount, transform.position.y, transform.position.z);
    }



    //DEBUGGING & TOOLING
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
#endif

}
