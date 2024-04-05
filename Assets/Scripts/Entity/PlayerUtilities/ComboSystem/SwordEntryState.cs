public class SwordEntryState : State
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        State nexState = (State)new GroundEntryState();
        stateMachine.SetNextState(nexState);
    }
}