using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    public _Player player;

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
    int itemIndex;
    const int MAX_ITEM_INDEX = 2;
    

    private void FixedUpdate()
    {
        if (!player.IsDead)
        {
            bool isRunning = movementInput == Vector2.left || movementInput == Vector2.right;
            player.Animator.SetBool("IsRunning", isRunning); // Set animation

            #region Movement

            if (movementInput == Vector2.right && !player.isRight)
            {
                player.Rotate();
            }

            if (movementInput == Vector2.left && player.isRight)
            {
                player.Rotate();
            }

            MovePlayer(player.Speed); // Move player

            #endregion

            //
            // Jump
            //
            if (isJumpPressed)
            {
                if (player.IsGrounded)
                {
                    jumpQuery = true;
                }
                else if(player.Rigidbody.velocity.y < -5)
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
                    player.Rigidbody.AddForce(new Vector2(player.Speed * 50 * rotation, 0));
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
        playerInput.Player.Jump.canceled += Jump; // End Jump

        playerInput.Player.ItemIndex.started += OnItemChanged; // On item change
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

        player.transform.position += Time.deltaTime * _speed * currentMovement;
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

    public void Start()
    {
        player = GetComponent<_Player>();
        stateMachine = GetComponent<StateMachine>();

        itemIndex = 0;
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
