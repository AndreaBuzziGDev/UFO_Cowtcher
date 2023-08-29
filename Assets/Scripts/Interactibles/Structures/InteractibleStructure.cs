using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleStructure : MonoInteractible
{
    //DATA
    ///
    private bool hasBeenDepleted = false;
    public bool HasBeenDepleted { get { return hasBeenDepleted; } set { hasBeenDepleted = value; } }

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
    ///PARTICLES
    [SerializeField] private ParticleSystem ExpirationParticles;
    private bool hasPlayedExpirationParticles;

    ///LIFETIME
    [SerializeField] private float lifetimeMax = 20.0f;
    private float lifetimeCurrent;



    //METHODS
    //...

    // Start is called before the first frame update
    void Start()
    {
        childPedestalRenderer.sprite = turnedOffPedestalSprite;

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
        //IF SOURCE UFO
        if (IsObjectWithinOperativeRadius(interactionSource))
        {
            Debug.Log("hasBeenDepleted: " + hasBeenDepleted);
            //TODO: SHOULD BE REFACTORED TO INTERVIEW THE StructureAbstract OBJECT, IN ORDER TO ALLOW DIFFERENT BEHAVIOURS
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
        if (!hasPlayedExpirationParticles && ExpirationParticles != null)
        {
            ParticleSystem expirationParticlesInstance = Instantiate(ExpirationParticles, transform.position + new Vector3(0,1,0), Quaternion.identity);
            expirationParticlesInstance.Play();
            Destroy(expirationParticlesInstance.gameObject, 3.0f);

            hasPlayedExpirationParticles = true;
        }

        //DESTROY EXPIRED STRUCTURE
        Destroy(this.gameObject, 3.0f);

    }

    ///LIFETIME
    private void HandleLifetime()
    {
        if (lifetimeCurrent > 0)
        {
            lifetimeCurrent -= Time.deltaTime;
        }
        else
        {
            ExpireStructure();
        }
    }


}
