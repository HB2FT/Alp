using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Entity
{
    private PlayerInput playerInput;
    private StateMachine stateMachine;

    Vector2 movementInput;
    Vector3 currentMovement;

    bool isMovementPressed;
    [SerializeField]
    bool jumpQuery;
    [SerializeField]
    bool isJumpPressed;
    bool isSlidePressed;
    bool isAttackPressed;

    [SerializeField]
    float runSpeed;

    private void FixedUpdate()
    {
        if (!IsDead)
        {
            bool isRunning = movementInput == Vector2.left || movementInput == Vector2.right;
            animator.SetBool("IsRunning", isRunning); // Set animation

            #region Movement

            if (movementInput == Vector2.right && !isRight)
            {
                Rotate();
            }

            if (movementInput == Vector2.left && isRight)
            {
                Rotate();
            }

            MovePlayer(speed); // Move player

            #endregion

            //
            // Jump
            //
            if (isJumpPressed)
            {
                if (IsGrounded)
                {
                    jumpQuery = true;
                }
                else if(rigidBody.velocity.y < 0)
                {
                    //jumpQuery = true;
                }
            }

            //
            // Jump
            //
            if (IsGrounded && jumpQuery)
            {
                rigidBody.AddForce(new Vector2(0f, jumpForce));
                jumpQuery = false;
            }

            if (jumpQuery)
            {
                rigidBody.AddForce(new Vector2(0f, jumpForce * Time.deltaTime));
                jumpQuery = false;
            }

            //
            // Slide
            //
            if (isSlidePressed && isMovementPressed) // Pressed slide while moving
            {
                if (stateMachine.CurrentState.GetType() != typeof(SlideState))
                {
                    stateMachine.SetNextState(new SlideState());

                    int rotation;
                    if (isRight)
                    {
                        rotation = 1;
                    }
                    else
                    {
                        rotation = -1;
                    }
                    rigidBody.AddForce(new Vector2(speed * 50 * rotation, 0));
                }

                isSlidePressed = false;
            }

            //
            // Attack
            //
            if (isAttackPressed)
            {
                //stateMachine.SetNextState(new GroundEntryState());
                isAttackPressed = false;
            }
        }
    }

    private void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.Player.Movement.started += Move; // On press
        playerInput.Player.Movement.performed += Move; // While pressing
        playerInput.Player.Movement.canceled += Move; // End press

        playerInput.Player.Slide.started += Slide; // On slide
        playerInput.Player.Slide.canceled += Slide; // End slide

        playerInput.Player.Jump.started += Jump; // On Jump
        playerInput.Player.Jump.performed += Jump; // While Jumping
        playerInput.Player.Jump.canceled += Jump; // End Jump
    }

    void Attack(InputAction.CallbackContext context)
    {
        isAttackPressed = context.ReadValueAsButton();
    }

    private void MovePlayer(float speed)
    {
        float _speed = speed;

        if (Gamepad.current != null)
        {
            if (Gamepad.current.leftStick.magnitude > 0.3f)
            {
                _speed *= Gamepad.current.leftStick.magnitude;
            }
        }

        transform.position += Time.deltaTime * _speed * currentMovement;
    }

    void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

        currentMovement.x = movementInput.x;
        currentMovement.y = movementInput.y;

        isMovementPressed = movementInput != Vector2.zero;
    }

    void Slide(InputAction.CallbackContext context)
    {
        isSlidePressed = context.ReadValueAsButton();
    }

    void Jump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
    }

    public override void Start()
    {
        base.Start();

        stateMachine = GetComponent<StateMachine>();
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    public override void OnCollisionExit2D(Collision2D collision)
    {
        base.OnCollisionExit2D(collision);
    }
}
