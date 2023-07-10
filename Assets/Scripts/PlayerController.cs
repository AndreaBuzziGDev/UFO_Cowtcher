using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //DATA
    
    //INPUT - EVENT-DRIVEN IMPLEMENTATION
    private PlayerInput Input = null;
    private Vector2 MovementInputFactor = new(0,0);


    //POSITION ETC

    //TODO: SET INITIAL PLAYER POSITION PROGRAMMATICALLY
    //public Vector3 InitialPosition = new Vector3(-10, 0, 0);
    [SerializeField] private float MoveSpeed = 5;
    Rigidbody myRigidBody;






    //METHODS

    //...
    private void Awake()
    {
        Input = new PlayerInput();
        myRigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    /*
    void Start()
    {
        
    }
    */

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */

    private void FixedUpdate()
    {
        
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
    private void OnEscapePerformed(InputAction.CallbackContext value)
    {
        if (GameController.Instance.IsPaused)
        {
            GameController.Instance.SetState(GameController.EGameState.Playing);
        }
        else
        {
            GameController.Instance.SetState(GameController.EGameState.Paused);
        }
    }






    //FUNCTIONALITIES
    public void Move(Vector3 direction) => myRigidBody.velocity = (direction) * MoveSpeed;

}
