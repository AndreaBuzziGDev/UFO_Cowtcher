using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPAlertSlide : AbstractMovementAlert
{
    //DATA
    ///TEMPLATE
    private readonly MPAlertSlideSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    private Vector3 slideDirection = Vector3.zero;



    //CONSTRUCTOR
    public MPAlertSlide(MPAlertSlideSO inputTemplate)
    {
        this.template = inputTemplate;
    }


    ///TEMPLATE
    public override MPAbstractParentSO Template() => template;

    ///MOVEMENT
    public override Vector3 ManageMovement(CowMovement interestedCow)
    {
        //TODO: ONLY WHEN ENTERING THE ALERT STATE THE FIRST TIME THE COW STARTS FLEEING THE UFO
        if(slideDirection == Vector3.zero)
        {
            Vector3 menacePosition = GameController.Instance.FindUFOAnywhere().GetPositionXZ();
            slideDirection = interestedCow.transform.position - menacePosition;
        }

        //USE CowMovement OR Cow OR SOME OTHER SCRIPT TO DETECT IF A COLLISION HAPPENED, AND IF IT DID, USE IT TO CHANGE DIRECTION (SHOULD BOUNCE)
        //TODO: OPTIMIZE
        CowCollider cowMov = interestedCow.gameObject.GetComponent<CowCollider>();
        if (cowMov != null)
        {
            if (cowMov.HasCollided)
            {
                Debug.Log("MPAlertSlide - ManageMovement");
                //TODO: FINISH IMPLEMENTATION
                slideDirection = Vector3.Reflect(slideDirection, cowMov.GetCollisionData());
            }
        }

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
        //NOT NEEDED

    }
    public override void ResetTimers()
    {

    }
}
