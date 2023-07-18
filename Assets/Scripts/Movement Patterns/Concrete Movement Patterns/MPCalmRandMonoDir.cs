using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Random Mono Direction", menuName = "MovementPattern/Calm/Random Mono Direction")]
public class MPCalmRandMonoDir : AbstractMovementPattern
{
    //DATA
    ///TEMPLATE
    private readonly MPCalmRandMonoDirSO template;

    ///ACTUALLY USEFUL DATA FOR MOVEMENT PATTERN
    [SerializeField] public float timerStill;
    [SerializeField] public float timerMoving;
    [SerializeField] public List<Vector3> AllowedDirections = new();
    private Vector3 randomlyChosenDirection;



    //CONSTRUCTOR
    public MPCalmRandMonoDir(MPCalmRandMonoDirSO inputTemplate)
    {
        this.template = inputTemplate;
        this.AllowedDirections = inputTemplate.AllowedDirections;
        ResetTimers();
    }

    //METHODS

    ///TEMPLATE
    public override IMovementPattern Template() => template;


    ///MOVEMENT
    public override Vector3 ManageMovement(Cow interestedCow)
    {
        Debug.Log("timerStill: " + timerStill);
        Debug.Log("timerMoving: " + timerMoving);

        Vector3 result = Vector3.zero;
        if (timerMoving > 0) return randomlyChosenDirection;
        return result;
    }


    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        if (timerMoving > 0) timerMoving -= delta;
        else if (timerStill > 0) timerStill -= delta;
        else ResetTimers();
    }

    public override void ResetTimers()
    {
        this.timerStill = template.timerStill;
        this.timerMoving = template.timerMoving;

        if (AllowedDirections != null || AllowedDirections.Count > 0) randomlyChosenDirection = AllowedDirections[Random.Range(0, AllowedDirections.Count)];
    }

}
