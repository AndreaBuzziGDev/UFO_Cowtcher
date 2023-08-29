using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoInteractible
{
    //DATA
    ///STATUS ALTERATION
    [SerializeField] private SAAbstractSO Alteration;

    ///LIFETIME
    [SerializeField] private float lifetimeMax = 10.0f;
    private float lifetimeCurrent;

    ///EXPIRATION
    [SerializeField] private float expirationTimeMax = 1.0f;
    private float expireTimeCurrent;
    private bool hasBegunExpiration;

    ///SPRITE RENDERER REFERENCES
    [SerializeField] private SpriteRenderer buffIconRenderer;


    ///JUICYNESS STUFF
    ///SHAKE VARIABLES
    [Header("Shake Settings")]
    [SerializeField] private float shakeAmount;
    [SerializeField] private float shakeSpeed;




    //METHODS
    //...
    private void Start()
    {
        lifetimeCurrent = lifetimeMax;
    }

    // Update is called once per frame
    void Update()
    {
        AnimateItemPickup();

        HandleLifetime();

    }


    //IMPLEMENTING IInteractible

    public override void Interact(GameObject interactionSource)
    {
        //CAN BE INTERACTED ONLY IF IT'S NOT EXPIRING
        if (expireTimeCurrent <= 0)
        {
            //DELIVER BUFF TO THE PLAYER UFO
            GameController.Instance.FindPlayerAnywhere().AddStatusAlteration(this.GetStatusAlteration());

            //DESTROY PICKED UP ITEM
            Destroy(this.gameObject);//TODO: POSSIBLE CHANGE SO THAT THIS DISAPPEARS GRADUALLY...
        }
    }



    //FUNCTIONALITIES
    public SAAbstract GetStatusAlteration()
    {
        return Alteration.GetBuff();
    }


    //SPAWN ITEM
    ///SPAWN ON DEFINED POSITION
    public void Spawn(Vector3 intendedPosition)
    {
        this.transform.position = intendedPosition;
        this.gameObject.SetActive(true);
    }

    ///SPAWN ITEM RANDOMLY ON SPAWN GRID
    public void SpawnRandomly()
    {
        SpawningGrid.Instance.SpawnObjectInsideGrid(this);
    }




    //JUICYNESS
    ///ANIMATION
    private void AnimateItemPickup()
    {

        transform.position = new Vector3(
            transform.position.x,
            0.5f + Mathf.Sin(Time.unscaledTime * shakeSpeed) * shakeAmount,
            transform.position.z
            );

    }


    ///LIFETIME
    private void HandleLifetime()
    {
        if(lifetimeCurrent > 0)
        {
            lifetimeCurrent -= Time.deltaTime;
        }
        else
        {
            if (!hasBegunExpiration)
            {
                Destroy(this.gameObject, expirationTimeMax);
                expireTimeCurrent = expirationTimeMax;
                hasBegunExpiration = true;
            }
        }

        if (expireTimeCurrent > 0)
        {
            //HANDLE GRADUAL TRANSPARENCY
            expireTimeCurrent -= Time.deltaTime;
            float factor = expireTimeCurrent / expirationTimeMax;

            //TODO: CHANGE WITH COLOR LERP
            Color buffSpriteColor = new Color(buffIconRenderer.color.r, buffIconRenderer.color.g, buffIconRenderer.color.b, factor);
            buffIconRenderer.color = buffSpriteColor;

        }

    }


}
