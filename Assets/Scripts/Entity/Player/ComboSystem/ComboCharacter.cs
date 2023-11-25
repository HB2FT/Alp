using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComboCharacter : MonoBehaviour
{
    private PlayerInput playerInput;
    private StateMachine stateMachine;

    [SerializeField] public Collider2D hit;

    private bool isAttackPressed;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttackPressed && stateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            stateMachine.SetNextState(new GroundEntryState());
            isAttackPressed = false;
        }

        if (isAttackPressed && stateMachine.CurrentState.GetType() == typeof(IdleBowState))
        {
            stateMachine.SetNextState(new BowPreparingState());
            isAttackPressed = false;
        }


    }

    private void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.Player.Attack.started += Attack; // On Attack
        playerInput.Player.Attack.canceled += Attack; // End Attack
    }

    void Attack(InputAction.CallbackContext context)
    {
        isAttackPressed = context.ReadValueAsButton();
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
