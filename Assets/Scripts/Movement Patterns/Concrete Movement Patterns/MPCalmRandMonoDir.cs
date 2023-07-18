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
        //TODO: HANDLE MOVEMENT STUFF HERE (timerStill, timerMoving)

        //TODO: EXPORT VECTOR LOGIC IN A DEDICATED METHOD?
        if (AllowedDirections == null || AllowedDirections.Count == 0)
        {
            return Vector3.zero;
        }

        return AllowedDirections[Random.Range(0, AllowedDirections.Count)];

    }


    ///TIMERS
    public override void UpdateTimers(float delta)
    {
        this.timerStill -= delta;
        this.timerMoving -= delta;
    }

    public override void ResetTimers()
    {
        this.timerStill = template.timerStill;
        this.timerMoving = template.timerMoving;
    }

}
