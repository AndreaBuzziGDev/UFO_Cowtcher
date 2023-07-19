using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;


public class PlayerController : MonoBehaviour
{
    //DATA
    ///INPUT - EVENT-DRIVEN IMPLEMENTATION
    private PlayerInput Input = null;
    private Vector2 MovementInputFactor = new(0,0);


    ///POSITION ETC
    //TODO: SET INITIAL PLAYER POSITION PROGRAMMATICALLY
    //public Vector3 InitialPosition = new Vector3(-10, 0, 0);
    [SerializeField] private float MoveSpeed = 5;
    Rigidbody myRigidBody;

    ///OTHER DATA
    private float stunDuration = 0.0f;//NB: AFTER PROTOTYPE, REFACTOR THIS AS STATUS ALTERATION
    public bool IsStunned { get { return (stunDuration > 0); } }


    ///STATUS ALTERATION DATA
    private List<SAAbstract> statusAlterations = new();
    private float movSpeedBonus;





    //METHODS

    //...
    private void Awake()
    {
        Input = new PlayerInput();
        myRigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (stunDuration > 0) stunDuration -= Time.deltaTime;
        UpdateAlterationsTimers(Time.deltaTime);

        if (!GameController.Instance.IsPaused) Move(new Vector3(MovementInputFactor.x, 0, MovementInputFactor.y));
    }



    //
    private void OnEnable()
    {
        //ENABLE INPUT WHEN OBJECT ENABLED
        Input.Enable();

        //ACTION SUBSCRIPTIONS
        //MOVEMENT
        Input.Player.Movement.performed += OnMovementPerformed;
        Input.Player.Movement.canceled += OnMovementCanceled;


        //ESCAPE
        Input.Player.Escape.performed += OnEscapePerformed;

    }

    private void OnDisable()
    {
        //DISABLE INPUT WHEN OBJECT DISABLED
        Input.Disable();

        //MOVEMENT
        Input.Player.Movement.performed -= OnMovementPerformed;
        Input.Player.Movement.canceled -= OnMovementCanceled;


        //ESCAPE
        Input.Player.Escape.performed -= OnEscapePerformed;

    }


    //EVENT-BASED INPUT IMPLEMENTATION
    //MOVEMENT
    private void OnMovementPerformed(InputAction.CallbackContext value) => MovementInputFactor = value.ReadValue<Vector2>();
    private void OnMovementCanceled(InputAction.CallbackContext value) => MovementInputFactor = value.ReadValue<Vector2>();

    //ESCAPE
    private void OnEscapePerformed(InputAction.CallbackContext value) => GameController.Instance.helper.HandleEscInput();






    //FUNCTIONALITIES
    public void Move(Vector3 direction)
    {
        if (IsStunned)
        {
            myRigidBody.velocity = Vector3.zero;
        }
        else
        {
            myRigidBody.velocity = (1+(movSpeedBonus/100)) * MoveSpeed * (direction);
        }
    }

    public void ApplyStun(float inputDuration)
    {
        this.stunDuration = inputDuration;
    }

    public void AddStatusAlteration(SAAbstract newAlteration)
    {
        //TODO: REFACTOR AS DICTIONARY -> ONLY ONE TYPE AT A TIME (SUB-TODO: IMPLEMENT COMPARABLES SO THE BIGGER BUFF WINS)
        statusAlterations.Add(newAlteration);
        UIController.Instance.IGPanel.BuffPanel.fadeToTransparent = true;
    }

    private void UpdateAlterationsTimers(float delta)
    {
        List<SAAbstract> expired = new();
        foreach (SAAbstract alteration in statusAlterations)
        {
            alteration.UpdateTimers(delta);
            if (alteration.IsStillRunning())
            {
                alteration.ApplyBuff();
            }
            else
            {
                expired.Add(alteration);
            }
        }

        statusAlterations = statusAlterations.Except(expired).ToList();

        //HANDLE ALTERATIONS THAT NEED TO BE MANUALLY EXPIRED (NB: UNCLEAN CODE SOLUTION - BUT IT WORKS)
        Debug.Log("Expired Alterations count: " + expired.Count);
        foreach (SAAbstract alteration in expired)
        {
            alteration.ExpireBuff();
        }
    }

    public void SetBonusMovSpeed(float percentBonus)
    {
        movSpeedBonus = percentBonus;
    }

}
