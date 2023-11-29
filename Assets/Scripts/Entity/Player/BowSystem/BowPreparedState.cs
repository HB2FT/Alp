using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BowPreparedState : BowBaseState
{
    private Player player;

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        duration = .683f;
        bowStateName = "BowPrepared";

        player = GetComponent<Player>();
        player.Speed = player.speedTemp / 4;
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

        player.Speed = player.speedTemp;
    }
}
