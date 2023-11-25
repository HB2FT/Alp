using UnityEngine;
using UnityEngine.InputSystem;

public class SwordBaseState : State
{
    private PlayerInput playerInput;

    public float duration;
    protected Animator animator;
    protected bool shouldCombo;
    protected int attackIndex;
    protected bool isAttackPressed;

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        animator = GetComponent<Animator>();

        playerInput = new PlayerInput();

        playerInput.Enable();

        playerInput.Player.Attack.started += Attack;

    }

    void Attack(InputAction.CallbackContext context)
    {
        isAttackPressed = context.ReadValueAsButton();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (isAttackPressed)
        {
            shouldCombo = true;
            isAttackPressed = false;
        }
    }

    public override void OnExit()
    {
        base.OnExit();

        playerInput.Disable();
    }
}