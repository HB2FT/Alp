using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private _Player player;

    private PlayerInput playerInput;
    private StateMachine stateMachine;

    Vector2 movementInput;
    Vector3 currentMovement;

    bool isMovementPressed;
    [SerializeField] bool jumpQuery;
    [SerializeField] bool isJumpPressed;
    bool isSlidePressed;
    bool isAttackPressed;
    bool isRunning;

    [SerializeField] int itemIndex;
    const int MAX_ITEM_INDEX = 2;

    public void Start()
    {
        player = GetComponentInParent<_Player>();
        stateMachine = GetComponent<StateMachine>();

        itemIndex = 0;
    }

    private void Update()
    {
        if (!player.IsDead)
        {
            //bool isRunning = movementInput == Vector2.left || movementInput == Vector2.right;
            




            HandleMovement();

            HandleJump();

            HandleSlide();

            HandleAttak();

            UpdateAnimator();
        }
    }

    private void UpdateAnimator()
    {
        player.Animator.SetBool("IsRunning", isRunning); // Set animation
    }

    private void HandleAttak()
    {
        //
        // Attack
        //
        if (isAttackPressed)
        {
            //stateMachine.SetNextState(new GroundEntryState());
            isAttackPressed = false;
        }
    }

    private void HandleSlide()
    {
        //
        // Slide
        //
        if (isSlidePressed && isMovementPressed) // Pressed slide while moving
        {
            if (stateMachine.CurrentState.GetType() != typeof(SlideState))
            {
                stateMachine.SetNextState(new SlideState());

                int rotation;
                if (player.isRight)
                {
                    rotation = 1;
                }
                else
                {
                    rotation = -1;
                }
                player.Rigidbody.AddForce(new Vector2(player.Speed * rotation, 0), ForceMode2D.Impulse);
            }

            isSlidePressed = false;
        }
    }

    private void HandleJump()
    {
        //
        // Jump query
        //
        if (isJumpPressed)
        {
            if (player.IsGrounded || player.Rigidbody.velocity.y < -5)
            {
                jumpQuery = true;
            }

            isJumpPressed = false;
        }

        //
        // Jump
        //
        if (player.IsGrounded && jumpQuery)
        {
            player.Rigidbody.AddForce(new Vector2(0f, player.jumpForce));
            jumpQuery = false;
        }
    }

    private void HandleMovement()
    {
        #region rotation
        if (movementInput == Vector2.right && !player.isRight)
        {
            player.Rotate(); Debug.Log("Rotate right");
        }

        if (movementInput == Vector2.left && player.isRight)
        {
            player.Rotate(); Debug.Log("Rotate right");
        }
        #endregion

        isRunning = currentMovement != Vector3.zero;// handle is running

        float _speed = player.Speed;

        if (Gamepad.current != null)
        {
            if (Gamepad.current.leftStick.magnitude > 0.3f)
            {
                _speed *= Gamepad.current.leftStick.magnitude;
            }
        }

        if (player.canMove || true)
        {
            player.transform.position += currentMovement * _speed * Time.deltaTime;
        }

        //player.Rigidbody.velocity = new Vector3(_speed * currentMovement.x, player.Rigidbody.velocity.y);
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
        playerInput.Player.Jump.canceled += Jump; // End Jump

        //playerInput.Player.ItemIndex.started += OnItemChanged; // On item change
    }

    void OnItemChanged(InputAction.CallbackContext context)
    {
        Vector2 vector = context.ReadValue<Vector2>();

        int i = (int) vector.y;

        ChangeIndex(i);
    }

    void ChangeIndex(int i)
    {
        if (itemIndex >= 0 && itemIndex <= MAX_ITEM_INDEX)
        {
            itemIndex += i;
            player.ItemIndex = itemIndex;
        }

        if (itemIndex > MAX_ITEM_INDEX) itemIndex = MAX_ITEM_INDEX;
        if (itemIndex < 0) itemIndex = 0;
    }

    void Attack(InputAction.CallbackContext context)
    {
        isAttackPressed = context.ReadValueAsButton();
    }

    [Obsolete("Codes moved to HandleInput method")]
    private void MovePlayer(float speed)
    {
        
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

    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }
}
