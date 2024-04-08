using Mir.Entity.PlayerUtilities.ComboSystem;

namespace Mir.Entity.PlayerUtilities.IdleSystem
{
    public class IdleState : IdleBaseState
    {
        public override void OnEnter(StateMachine _stateMachine)
        {
            base.OnEnter(_stateMachine);

            animator.SetTrigger("DropHand");
        }
    }
}