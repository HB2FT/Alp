public class IdleState : IdleBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        animator.SetTrigger("DropHand");
    }
}