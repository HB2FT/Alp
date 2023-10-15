using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BowPreparedState : BowBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        duration = .683f;
        bowStateName = "BowPrepared";
        //animator.SetTrigger(bowStateName);
        //Debug.Log(bowStateName);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (Input.GetMouseButtonUp(0))
        {
            stateMachine.SetNextState(new BowAttackState());
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
