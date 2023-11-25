using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideState : SlideBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

       

        duration = .35f;
        animator.SetTrigger("Slide");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        
        if (fixedtime >= duration)
        {
            stateMachine.SetNextState(new StandState());
        }
    }
}
