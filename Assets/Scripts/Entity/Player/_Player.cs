using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class _Player : Entity
{
    public StateMachine stateMachine;

    private int itemIndex;

    public override void Start()
    {
        base.Start();

        stateMachine = GetComponent<StateMachine>();

        itemIndex = 0;
    }

    public override void Update()
    {
        base.Update();

        if (!IsDead)
        {
            
        }
    }

    public int ItemIndex
    {
        get { return itemIndex; }
        set 
        { 
            itemIndex = value;

            ChangeState();
        }
    }

    private void ChangeState()
    {
        if (itemIndex == 0)
        {
            if (stateMachine.mainStateType.GetType() != typeof(IdleState))
            {
                stateMachine.mainStateType = new IdleState();
            }
        }

        if (itemIndex == 1)
        {
            if (stateMachine.mainStateType.GetType() != typeof(IdleCombatState))
            {
                stateMachine.mainStateType = new IdleCombatState();
            }
        }

        if (itemIndex == 2)
        {
            if (stateMachine.mainStateType.GetType() != typeof(IdleBowState))
            {
                stateMachine.mainStateType = new IdleBowState();
            }
        }

        stateMachine.SetNextStateToMain();
    }
}
