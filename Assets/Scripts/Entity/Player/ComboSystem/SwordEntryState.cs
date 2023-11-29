using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SwordEntryState : State
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        State nexState = (State)new GroundEntryState();
        stateMachine.SetNextState(nexState);
    }
}