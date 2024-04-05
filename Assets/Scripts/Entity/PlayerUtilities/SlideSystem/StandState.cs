using Mir.Entity.PlayerUtilities;

namespace Mir.Entity.PlayerUtilities.SlideSystem
{
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

                // Enable player input (ALL movements)
                PlayerMovement.CanMove = true;
            }
        }
    }
}