using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class IdleCombatState : SwordBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        animator.SetTrigger("HandSword");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (shouldCombo.Value)
        {
            stateMachine.SetNextState(new GroundEntryState());
            shouldCombo.Value = false;
        }
    }
}