using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEntryState : SwordBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        // Attack
        attackIndex = 1;
        duration = .35f;
        animator.SetTrigger("Attack" +  attackIndex);
        Debug.Log("Player Atack" + 1 + " -> Attacked");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedtime >= duration)
        {
            if (shouldCombo)
            {
                stateMachine.SetNextState(new GroundComboState());
            }

            else
            {
                stateMachine.SetNextStateToMain();
            }
        }
    }
}
