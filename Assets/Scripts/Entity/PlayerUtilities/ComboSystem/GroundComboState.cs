using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundComboState : SwordBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        // Attack
        attackIndex = 2;
        duration = .4f;
        animator.SetTrigger("Attack" + attackIndex);
        Debug.Log("Player Atack" + 2 + " -> Attacked");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedtime >= duration)
        {
            if (shouldCombo.Value)
            {
                stateMachine.SetNextState(new GroundFinisherState());
            }

            else
            {
                stateMachine.SetNextStateToMain();
            }
        }
    }
}
