using Mir.Entity.Player;
using Mir.Objects.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class _Player : Entity
{
    public StateMachine stateMachine;
    public ItemSystem ItemSystem;

    [Obsolete]
    private int itemIndex;
    private int _itemIndex; // Temp variable for InputSystem.currentItemIndex

    public override void Start()
    {
        base.Start();

        stateMachine = GetComponent<StateMachine>();

        _itemIndex = 0;
    }

    public override void Update()
    {
        base.Update();

        if (!IsDead)
        {
            if (_itemIndex != ItemSystem.currentItemIndex)
            {
                ChangeState();
            }

            _itemIndex = ItemSystem.currentItemIndex;
        }
    }

    [Obsolete]
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
        if (ItemSystem.currentItemIndex == 0)
        {
            if (stateMachine.mainStateType.GetType() != typeof(IdleState))
            {
                stateMachine.mainStateType = new IdleState();
            }
        }

        if (ItemSystem.currentItemIndex == 1)
        {
            if (stateMachine.mainStateType.GetType() != typeof(IdleCombatState))
            {
                stateMachine.mainStateType = new IdleCombatState();
            }
        }

        if (ItemSystem.currentItemIndex == 2)
        {
            if (stateMachine.mainStateType.GetType() != typeof(IdleBowState))
            {
                stateMachine.mainStateType = new IdleBowState();
            }
        }

        stateMachine.SetNextStateToMain();
    }
}
