using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideout : MonoBehaviour
{
    //DATA
    ///TEMPLATE
    [SerializeField] private HideoutSO hideoutTemplate;
    public HideoutSO HideoutTemplate { get { return hideoutTemplate; } }

    ///HIDEOUT INFOS
    [SerializeField] private HideoutInfos myInfos;


    ///UFO
    private UFO playerUFO;


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
    [SerializeField] private float altShakeTime;

    private bool shake = false;
    private bool altShake = false;
    private Vector3 hideoutPosition;




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

        //HANDLE CONSTRUCTION OF hideoutSlots
        InitalizeHideoutSlots();

        //SETTING SHAKING
        hideoutPosition = this.transform.position;

        //


    }

    // Start is called before the first frame update
    void Start()
    {
        //UFO
        playerUFO = GameController.Instance.FindUFOAnywhere();
        if (playerUFO != null) ufoDistanceXZ = new Vector3(playerUFO.transform.position.x, 0, playerUFO.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int availSlots = 0;

        ufoDistanceXZ = playerUFO.GetPositionXZ();

        //HIDEOUT SLOTS LOGIC
        for (int i = 0; i < hideoutSlots.Count; i++)
        {
            if (hideoutSlots[i].HostedCow != null)
            {
                //TODO: COROUTINE-IFY?
                hideoutSlots[i].SlotPermanenceTimer -= Time.deltaTime;

                if (hideoutSlots[i].CanSpawn)
                {
                    if (IsUFONear())
                    {
                        //ALTERNATIVE SHAKING
                        if(!altShake) StartCoroutine(AltShakeRoutine());
                    }
                    else
                    {
                        Cow respawnedCow = hideoutSlots[i].Vacate(hideoutPermanenceTimer);
                        VacateHideout(respawnedCow);
                    }
                }
            }

            //COUNT SLOTS THAT ARE AVAILABLE
            if (hideoutSlots[i].HostedCow == null)
            {
                availSlots++;
            }
        }

        //UPDATE INFOS
        if(myInfos != null) myInfos.UpdateCounter(numberOfHideoutSlots-availSlots, numberOfHideoutSlots);

        //ANIMATE SHAKING
        if (shake) HideoutShakeHorizontal();
        else if (altShake) HideoutShakeVertical();
    }




    //INITIALIZATION
    private void InitalizeHideoutSlots()
    {
        for (int i = 0; i < numberOfHideoutSlots; i++) hideoutSlots.Add(new HideoutSlot());
        for (int i = 0; i < hideoutSlots.Count; i++) hideoutSlots[i].SlotPermanenceTimer = hideoutPermanenceTimer;
    }


    //VACATE HIDEOUT
    private void VacateHideout(Cow interestedCow)
    {
        Vector3 newCowPosition = UtilsRadius.RandomPositionOnCircleRadius(spawnRadius) + transform.position;
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
                StartCoroutine(ShakeRoutine());
                break;
            }
        }
    }


    //JUICYNESS
    private void HideoutShakeHorizontal()
    {
        transform.position = new Vector3(transform.position.x + Mathf.Sin(Time.fixedUnscaledTime * shakeSpeed) * shakeAmount, transform.position.y, transform.position.z);
    }

    private void HideoutShakeVertical()
    {
        //TODO: EVALUATE LESS INTENSE VERTICAL SHAKE AND ONLY UPWARDS SHAKE (NO BELOW GROUND)
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.fixedUnscaledTime * shakeSpeed) * shakeAmount, transform.position.z);
    }



    //COROUTINES
    ///HORIZONTAL SHAKE WHEN A NEW COW IS HOSTED
    private IEnumerator ShakeRoutine()
    {
        //FUNCTIONALITIES
        myInfos.HandleHost();

        //SHAKE
        shake = true;

        //WAIT
        yield return new WaitForSeconds(shakeTime);

        //STOP SHAKE
        transform.position = hideoutPosition;
        shake = false;
    }

    ///VERTICAL SHAKE WHEN A COW IS AFRAID OF GOING OUTSIDE
    private IEnumerator AltShakeRoutine()
    {
        //SHAKE
        altShake = true;

        //WAIT
        yield return new WaitForSeconds(altShakeTime);

        //STOP SHAKE
        transform.position = hideoutPosition;
        altShake = false;
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
