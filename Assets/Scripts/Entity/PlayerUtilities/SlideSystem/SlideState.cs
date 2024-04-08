using Mir.Entity;

namespace Mir.Entity.PlayerUtilities.SlideSystem
{
    public class SlideState : SlideBaseState
    {
        public override void OnEnter(StateMachine _stateMachine)
        {
            base.OnEnter(_stateMachine);

            // Disable player input (All movements)
            _Player.instance.CanMove = false;

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

}