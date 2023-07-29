using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SprintCaptureController : MonoBehaviour
{
    //DATA
    ///INPUT - EVENT-DRIVEN IMPLEMENTATION
    private PlayerInput InputSprint = null;

    ///PULSE MANAGEMENT
    [SerializeField] private float speedMult = 5;
    [SerializeField] private float pauseTimerMax = 1.0f;
    private float pauseTimer = 0;

    private Vector2 SprintInputFactor = new(0, 0);




    ///RIGIDBODY
    Rigidbody myRigidBody;

    ///SPRINT AFTER CAPTURE
    bool isSprinting = false;


    //METHODS
    //...
    private void Awake()
    {
        myRigidBody = this.gameObject.GetComponent<Rigidbody>();
    }



    private void Start()
    {
        InputSprint = GameController.Instance.FindPlayerAnywhere().InputPlayer;

        //ACTION SUBSCRIPTIONS
        //MOVEMENT
        InputSprint.Player.Movement.performed += OnMovementPerformed;
        InputSprint.Player.Movement.canceled += OnMovementCanceled;

        //JOYSTICK
        //Input.Player.ScreenTouch.started += OnScreenTouched;
        //Input.Player.ScreenTouch.canceled += OnScreenReleased;

    }


    private void Update()
    {
        Debug.Log("SprintCaptureController - pauseTimer" + pauseTimer);

        if(pauseTimer > 0)
        {
            pauseTimer -= Time.unscaledDeltaTime;
        }
        
        if(isSprinting && pauseTimer <= 0)
        {
            HandleSprint();
        }

    }



    //ENABLE/DISABLE
    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        //MOVEMENT
        InputSprint.Player.Movement.performed -= OnMovementPerformed;
        InputSprint.Player.Movement.canceled -= OnMovementCanceled;

        //JOYSTICK
        //Input.Player.ScreenTouch.started -= OnScreenTouched;
        //Input.Player.ScreenTouch.canceled -= OnScreenReleased;

    }



    //MOVEMENT
    private void OnMovementPerformed(InputAction.CallbackContext value) {

        SprintInputFactor = value.ReadValue<Vector2>();
    }
    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        SprintInputFactor = value.ReadValue<Vector2>();
    }

    private void HandleSprint()
    {
        //ON INPUT LEAVE = UNPAUSE
        isSprinting = false;
        Time.timeScale = 1;

        //ADD IMPULSE TO GAMEOBJECT RIGIDBODY
        //SprintInputFactor
        Vector3 direction = (new Vector3(SprintInputFactor.x, 0, SprintInputFactor.y)).normalized;

        GameController.Instance.FindPlayerAnywhere().AddSprintPulse(speedMult * direction);
    }



    //FUNCTIONALITIES
    public void SetCaptureSprint()
    {
        //sprintCaptureTimer = sprintCaptureTimerMax;
        isSprinting = true;
        pauseTimer = pauseTimerMax;
        Time.timeScale = 0;
    }

}
