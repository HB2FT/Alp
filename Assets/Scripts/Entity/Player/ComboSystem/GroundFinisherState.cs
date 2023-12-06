using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFinisherState : SwordBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        // Attack
        attackIndex = 3;
        duration = .433f;
        animator.SetTrigger("Attack" + attackIndex);
        Debug.Log("Player Atack" + 3 + " -> Attacked");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedtime >= duration)
        {
            if (shouldCombo.Value)
            {
                stateMachine.SetNextState(new GroundEntryState()); Debug.Log("Finisher to Entry");
            }

            else
            {
                stateMachine.SetNextStateToMain();
            }
        }
    }
}
