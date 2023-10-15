using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPreparingState : BowBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        bowStateName = "PrepareBow";
        duration = .683f;
        animator.SetTrigger(bowStateName);
        Debug.Log("Bow Preparing");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedtime >= duration)
        {
            stateMachine.SetNextState(new BowPreparedState());
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                shouldAttack = false;
                stateMachine.SetNextStateToMain();
            }
        }
    }
    public override void OnExit()
    {
        base.OnExit();
    }
}
