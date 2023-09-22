using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPAlertSlide : AbstractMovementAlert
{
    //DATA
    ///TEMPLATE
    private readonly MPAlertSlideSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private float sameDirectionTimer;
    private bool canChangeDirection = true;

    private CowCollider cowColl = null;
    Vector3 slideDirection = Vector3.zero;

    

    //CONSTRUCTOR
    public MPAlertSlide(MPAlertSlideSO inputTemplate)
    {
        this.template = inputTemplate;
        this.sameDirectionTimer = inputTemplate.sameDirectionTimer;
    }


    ///TEMPLATE
    public override MPAbstractParentSO Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        //GET COLLIDER
        if(this.cowColl == null)
        {
            this.cowColl = interestedCow.gameObject.GetComponent<CowCollider>();
        }

        //REFLECT AGAINST COLLISION
        if (this.cowColl.HasCollided)
        {
            Vector3 collNormal = cowColl.GetCollisionData();
            Vector3 planarNormal = new Vector3(collNormal.x, 0, collNormal.z);

            slideDirection = Vector3.Reflect(slideDirection, planarNormal);
        }

        //HANDLE DIRECTION STUFF
        if (slideDirection == Vector3.zero || canChangeDirection)
        {
            //OR HANDLE DIRECTION STUFF
            slideDirection = interestedCow.transform.position - GameController.Instance.FindUFOAnywhere().GetPositionXZ();
            canChangeDirection = false;
        }

        //HANDLE TIMERS
        if (sameDirectionTimer <= 0) 
            ResetTimers();

        Debug.Log("MPAlertSlide - slideDirection: " + slideDirection);
        return slideDirection.normalized;
    }

    public override Vector3 ManagePanic(CowMovement myCow)
    {
        if (CowHideoutHelper.ShouldRunForHideout(myCow.CowScript))
            return CowHideoutHelper.HideoutDirection(myCow.CowScript).normalized;
        else
            return ManageMovement(myCow);
    }

    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        sameDirectionTimer -= delta;
    }
    public override void ResetTimers()
    {
        sameDirectionTimer = template.sameDirectionTimer;
        canChangeDirection = true;
    }
}
