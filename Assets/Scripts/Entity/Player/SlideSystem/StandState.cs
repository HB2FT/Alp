using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandState : SlideBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        duration = .35f;
        animator.SetTrigger("Stand");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedtime >= duration)
        {
            stateMachine.SetNextStateToMain();
        }
    }
}
