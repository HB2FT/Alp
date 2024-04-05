using UnityEngine;

namespace Mir.Entity.PlayerUtilities.BowSystem
{
    public class BowAttackState : BowBaseState
    {
        public override void OnEnter(StateMachine _stateMachine)
        {
            base.OnEnter(_stateMachine);

            duration = .133f;
            bowStateName = "ReleaseBow";
            animator.SetTrigger(bowStateName); Debug.Log(bowStateName);
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
}