using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCharacter : MonoBehaviour
{
    private StateMachine stateMachine;

    [SerializeField] public Collider2D hit;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && stateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            stateMachine.SetNextState(new GroundEntryState());
        }

        if (Input.GetMouseButtonDown(0) && stateMachine.CurrentState.GetType() == typeof(IdleBowState))
        {
            stateMachine.SetNextState(new BowPreparingState());
        }


    }
}
