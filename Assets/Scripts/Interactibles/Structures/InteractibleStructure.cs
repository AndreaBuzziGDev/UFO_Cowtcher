using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleStructure : MonoInteractible
{
    //DATA
    ///DEPLETION
    private bool hasBeenDepleted = false;
    public bool HasBeenDepleted { get { return hasBeenDepleted; } set { hasBeenDepleted = value; } }

    ///ACTIVATION
    private bool hasBeenActivated = false;
    public bool HasBeenActivated { get { return hasBeenActivated; } }

    ///AUDIO SOURCE
    [SerializeField] private AudioSource activationSound;

    ///SPRITE REFERENCES
    [SerializeField] private Sprite turnedOffPedestalSprite;
    [SerializeField] private Sprite turnedOnPedestalSprite;

    [SerializeField] private Sprite turnedOnIconSprite;

    ///SPRITE RENDERER REFERENCES
    [SerializeField] private SpriteRenderer childPedestalRenderer;
    [SerializeField] private SpriteRenderer childIconRenderer;
    private bool turnedOn;


    ///STRUCTURE DATA
    [SerializeField] private StructureAbstractSO StructureScriptableObject;
    StructureAbstract myStructure;

    ///JUICYNESS STUFF
    ///EXPIRATION PARTICLES
    [SerializeField] private GameObject expirationSubComponent;
    private bool hasBegunExpiration;

    ///EXPIRATION DATA
    [SerializeField] private float expirationTimeMax = 3.0f;
    private float expireTimeCurrent;

    ///LIFETIME
    [SerializeField] private float lifetimeMax = 20.0f;
    private float lifetimeCurrent;



    ///PARTICLES FOR REFUELING TOWER
    [SerializeField] private FuelParticleGeneration particleGen;
    public FuelParticleGeneration ParticleGen { get { return particleGen; } }



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        childPedestalRenderer.sprite = turnedOffPedestalSprite;
        expirationSubComponent.SetActive(false);

        lifetimeCurrent = lifetimeMax;
        if (StructureScriptableObject != null) myStructure = StructureScriptableObject.GetStructure();
        else Debug.LogError("Structure " + this.gameObject.name + " is missing Data. Assign Scriptable Object.");
    }

    // Update is called once per frame
    void Update()
    {
        //HANDLE THE STRUCTURE'S LOGIC
        if (hasBeenDepleted)
        {
            ExpireStructure();
        }

        HandleLifetime();

    }



    //FUNCTIONALITIES

    ///ENABLE TURRET



    ///INTERACT
    public override void Interact(GameObject interactionSource)
    {
        //ACTIVATE TURRET ON INTERACTION
        if (!hasBeenActivated)
        {
            activationSound.Play();
            hasBeenActivated = true;
        }

        //CAN BE INTERACTED ONLY IF IT'S NOT EXPIRING
        if (expireTimeCurrent <= 0)
        {
            //IF SOURCE UFO
            if (IsObjectWithinOperativeRadius(interactionSource))
            {
                if (!hasBeenDepleted)
                {
                    myStructure.DoBehaviour(this);
                }
            }

            //CHANGE SPRITE FOR ACTIVATION
            if (!turnedOn)
            {
                childPedestalRenderer.sprite = turnedOnPedestalSprite;
                childIconRenderer.sprite = turnedOnIconSprite;
                turnedOn = true;
            }
        }
    }



    //UTILITIES
    public bool IsObjectWithinOperativeRadius(GameObject within)
    {
        Vector3 basePosition = new Vector3(within.transform.position.x, 0, within.transform.position.z);
        float distance = (this.transform.position - basePosition).magnitude;
        return distance < myStructure.OperativeRadius;
    }


    //JUICYNESS
    ///EXPIRATION
    private void ExpireStructure()
    {
        //PARTICLE EMISSION
        if (!hasBegunExpiration)
        {
            //START EXPIRATION EFFECT
            if(expirationSubComponent != null) expirationSubComponent.SetActive(true);

            //DESTROY EXPIRED STRUCTURE
            Destroy(this.gameObject, expirationTimeMax);
            expireTimeCurrent = expirationTimeMax;
            hasBegunExpiration = true;
        }


    }

    ///LIFETIME
    private void HandleLifetime()
    {
        if (lifetimeCurrent > 0)
        {
            lifetimeCurrent -= Time.deltaTime;
        }
        else if (!hasBegunExpiration)
        {
            ExpireStructure();
        }

        //HANDLE TRANSPARENCY
        if (expireTimeCurrent > 0)
        {
            //HANDLE GRADUAL TRANSPARENCY
            expireTimeCurrent -= Time.deltaTime;
            float factor = expireTimeCurrent / expirationTimeMax;

            //TODO: CHANGE WITH COLOR LERP
            Color pedestalColor = new Color(childPedestalRenderer.color.r, childPedestalRenderer.color.g, childPedestalRenderer.color.b, factor);
            Color iconColor = new Color(childIconRenderer.color.r, childIconRenderer.color.g, childIconRenderer.color.b, factor);

            childPedestalRenderer.color = pedestalColor;
            childIconRenderer.color = iconColor;
        }

    }


}
